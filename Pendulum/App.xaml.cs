using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
            // 调用`FindResource`获取才会显示出来
            TaskbarIcon taskbar = (TaskbarIcon)FindResource("Taskbar");
            // 设置悬停提示
            taskbar.ToolTipText = "Pendulum";
            base.OnStartup(e);
        }
    }
}
