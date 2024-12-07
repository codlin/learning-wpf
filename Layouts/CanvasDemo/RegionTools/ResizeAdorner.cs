using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using CanvasDemo.RegionTools;
using System;

public class ResizeAdorner : Adorner
{
    private readonly Thumb[] _thumbs;
    private readonly VisualCollection _visuals;
    private readonly FigureRegionRectVisual _adornedElement;

    public ResizeAdorner(FigureRegionRectVisual adornedElement) : base(adornedElement)
    {
        _adornedElement = adornedElement;
        _visuals = new VisualCollection(this);

        _thumbs = new[]
        {
            CreateThumb(Cursors.SizeNWSE), // _topLeft
            CreateThumb(Cursors.SizeNESW), // _topRight
            CreateThumb(Cursors.SizeNESW), // _bottomLeft
            CreateThumb(Cursors.SizeNWSE), // _bottomRight
            CreateThumb(Cursors.SizeNS),   // _topMiddle
            CreateThumb(Cursors.SizeNS),   // _bottomMiddle
            CreateThumb(Cursors.SizeWE),   // _leftMiddle
            CreateThumb(Cursors.SizeWE)    // _rightMiddle
        };

        foreach (var thumb in _thumbs)
        {
            _visuals.Add(thumb);
            thumb.DragDelta += HandleThumbDrag;
        }
    }

    private Thumb CreateThumb(Cursor cursor)
    {
        var thumb = new Thumb
        {
            Cursor = cursor,
            Width = 10,
            Height = 10,
            Background = Brushes.White,
            BorderBrush = Brushes.Black,
            BorderThickness = new Thickness(1)
        };

        // 移除立体效果
        var factory = new FrameworkElementFactory(typeof(Border));
        factory.SetValue(Border.BackgroundProperty, Brushes.White);
        factory.SetValue(Border.BorderBrushProperty, Brushes.Black);
        factory.SetValue(Border.BorderThicknessProperty, new Thickness(1));

        thumb.Template = new ControlTemplate(typeof(Thumb))
        {
            VisualTree = factory
        };

        return thumb;
    }

    private void HandleThumbDrag(object sender, DragDeltaEventArgs e)
    {
        if (sender is not Thumb thumb) return;

        var offsetX = e.HorizontalChange;
        var offsetY = e.VerticalChange;

        var figure = _adornedElement.Figure;
        var newLeft = figure.Left;
        var newTop = figure.Top;
        var newWidth = figure.Width;
        var newHeight = figure.Height;

        switch (Array.IndexOf(_thumbs, thumb))
        {
            case 0: // _topLeft
                newLeft += offsetX;
                newTop += offsetY;
                newWidth -= offsetX;
                newHeight -= offsetY;
                break;
            case 1: // _topRight
                newTop += offsetY;
                newWidth += offsetX;
                newHeight -= offsetY;
                break;
            case 2: // _bottomLeft
                newLeft += offsetX;
                newWidth -= offsetX;
                newHeight += offsetY;
                break;
            case 3: // _bottomRight
                newWidth += offsetX;
                newHeight += offsetY;
                break;
            case 4: // _topMiddle
                newTop += offsetY;
                newHeight -= offsetY;
                break;
            case 5: // _bottomMiddle
                newHeight += offsetY;
                break;
            case 6: // _leftMiddle
                newLeft += offsetX;
                newWidth -= offsetX;
                break;
            case 7: // _rightMiddle
                newWidth += offsetX;
                break;
        }

        if (newWidth > 0 && newHeight > 0)
        {
            figure.Left = newLeft;
            figure.Top = newTop;
            figure.Width = newWidth;
            figure.Height = newHeight;
        }

        _adornedElement.InvalidateVisual();
        InvalidateArrange();
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        var figure = _adornedElement.Figure;
        var adornedElementRect = new Rect(new Point(figure.Left, figure.Top), new Size(figure.Width, figure.Height));

        ArrangeThumb(_thumbs[0], adornedElementRect.TopLeft);
        ArrangeThumb(_thumbs[1], adornedElementRect.TopRight);
        ArrangeThumb(_thumbs[2], adornedElementRect.BottomLeft);
        ArrangeThumb(_thumbs[3], adornedElementRect.BottomRight);
        ArrangeThumb(_thumbs[4], new Point(adornedElementRect.Left + adornedElementRect.Width / 2, adornedElementRect.Top));
        ArrangeThumb(_thumbs[5], new Point(adornedElementRect.Left + adornedElementRect.Width / 2, adornedElementRect.Bottom));
        ArrangeThumb(_thumbs[6], new Point(adornedElementRect.Left, adornedElementRect.Top + adornedElementRect.Height / 2));
        ArrangeThumb(_thumbs[7], new Point(adornedElementRect.Right, adornedElementRect.Top + adornedElementRect.Height / 2));

        return finalSize;
    }

    private void ArrangeThumb(Thumb thumb, Point position)
    {
        thumb.Arrange(new Rect(
            new Point(position.X - thumb.Width / 2, position.Y - thumb.Height / 2),
            thumb.RenderSize
        ));
    }

    protected override Visual GetVisualChild(int index) => _visuals[index];

    protected override int VisualChildrenCount => _visuals.Count;
}
