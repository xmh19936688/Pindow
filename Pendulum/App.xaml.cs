using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Windows;
using System.Windows.Input;

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
            // 为双击注册命令
            taskbar.DoubleClickCommand = new TaskBarCommand();
        }

        // 解锁视图
        private void Unlock_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Current.MainWindow as MainWindow;
            main.SetNotThrough();
        }

        // 锁定视图
        private void Lock_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Current.MainWindow as MainWindow;
            main.SetThrough();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Current.MainWindow as MainWindow;
            main.Close();
        }
    }

    // taskbar的命令实现
    public class TaskBarCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // 获取当前window
            MainWindow main = Application.Current.MainWindow as MainWindow;
            // 切换穿透
            main.ToggleThrough();
        }
    }
}
