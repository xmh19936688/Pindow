# note

## 使窗口透明并点击穿透

从[github](https://github.com/lindexi/lindexi_gd/tree/b26274ae2ba4b54c151b69db4e899781fb640597/RuhuyagayBemkaijearfear)下载如下文件：

```txt
BrushCreator.cs
PerformanceDesktopTransparentWindow.cs
Win32.Dwmapi.cs
Win32.WM.cs
Win32.cs
```

依次修改命名空间与当前一致，
修改`MainWindow.xaml.cs`中的基类为`PerformanceDesktopTransparentWindow`，
修改`MainWindow.xaml`中的根标签为`local:PerformanceDesktopTransparentWindow`，
如果在`MainWindow.xaml`中报错命名空间中找不到`PerformanceDesktopTransparentWindow`，点击重新生成解决方案。

## 使窗口总在最前

在`MainWindow()`中设置`Topmost = true;`，
在`MainWindow()`给`Deactivated`添加回调，在回调中设置`((Window)sender).Topmost=true;`。

## 定时更新label

`DispatcherTimer timer = new DispatcherTimer()`创建定时器，
`timer.Interval = new TimeSpan(0, 0, 0, 0, 200)`设置时间间隔，其中`TimeSpan`有多种重载，
`timertimer.Tick += Tick`给定时器设置回调，函数签名为`private void Tick(object sender, EventArgs e){}`。

## 创建系统托盘图标

在控制台执行`Install-Package Hardcodet.NotifyIcon.Wpf -Version 1.1.0`安装`NotifyIcon`，安装命令来自[nuget上的NotifyIcon](https://www.nuget.org/packages/Hardcodet.NotifyIcon.Wpf/)，
在`App.xaml`中添加命名空间`xmlns:tb="http://www.hardcodet.net/taskbar"`，
在`App.xaml`的`<Application.Resources>`内添加`<tb:TaskbarIcon>`，
在`App.xaml.cs`的`OnStartup`中获取并配置`TaskbarIcon`。

## 给系统托盘添加菜单

在`App.xaml`的`<tb:TaskbarIcon>`中添加`<tb:TaskbarIcon.ContextMenu>`，
在`<tb:TaskbarIcon.ContextMenu>`中的`<ContextMenu>`中添加`<MenuItem>`，
`<MenuItem>`的`Lock_Click`对应到`App.xaml.cs`中的同名方法，方法签名为`private void Click(object sender, RoutedEventArgs e)`。

## 允许通过菜单切换穿透和透明

在菜单回调方法中进行配置

## 允许在非透明状态下改变位置

在`MainWindow`中重写`OnMouseLeftButtonDown()`方法，在其中调用`DragMove()`。

## 通过滑块调整字体大小

`Slider`为滑块控件；
`Minimum`为最小值；
`Maximum`为最大值；
`Value`为当前值；
`ValueChanged`为滑动回调。

## 系统托盘图标双击命令

创建`TaskBarCommand`类并实现`ICommand`接口，
注册到`TaskbarIcon`的`DoubleClickCommand`上。

## 记录上次关闭时的窗口配置

在`Settings.settings`中添加`MainRestoreBounds`变量，类型为`System.Windows.Rect`，值为“左上宽高”，
在`Settings.settings`中添加`MainWindowState`变量，类型为`System.Windows.WindowState`，
在`MainWindow.xaml`中注册`Closing`回调，在`MainWindow.xaml.cs`中实现`Closing`回调，
在`Closing`回调中，保存状态，在`MainWindow()`方法中读取状态并初始化配置。

## 生成单个exe

- 在解决方案管理器视图中的项目上右键
- 点击管理NuGet程序包
- 在浏览中搜索`Costura.Fody`并安装
- 清理并重新生成解决方案
- 选择Debug或Release运行（调试或执行）一次
- 在项目的bin下的Debug或Release下生成的exe文件即可复制到其他地方运行

## 给exe指定icon

- 在解决方案管理器视图中的项目上右键，属性
- 在应用程序标签下设置图标

## 参考引用

- [WPF 制作高性能的透明背景异形窗口](https://blog.walterlv.com/post/wpf-transparent-window-without-allows-transparency.html)
- [WPF 制作支持点击穿透的高性能的透明背景异形窗口](https://lindexi.blog.csdn.net/article/details/112240402)
- [透明窗口且点击穿透代码依赖](https://github.com/lindexi/lindexi_gd/tree/b26274ae2ba4b54c151b69db4e899781fb640597/RuhuyagayBemkaijearfear)
- [窗口总在最前](https://www.itranslater.com/qa/details/2583224223888049152)
- [使用定时器操作UI界面](https://www.cnblogs.com/jianjipan/p/10479218.html)
- [nuget上的NotifyIcon](https://www.nuget.org/packages/Hardcodet.NotifyIcon.Wpf/)
- [使用NotifyIcon](https://www.codeproject.com/Articles/36468/WPF-NotifyIcon-2)
- [图标库](https://www.iconfont.cn/)
- [svg转ico](https://www.aconvert.com/cn/icon/svg-to-ico/)
- [拖拽移动窗口位置](https://docs.microsoft.com/en-us/dotnet/api/system.windows.window.dragmove?view=windowsdesktop-6.0#examples)
- [在App.cs中获取当前Window](https://zditect.com/article/505553.html)
- [在所有虚拟桌面显示窗口](https://winaero.com/how-to-make-a-window-visible-on-all-virtual-desktops-in-windows-10/)
- [WPF窗口保持上次关闭时的大小与位置](https://blog.csdn.net/qq_43307934/article/details/87971342)
- [WPF程序只生成一个Exe文件](https://www.cnblogs.com/luziking/p/15032206.html)
- [使用Costura.Fody插件将自己写的程序打包成一个可以独立运行的EXE文件](https://blog.csdn.net/wangjiaoshoudebaba/article/details/80787677)
- [设置icon](https://stackoverflow.com/questions/5531074/how-to-define-single-icon-for-main-window-and-exe-file)
- [在所有虚拟桌面显示，且不在alt+tab和win+tab显示](https://stackoverflow.com/questions/357076/best-way-to-hide-a-window-from-the-alt-tab-program-switcher/551847)
