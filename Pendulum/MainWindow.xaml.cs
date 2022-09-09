using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pendulum
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : PerformanceDesktopTransparentWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // 读取位置大小并设置
            Rect restoreBounds = Properties.Settings.Default.MainRestoreBounds;
            Left = restoreBounds.Left;
            Top = restoreBounds.Top;
            Width = restoreBounds.Width;
            Height = restoreBounds.Height;
            // 读取窗口状态并设置
            WindowState = Properties.Settings.Default.MainWindowState;
            // 读取字体大小并设置
            label.FontSize = Properties.Settings.Default.FontSize;

            //设置样式
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            // 设置透明且点击穿透
            SetTransparentHitThrough();
            // 设置窗口总在最前
            Topmost = true;
            // 设置回调保证窗口最前
            Deactivated += Window_Deactivated;
            // 显示当前时间
            label.Content = DateTime.Now.ToString("HH:mm:ss");

            // 设置定时器，定时更新UI
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 200); // 参数依次为：日 时 分 秒 毫秒
            timer.Tick += Tick;
            timer.Start();

            // 设置滑块滑动回调
            slider.ValueChanged += SliderValueChanged;
        }

        // 窗口不活跃回调
        private void Window_Deactivated(object sender, EventArgs e)
        {
            // 设置窗口总在最前
            Topmost = true;
        }

        // 定时器回调
        private void Tick(object sender, EventArgs e)
        {
            label.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        // 滑块滑动回调
        private void SliderValueChanged(object sender, EventArgs e)
        {
            // 字体不能为0
            if (slider.Value == 0) return;
            // 根据滑块值设置字体
            label.FontSize = slider.Value * 512;
        }

        // 切换穿透
        public void ToggleThrough()
        {
            if (ResizeMode == ResizeMode.CanResize)
                SetThrough();
            else
                SetNotThrough();
        }

        // 设置允许穿透
        public void SetThrough()
        {
            if (ResizeMode == ResizeMode.NoResize) return;

            SetTransparentHitThrough();
            ResizeMode = ResizeMode.NoResize;
            slider.Visibility = Visibility.Hidden;
            WindowStyle = WindowStyle.None;
        }

        // 设置不穿透
        public void SetNotThrough()
        {
            if (ResizeMode == ResizeMode.CanResize) return;

            SetTransparentNotHitThrough();
            ResizeMode = ResizeMode.CanResize;
            slider.Visibility = Visibility.Visible;
            WindowStyle = WindowStyle.SingleBorderWindow;
        }

        // 设置鼠标按下的时候拖拽移动窗口
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        // 窗口关闭时的回调
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 保存窗口状态
            Properties.Settings.Default.MainRestoreBounds = RestoreBounds;
            Properties.Settings.Default.MainWindowState = WindowState;
            Properties.Settings.Default.FontSize = label.FontSize;
            Properties.Settings.Default.Save();
        }
    }
}
