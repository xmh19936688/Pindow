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

依次修改命名空间与当前一致；
修改`MainWindow.xaml.cs`中的基类为`PerformanceDesktopTransparentWindow`；
修改`MainWindow.xaml`中的根标签为`local:PerformanceDesktopTransparentWindow`；
如果在`MainWindow.xaml`中报错命名空间中找不到`PerformanceDesktopTransparentWindow`，点击重新生成解决方案；

## 使窗口总在最前

在`MainWindow()`中设置`Topmost = true;`;
在`MainWindow()`给`Deactivated`添加回调，在回调中设置`((Window)sender).Topmost=true;`

## 每300ms更新label

## 创建系统托盘图标

## 给系统托盘添加菜单

## 允许通过菜单切换穿透和透明

## 允许在非透明状态下改变位置和大小

## 参考引用

- [WPF 制作高性能的透明背景异形窗口](https://blog.walterlv.com/post/wpf-transparent-window-without-allows-transparency.html)
- [WPF 制作支持点击穿透的高性能的透明背景异形窗口](https://lindexi.blog.csdn.net/article/details/112240402)
- [透明窗口且点击穿透代码依赖](https://github.com/lindexi/lindexi_gd/tree/b26274ae2ba4b54c151b69db4e899781fb640597/RuhuyagayBemkaijearfear)
- [窗口总在最前](https://www.itranslater.com/qa/details/2583224223888049152)
