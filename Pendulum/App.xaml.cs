using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Hardcodet.Wpf.TaskbarNotification;

namespace Pendulum
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 调用`FindResource`获取才会显示出来
            TaskbarIcon taskbar = (TaskbarIcon)FindResource("Taskbar");
            // 设置悬停提示
            taskbar.ToolTipText = "Pendulum";
        }

        // 解锁视图
        private void Unlock_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Current.MainWindow as MainWindow;
            if (main.ResizeMode == ResizeMode.CanResize) return;

            // 最后调用不穿透方法
            main.SetTransparentNotHitThrough();
            main.ResizeMode = ResizeMode.CanResize;
            main.Background = Brushes.White;
            main.WindowStyle = WindowStyle.SingleBorderWindow;
        }

        // 锁定视图
        private void Lock_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Current.MainWindow as MainWindow;
            if (main.ResizeMode == ResizeMode.NoResize) return;

            main.ResizeMode = ResizeMode.NoResize;
            main.Background = Brushes.Transparent;
            main.WindowStyle = WindowStyle.None;
            // 最后调用穿透方法
            main.SetTransparentHitThrough();
        }
    }
}
