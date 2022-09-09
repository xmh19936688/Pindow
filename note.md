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

## �����ڷ�͸��״̬�¸ı�λ��

��`MainWindow`����д`OnMouseLeftButtonDown()`�����������е���`DragMove()`��

## ͨ��������������С

`Slider`Ϊ����ؼ���
`Minimum`Ϊ��Сֵ��
`Maximum`Ϊ���ֵ��
`Value`Ϊ��ǰֵ��
`ValueChanged`Ϊ�����ص���

## ϵͳ����ͼ��˫������

����`TaskBarCommand`�ಢʵ��`ICommand`�ӿڣ�
ע�ᵽ`TaskbarIcon`��`DoubleClickCommand`�ϡ�

## ��¼�ϴιر�ʱ�Ĵ�������

��`Settings.settings`�����`MainRestoreBounds`����������Ϊ`System.Windows.Rect`��ֵΪ�����Ͽ�ߡ���
��`Settings.settings`�����`MainWindowState`����������Ϊ`System.Windows.WindowState`��
��`MainWindow.xaml`��ע��`Closing`�ص�����`MainWindow.xaml.cs`��ʵ��`Closing`�ص���
��`Closing`�ص��У�����״̬����`MainWindow()`�����ж�ȡ״̬����ʼ�����á�

## ���ɵ���exe

- �ڽ��������������ͼ�е���Ŀ���Ҽ�
- �������NuGet�����
- �����������`Costura.Fody`����װ
- �����������ɽ������
- ѡ��Debug��Release���У����Ի�ִ�У�һ��
- ����Ŀ��bin�µ�Debug��Release�����ɵ�exe�ļ����ɸ��Ƶ������ط�����

## ��exeָ��icon

- �ڽ��������������ͼ�е���Ŀ���Ҽ�������
- ��Ӧ�ó����ǩ������ͼ��

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
- [��App.cs�л�ȡ��ǰWindow](https://zditect.com/article/505553.html)
- [����������������ʾ����](https://winaero.com/how-to-make-a-window-visible-on-all-virtual-desktops-in-windows-10/)
- [WPF���ڱ����ϴιر�ʱ�Ĵ�С��λ��](https://blog.csdn.net/qq_43307934/article/details/87971342)
- [WPF����ֻ����һ��Exe�ļ�](https://www.cnblogs.com/luziking/p/15032206.html)
- [ʹ��Costura.Fody������Լ�д�ĳ�������һ�����Զ������е�EXE�ļ�](https://blog.csdn.net/wangjiaoshoudebaba/article/details/80787677)
- [����icon](https://stackoverflow.com/questions/5531074/how-to-define-single-icon-for-main-window-and-exe-file)
- [����������������ʾ���Ҳ���alt+tab��win+tab��ʾ](https://stackoverflow.com/questions/357076/best-way-to-hide-a-window-from-the-alt-tab-program-switcher/551847)
