using System;
using System.Diagnostics;

public class ButtonCnt
{
	public void Open_GoogleChrome(object sender, RoutedEventArgs e)
	{
		Process.Start(new ProcessStartInfo("chrome.exe"))
	    {
			UseShellExecute = true;
		});
	}
}
