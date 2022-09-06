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
        }

        // 窗口不活跃回调
        private void Window_Deactivated(object sender, EventArgs e)
        {
            // 设置窗口总在最前
            ((Window)sender).Topmost=true;
        }
    }
}
