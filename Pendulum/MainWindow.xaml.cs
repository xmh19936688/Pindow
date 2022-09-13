using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
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
            SetFlag();
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

        // 设置flag: WS_EX_TOOLWINDOW (0x00000080)
        // 通过设置flag实现在所有虚拟桌面显示，且不在alt+tab和win+tab显示
        public void SetFlag()
        {
            WindowInteropHelper wndHelper = new WindowInteropHelper(this);
            int exStyle = (int)GetWindowLong(wndHelper.Handle, (int)GetWindowLongFields.GWL_EXSTYLE);
            exStyle |= (int)ExtendedWindowStyles.WS_EX_TOOLWINDOW;
            SetWindowLong(wndHelper.Handle, (int)GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle);
        }

        // 窗口加载完成回调
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetFlag();
        }

        #region Window styles (copy from: https://stackoverflow.com/questions/357076/best-way-to-hide-a-window-from-the-alt-tab-program-switcher/551847)
        [Flags]
        public enum ExtendedWindowStyles
        {
            // ...
            WS_EX_TOOLWINDOW = 0x00000080,
            // ...
        }

        public enum GetWindowLongFields
        {
            // ...
            GWL_EXSTYLE = (-20),
            // ...
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        public static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            int error = 0;
            IntPtr result = IntPtr.Zero;
            // Win32 SetWindowLong doesn't clear error on success
            SetLastError(0);

            if (IntPtr.Size == 4)
            {
                // use SetWindowLong
                Int32 tempResult = IntSetWindowLong(hWnd, nIndex, IntPtrToInt32(dwNewLong));
                error = Marshal.GetLastWin32Error();
                result = new IntPtr(tempResult);
            }
            else
            {
                // use SetWindowLongPtr
                result = IntSetWindowLongPtr(hWnd, nIndex, dwNewLong);
                error = Marshal.GetLastWin32Error();
            }

            if ((result == IntPtr.Zero) && (error != 0))
            {
                throw new System.ComponentModel.Win32Exception(error);
            }

            return result;
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
        private static extern IntPtr IntSetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        private static extern Int32 IntSetWindowLong(IntPtr hWnd, int nIndex, Int32 dwNewLong);

        private static int IntPtrToInt32(IntPtr intPtr)
        {
            return unchecked((int)intPtr.ToInt64());
        }

        [DllImport("kernel32.dll", EntryPoint = "SetLastError")]
        public static extern void SetLastError(int dwErrorCode);
        #endregion
    }
}
