# note

## ʹ����͸���������͸

��[github](https://github.com/lindexi/lindexi_gd/tree/b26274ae2ba4b54c151b69db4e899781fb640597/RuhuyagayBemkaijearfear)���������ļ���

```txt
BrushCreator.cs
PerformanceDesktopTransparentWindow.cs
Win32.Dwmapi.cs
Win32.WM.cs
Win32.cs
```

�����޸������ռ��뵱ǰһ�£�
�޸�`MainWindow.xaml.cs`�еĻ���Ϊ`PerformanceDesktopTransparentWindow`��
�޸�`MainWindow.xaml`�еĸ���ǩΪ`local:PerformanceDesktopTransparentWindow`��
�����`MainWindow.xaml`�б��������ռ����Ҳ���`PerformanceDesktopTransparentWindow`������������ɽ��������

## ʹ����������ǰ

��`MainWindow()`������`Topmost = true;`��
��`MainWindow()`��`Deactivated`��ӻص����ڻص�������`((Window)sender).Topmost=true;`��

## ��ʱ����label

`DispatcherTimer timer = new DispatcherTimer()`������ʱ����
`timer.Interval = new TimeSpan(0, 0, 0, 0, 200)`����ʱ����������`TimeSpan`�ж������أ�
`timertimer.Tick += Tick`����ʱ�����ûص�������ǩ��Ϊ`private void Tick(object sender, EventArgs e){}`��

## ����ϵͳ����ͼ��

�ڿ���ִ̨��`Install-Package Hardcodet.NotifyIcon.Wpf -Version 1.1.0`��װ`NotifyIcon`����װ��������[nuget�ϵ�NotifyIcon](https://www.nuget.org/packages/Hardcodet.NotifyIcon.Wpf/)��
��`App.xaml`����������ռ�`xmlns:tb="http://www.hardcodet.net/taskbar"`��
��`App.xaml`��`<Application.Resources>`�����`<tb:TaskbarIcon>`��
��`App.xaml.cs`��`OnStartup`�л�ȡ������`TaskbarIcon`��

## ��ϵͳ������Ӳ˵�

��`App.xaml`��`<tb:TaskbarIcon>`�����`<tb:TaskbarIcon.ContextMenu>`��
��`<tb:TaskbarIcon.ContextMenu>`�е�`<ContextMenu>`�����`<MenuItem>`��
`<MenuItem>`��`Lock_Click`��Ӧ��`App.xaml.cs`�е�ͬ������������ǩ��Ϊ`private void Click(object sender, RoutedEventArgs e)`��

## ����ͨ���˵��л���͸��͸��

�ڲ˵��ص������н�������

## �����ڷ�͸��״̬�¸ı�λ�ú������С

��`MainWindow`����д`OnMouseLeftButtonDown()`�����������е���`DragMove()`��

## ���ڴ�С����Ӧ�����С

## ���ɴ�icon��exe

## �ο�����

- [WPF ���������ܵ�͸���������δ���](https://blog.walterlv.com/post/wpf-transparent-window-without-allows-transparency.html)
- [WPF ����֧�ֵ����͸�ĸ����ܵ�͸���������δ���](https://lindexi.blog.csdn.net/article/details/112240402)
- [͸�������ҵ����͸��������](https://github.com/lindexi/lindexi_gd/tree/b26274ae2ba4b54c151b69db4e899781fb640597/RuhuyagayBemkaijearfear)
- [����������ǰ](https://www.itranslater.com/qa/details/2583224223888049152)
- [ʹ�ö�ʱ������UI����](https://www.cnblogs.com/jianjipan/p/10479218.html)
- [nuget�ϵ�NotifyIcon](https://www.nuget.org/packages/Hardcodet.NotifyIcon.Wpf/)
- [ʹ��NotifyIcon](https://www.codeproject.com/Articles/36468/WPF-NotifyIcon-2)
- [ͼ���](https://www.iconfont.cn/)
- [svgתico](https://www.aconvert.com/cn/icon/svg-to-ico/)
- [��ק�ƶ�����λ��](https://docs.microsoft.com/en-us/dotnet/api/system.windows.window.dragmove?view=windowsdesktop-6.0#examples)
