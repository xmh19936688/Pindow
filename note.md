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

��`MainWindow()`������`Topmost = true;`;
��`MainWindow()`��`Deactivated`��ӻص����ڻص�������`((Window)sender).Topmost=true;`

## ��ʱ����label

`DispatcherTimer timer = new DispatcherTimer()`������ʱ����
`timer.Interval = new TimeSpan(0, 0, 0, 0, 200)`����ʱ����������`TimeSpan`�ж������أ�
`timertimer.Tick += Tick`����ʱ�����ûص�������ǩ��Ϊ`private void Tick(object sender, EventArgs e){}`��

## ����ϵͳ����ͼ��

## ��ϵͳ������Ӳ˵�

## ����ͨ���˵��л���͸��͸��

## �����ڷ�͸��״̬�¸ı�λ�ú������С

## ���ڴ�С����Ӧ�����С

## �ο�����

- [WPF ���������ܵ�͸���������δ���](https://blog.walterlv.com/post/wpf-transparent-window-without-allows-transparency.html)
- [WPF ����֧�ֵ����͸�ĸ����ܵ�͸���������δ���](https://lindexi.blog.csdn.net/article/details/112240402)
- [͸�������ҵ����͸��������](https://github.com/lindexi/lindexi_gd/tree/b26274ae2ba4b54c151b69db4e899781fb640597/RuhuyagayBemkaijearfear)
- [����������ǰ](https://www.itranslater.com/qa/details/2583224223888049152)
- [ʹ�ö�ʱ������UI����](https://www.cnblogs.com/jianjipan/p/10479218.html)
