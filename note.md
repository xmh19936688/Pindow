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

## 允许在非透明状态下改变位置和字体大小

在`MainWindow`中重写`OnMouseLeftButtonDown()`方法，在其中调用`DragMove()`。

## 窗口大小自适应字体大小

## 生成带icon的exe

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
