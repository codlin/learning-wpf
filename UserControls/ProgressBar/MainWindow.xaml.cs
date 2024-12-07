using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace CustomProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private double _currentProgress;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            // 设置初始值
            _currentProgress = 0;


            PulseProgressBar.Loaded += PulseProgressBar_Loaded;
            PulseProgressBar.SizeChanged += PulseProgressBar_SizeChanged;
        }

        private void PulseProgressBar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateCornerRadius();
        }

        private void PulseProgressBar_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCornerRadius();
        }

        private void UpdateCornerRadius()
        {
            if (PulseProgressBar.Template != null && PulseProgressBar.Template.FindName("PART_Track", PulseProgressBar) is Border track)
            {
                // 获取控件的高度
                double height = track.ActualHeight;
                double radius = height / 2; // 右侧圆角的半径为高度的一半

                // 动态设置 CornerRadius
                track.SetValue(Border.CornerRadiusProperty, new CornerRadius(0, radius, radius, 0));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public double Progress
        {
            get { return _currentProgress; }
            set
            {
                _currentProgress = value;
                OnPropertyChanged(nameof(Progress));
                //UpdateProgress();
            }
        }

        // 更新进度条
        private void UpdateProgress()
        {
            double newWidth = PulseProgressBar.ActualWidth * _currentProgress;

            // 使脉冲条宽度跟随进度变化
            //PulseProgressBar.Width = newWidth;

            // ProgressTransform
            //ProgressTransform.ScaleX = _currentProgress;

            // 对模板中的 ProgressBar 进行操作
            if (PulseProgressBar.Template != null && PulseProgressBar.Template.FindName("PART_Track", PulseProgressBar) is Border track)
            {
                // 获取 ScaleTransform
                if (track.RenderTransform is ScaleTransform scaleTransform)
                {
                    // 计算 ScaleX 的值，根据进度条的 Value 或 ActualWidth 更新
                    scaleTransform.ScaleX = _currentProgress; // 设置 ScaleX
                }
            }

        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        DispatcherTimer _timer = new();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _timer.Interval = TimeSpan.FromSeconds(0.1);
            _timer.Tick += (s, ev) =>
            {
                // _currentProgress 设置为 0 到 1 之间的随机数
                _currentProgress = new Random().NextDouble();
                Progress = _currentProgress;
            };
            _timer.Start();
        }

        private void Button_Stop(object sender, RoutedEventArgs e)
        {
            _timer?.Stop();
        }
    }
}