using System.Windows;

namespace LightButtonDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly LightViewModel _lightViewModel = new LightViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        // 底部圆内阴影颜色依赖属性
        public static readonly DependencyProperty BaseCircleInnerShadowColorProperty = DependencyProperty.Register(
            "BaseCircleInnerShadowColor", typeof(string), typeof(MainWindow), new PropertyMetadata("#000000"));

        // 底部圆内阴影颜色
        public string BaseCircleInnerShadowColor
        {
            get => (string)GetValue(BaseCircleInnerShadowColorProperty);
            set => SetValue(BaseCircleInnerShadowColorProperty, value);
        }

        // 四分圆外阴影颜色依赖属性
        public static readonly DependencyProperty QuarterCircleOuterShadowColorProperty = DependencyProperty.Register(
            "QuarterCircleOuterShadowColor", typeof(string), typeof(MainWindow), new PropertyMetadata("#000000"));

        // 四分圆外阴影颜色
        public string QuarterCircleOuterShadowColor
        {
            get => (string)GetValue(QuarterCircleOuterShadowColorProperty);
            set => SetValue(QuarterCircleOuterShadowColorProperty, value);
        }

        // 灯带内阴影颜色依赖属性
        public static readonly DependencyProperty LightStripInnerShadowColorProperty = DependencyProperty.Register(
            "LightStripInnerShadowColor", typeof(string), typeof(MainWindow), new PropertyMetadata("#000000"));
        // 灯带内阴影颜色
        public string LightStripInnerShadowColor
        {
            get => (string)GetValue(LightStripInnerShadowColorProperty);
            set => SetValue(LightStripInnerShadowColorProperty, value);
        }

        // 外灯带外圆装饰圆半径依赖属性
        public static readonly DependencyProperty OuterLightStripOuterAdornRadiusProperty = DependencyProperty.Register(
            "OuterLightStripOuterAdornRadius", typeof(double), typeof(MainWindow), new PropertyMetadata(50.0));
        // 外灯带外圆装饰圆半径
        public double OuterLightStripOuterAdornRadius
        {
            get => (double)GetValue(OuterLightStripOuterAdornRadiusProperty);
            set => SetValue(OuterLightStripOuterAdornRadiusProperty, value);
        }

        // 外灯带内圆装饰圆半径依赖属性
        public static readonly DependencyProperty OuterLightStripInnerAdornRadiusProperty = DependencyProperty.Register(
            "OuterLightStripInnerAdornRadius", typeof(double), typeof(MainWindow), new PropertyMetadata(36.0));
        // 外灯带内圆装饰圆半径
        public double OuterLightStripInnerAdornRadius
        {
            get => (double)GetValue(OuterLightStripInnerAdornRadiusProperty);
            set => SetValue(OuterLightStripInnerAdornRadiusProperty, value);
        }

        // 灯带装饰圆分割水平矩形尺寸依赖属性
        public static readonly DependencyProperty LightStripAdornCircleSplitHorizontalRectSizeProperty = DependencyProperty.Register(
            "LightStripAdornCircleSplitHorizontalRectSize", typeof(string), typeof(MainWindow), new PropertyMetadata("10,55,100,10"));
        // 灯带装饰圆分割水平矩形尺寸
        public string LightStripAdornCircleSplitHorizontalRectSize
        {
            get => (string)GetValue(LightStripAdornCircleSplitHorizontalRectSizeProperty);
            set => SetValue(LightStripAdornCircleSplitHorizontalRectSizeProperty, value);
        }

        // 灯带装饰圆分割垂直矩形尺寸依赖属性
        public static readonly DependencyProperty LightStripAdornCircleSplitVerticalRectSizeProperty = DependencyProperty.Register(
            "LightStripAdornCircleSplitVerticalRectSize", typeof(string), typeof(MainWindow), new PropertyMetadata("55,10,10,100"));
        // 灯带装饰圆分割垂直矩形尺寸
        public string LightStripAdornCircleSplitVerticalRectSize
        {
            get => (string)GetValue(LightStripAdornCircleSplitVerticalRectSizeProperty);
            set => SetValue(LightStripAdornCircleSplitVerticalRectSizeProperty, value);
        }

        // 外灯带外圆半径依赖属性
        public static readonly DependencyProperty OuterLightStripOuterRadiusProperty = DependencyProperty.Register(
            "OuterLightStripOuterRadius", typeof(double), typeof(MainWindow), new PropertyMetadata(48.0));
        // 外灯带外圆半径
        public double OuterLightStripOuterRadius
        {
            get => (double)GetValue(OuterLightStripOuterRadiusProperty);
            set => SetValue(OuterLightStripOuterRadiusProperty, value);
        }

        // 外灯带内圆半径依赖属性
        public static readonly DependencyProperty OuterLightStripInnerRadiusProperty = DependencyProperty.Register(
            "OuterLightStripInnerRadius", typeof(double), typeof(MainWindow), new PropertyMetadata(38.0));
        // 外灯带内圆半径
        public double OuterLightStripInnerRadius
        {
            get => (double)GetValue(OuterLightStripInnerRadiusProperty);
            set => SetValue(OuterLightStripInnerRadiusProperty, value);
        }

        // 灯带水平分割矩形尺寸依赖属性
        public static readonly DependencyProperty LightStripSplitHorizontalRectSizeProperty = DependencyProperty.Register(
            "LightStripSplitHorizontalRectSize", typeof(string), typeof(MainWindow), new PropertyMetadata("10,53,100,14"));
        // 灯带水平分割矩形尺寸
        public string LightStripSplitHorizontalRectSize
        {
            get => (string)GetValue(LightStripSplitHorizontalRectSizeProperty);
            set => SetValue(LightStripSplitHorizontalRectSizeProperty, value);
        }

        // 灯带垂直分割矩形尺寸依赖属性
        public static readonly DependencyProperty LightStripSplitVerticalRectSizeProperty = DependencyProperty.Register(
            "LightStripSplitVerticalRectSize", typeof(string), typeof(MainWindow), new PropertyMetadata("53,10,14,100"));
        // 灯带垂直分割矩形尺寸
        public string LightStripSplitVerticalRectSize
        {
            get => (string)GetValue(LightStripSplitVerticalRectSizeProperty);
            set => SetValue(LightStripSplitVerticalRectSizeProperty, value);
        }

        // 内灯带外圆装饰圆半径依赖属性
        public static readonly DependencyProperty InnerLightStripOuterAdornRadiusProperty = DependencyProperty.Register(
            "InnerLightStripOuterAdornRadius", typeof(double), typeof(MainWindow), new PropertyMetadata(30.0));
        // 内灯带外圆装饰圆半径
        public double InnerLightStripOuterAdornRadius
        {
            get => (double)GetValue(InnerLightStripOuterAdornRadiusProperty);
            set => SetValue(InnerLightStripOuterAdornRadiusProperty, value);
        }

        // 内灯带内圆装饰圆半径依赖属性
        public static readonly DependencyProperty InnerLightStripInnerAdornRadiusProperty = DependencyProperty.Register(
            "InnerLightStripInnerAdornRadius", typeof(double), typeof(MainWindow), new PropertyMetadata(20.0));
        // 内灯带内圆装饰圆半径
        public double InnerLightStripInnerAdornRadius
        {
            get => (double)GetValue(InnerLightStripInnerAdornRadiusProperty);
            set => SetValue(InnerLightStripInnerAdornRadiusProperty, value);
        }

        // 内灯带外圆半径依赖属性
        public static readonly DependencyProperty InnerLightStripOuterRadiusProperty = DependencyProperty.Register(
            "InnerLightStripOuterRadius", typeof(double), typeof(MainWindow), new PropertyMetadata(28.0));
        // 内灯带外圆半径
        public double InnerLightStripOuterRadius
        {
            get => (double)GetValue(InnerLightStripOuterRadiusProperty);
            set => SetValue(InnerLightStripOuterRadiusProperty, value);
        }

        // 内灯带内圆半径依赖属性
        public static readonly DependencyProperty InnerLightStripInnerRadiusProperty = DependencyProperty.Register(
            "InnerLightStripInnerRadius", typeof(double), typeof(MainWindow), new PropertyMetadata(22.0));
        // 内灯带内圆半径
        public double InnerLightStripInnerRadius
        {
            get => (double)GetValue(InnerLightStripInnerRadiusProperty);
            set => SetValue(InnerLightStripInnerRadiusProperty, value);
        }

    }
}