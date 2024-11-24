using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using CanvasDemo.RegionTools;
using CanvasDemo.RegionTools.Models;
using CanvasDemo.RegionTools.ViewModels;

using CommunityToolkit.Mvvm.Input;

namespace CanvasDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LayerManagerHost _layerManagerHost;
        public MainWindow()
        {
            InitializeComponent();
            _layerManagerHost = new();
        }

        private void DisplayCanvas(object sender, RoutedEventArgs e)
        {
            DrawCanvas();
        }

        private void DrawCanvas()
        {
            Window window = new();
            window.Title = "Canvas Sample";

            // create canvas
            Canvas canvas = new();
            canvas.Width = 600;
            canvas.Height = 400;
            canvas.Background = new SolidColorBrush(Colors.LightSkyBlue);

            // create circle
            Ellipse ellipse = new()
            {
                Fill = new SolidColorBrush(Colors.White),
                Width = 300,
                Height = 300
            };
            Canvas.SetTop(ellipse, 100);
            Canvas.SetLeft(ellipse, 100);
            canvas.Children.Add(ellipse);

            canvas.Children.Add(_layerManagerHost);

            window.Content = canvas;
            window.Owner = this;
            window.Show();
        }

        FigureRegionRectVisual? _figure;
        public FigureRegionRectVisual? Figure
        {
            get => _figure;
            set => _figure = value;
        }

        RegionToolWindowViewModel _regionToolVM;
        private void RegionToolBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_regionToolVM == null)
            {
                _regionToolVM = new()
                {
                    ClearRegionCommand = new RelayCommand(() =>
                    {
                        if (Figure != null)
                        {
                            canvas.Children.Remove(Figure);
                        }
                    })
                };
                _regionToolVM.PropertyChanged += RegionToolVM_PropertyChanged;
            }

            // 注册鼠标事件
            RegisterCanvasMouseEvents();

            Window window = new RegionToolWindow
            {
                Owner = this,
                DataContext = _regionToolVM,
                
            };
            window.Closing += Window_Closing;
            window.Show();
        }

        private void Window_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            UnregisterCanvasMouseEvents();

            // 移除矩形的控制块
            if (Figure != null)
            {
                var adornerLayer = AdornerLayer.GetAdornerLayer(Figure);
                if (adornerLayer != null)
                {
                    var adorners = adornerLayer.GetAdorners(Figure);
                    if (adorners != null)
                    {
                        foreach (var adorner in adorners)
                        {
                            if (adorner is ResizeAdorner)
                            {
                                adornerLayer.Remove(adorner);
                            }
                        }
                    }
                }
            }
            _adornerLayer = null;
        }

        private void RegionToolVM_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is RegionToolWindowViewModel vm)
            {
                if (e.PropertyName == nameof(vm.IsRegionRectBtnChecked))
                {
                    if (vm.IsRegionRectBtnChecked)
                    {
                        // 清除画布中存在的选取矩形
                        if (Figure != null)
                        {
                            canvas.Children.Remove(Figure);
                        }

                        Figure = new(new FigureRegionRect(new FigureStyle
                        {
                            Fill = new SolidColorBrush(Colors.Blue),
                            FillOpacity = 0.25,
                            BorderBrush = new SolidColorBrush(Colors.Blue),
                            BorderThickness = 1
                        })
                        {
                            Left = 0,
                            Top = 0,
                            Width = 0,
                            Height = 0,
                        });
                        canvas.Children.Add(Figure);
                    }
                }
            }
        }

        // 注册画布鼠标事件
        private void RegisterCanvasMouseEvents()
        {
            UnregisterCanvasMouseEvents();
            canvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown;
            canvas.MouseMove += Canvas_MouseMove;
            canvas.MouseLeftButtonUp += Canvas_MouseLeftButtonUp;
        }

        // 取消注册画布鼠标事件
        private void UnregisterCanvasMouseEvents()
        {
            canvas.MouseLeftButtonDown -= Canvas_MouseLeftButtonDown;
            canvas.MouseMove -= Canvas_MouseMove;
            canvas.MouseLeftButtonUp -= Canvas_MouseLeftButtonUp;
        }

        // 拖拽起始点
        Point? _dragStartPoint;
        AdornerLayer? _adornerLayer;
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(canvas);
            if (_regionToolVM.IsRegionRectBtnChecked)
            {
                if (Figure != null)
                {
                    _dragStartPoint = position;
                    Figure.Figure.Left = position.X;
                    Figure.Figure.Top = position.Y;
                    Figure.InvalidateVisual();
                }
            } else
            {
                _dragStartPoint = position;

                // 选取图形
                var hitTestResult = VisualTreeHelper.HitTest(Figure, position);
                if (hitTestResult != null)
                {
                    var visual = hitTestResult.VisualHit;
                    if (visual is FigureRegionRectVisual figure)
                    {
                        // 选中图形
                        figure.Figure.Style.Fill = new SolidColorBrush(Colors.Red);
                        figure.InvalidateVisual();

                        // 添加 Adorner
                        if (_adornerLayer == null)
                        {
                            _adornerLayer = AdornerLayer.GetAdornerLayer(figure);
                            if (_adornerLayer != null)
                            {
                                _adornerLayer.Add(new ResizeAdorner(figure));
                            }
                        }
                    }
                } else if (Figure != null)
                {
                    Figure.Figure.Style.Fill = new SolidColorBrush(Colors.Blue);
                    Figure?.InvalidateVisual();
                }
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _regionToolVM.IsRegionRectBtnChecked = false;
            _dragStartPoint = null;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var position = e.GetPosition(canvas);
            if (_regionToolVM.IsRegionRectBtnChecked)
            {
                // 绘制矩形
                if (Figure != null && _dragStartPoint.HasValue)
                {
                    Figure.Figure.Width = position.X - _dragStartPoint.Value.X;
                    Figure.Figure.Height = position.Y - _dragStartPoint.Value.Y;
                    Figure.InvalidateVisual();
                }
            } else
            {
                // 命中测试
                var hitTestResult = VisualTreeHelper.HitTest(canvas, position);
                if (hitTestResult != null)
                {
                    var visual = hitTestResult.VisualHit;
                    if (visual is FigureRegionRectVisual figure)
                    {
                        // 鼠标变成手型
                        canvas.Cursor = Cursors.Hand;

                        // 平移矩形位置
                        if (_dragStartPoint.HasValue)
                        {
                            canvas.Cursor = Cursors.SizeAll;

                            var offsetX = position.X - _dragStartPoint.Value.X;
                            var offsetY = position.Y - _dragStartPoint.Value.Y;
                            figure.Figure.Left += offsetX;
                            figure.Figure.Top += offsetY;
                            figure.InvalidateVisual();
                            _dragStartPoint = position;

                            // 更新 Adorner 位置
                            var adornerLayer = AdornerLayer.GetAdornerLayer(figure);
                            if (adornerLayer != null)
                            {
                                adornerLayer.Update();
                            }
                        }
                    }  else
                    {
                        canvas.Cursor = Cursors.Arrow;
                        _dragStartPoint = null;
                    }
                } else
                {
                    canvas.Cursor = Cursors.Arrow;
                    _dragStartPoint = null;
                }
            }
        }
    }
}
