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
    }

}
