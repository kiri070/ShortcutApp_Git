using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyAppLauncher
{
    internal class ButtonManager
    {
        private MainWindow mainWindow;
        public ButtonManager(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        //urlがあるかチェックして返す関数
        private bool CheckURL(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                return true;
            }
            else
            {
                MessageBox.Show("URLが設定されていません");
                return false;
            }
        }

        //GoogleChromeを開くボタン
        public void Start_GoogleChrome()
        {
            Process.Start(new ProcessStartInfo("chrome.exe") { UseShellExecute = true });
        }

        //Xを開くボタン
        public void Start_X()
        {
            Process.Start(new ProcessStartInfo("https://x.com/home") { UseShellExecute = true });
        }

        //ChatGPTを開くボタン
        public void Start_ChatGPT()
        {
            Process.Start(new ProcessStartInfo("https://chatgpt.com/?model=gpt-4o") { UseShellExecute = true });
        }

        //Button1を開くボタン
        public void Button1_URL()
        {
            //URL有無チェック
            if (CheckURL(mainWindow.urls[0])) 
            {
                string url = mainWindow.urls[0];
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
        }

        //Button2を開くボタン
        public void Button2_URL()
        {
            if (CheckURL(mainWindow.urls[1]))
            {
                string url = mainWindow.urls[1];
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
        }
        //Button3を開くボタン
        public void Button3_URL()
        {
            if (CheckURL(mainWindow.urls[2]))
            {
                string url = mainWindow.urls[2];
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            
        }
        //Button4を開くボタン
        public void Button4_URL()
        {
            if (CheckURL(mainWindow.urls[3]))
            {
                string url = mainWindow.urls[3];
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            
        }
        //Button5を開くボタン
        public void Button5_URL()
        {
            if (CheckURL(mainWindow.urls[4]))
            {
                string url = mainWindow.urls[4];
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            
        }
        //Button6を開くボタン
        public void Button6_URL()
        {
            if (CheckURL(mainWindow.urls[5]))
            {
                string url = mainWindow.urls[5];
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            
        }
        //Button7を開くボタン
        public void Button7_URL()
        {
            if (CheckURL(mainWindow.urls[6]))
            {
                string url = mainWindow.urls[6];
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }

        }
        //Button8を開くボタン
        public void Button8_URL()
        {
            if (CheckURL(mainWindow.urls[7]))
            {
                string url = mainWindow.urls[7];
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }

        }
    }
}
