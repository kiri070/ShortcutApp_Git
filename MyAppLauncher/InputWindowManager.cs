using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyAppLauncher
{
    public partial class InputWindow : Window
    {
        
        public int buttonIndex { get; private set; } //ボタンの番号
        public string shortcutName { get; private set; } //ショートカットの名前
        public string shortcutUrl { get; private set; } //ショートカットのリンク

        MainWindow mainWindow;


        //MainWindowの参照をもらう関数
        public void InputMainWindow(MainWindow owner)
        {
            InitializeComponent();
            mainWindow = owner;
        }

        //登録ボタン
        public void Register_Click(object sender, RoutedEventArgs e)
        {
            //半角数字で入力されているか確認
            if (!int.TryParse(NumberBox.Text, out int index))
            {
                MessageBox.Show("半角数字を入力してください");
                return;
            }
            buttonIndex = index; //ボタンの番号
            //名前とリンクを登録
            shortcutName = NameBox.Text;
            shortcutUrl = URLBox.Text;

            //ボタン型に変換して取得
            Button targetButton = mainWindow.FindName("Button" + index) as Button;

            //入力に誤りがなければ
            if (!string.IsNullOrWhiteSpace(shortcutName) && !string.IsNullOrWhiteSpace(shortcutUrl))
            {
                targetButton.Content = shortcutName; //ボタンの名前を変更
                //urlを保存
                if (index - 1 >= 0 && index - 1 < mainWindow.urls.Count)
                {
                    mainWindow.urls[index - 1] = shortcutUrl;
                }
                else
                {
                    MessageBox.Show("インデックスが範囲外です");
                }

                //設定項目保存関数を呼ぶ
                SaveButtonSettings(index, shortcutName, shortcutUrl);

                targetButton.Opacity = 1f; //ボタンを完全に見える状態にする

                MessageBox.Show("登録が完了しました!");
                this.DialogResult = true; // MainWindowに成功を伝える
                this.Close();
            }
            else if (string.IsNullOrWhiteSpace(shortcutName) && !string.IsNullOrWhiteSpace(shortcutUrl))
            {
                MessageBox.Show("名前を入力してください");
            }
            else if (!string.IsNullOrWhiteSpace(shortcutName) && string.IsNullOrWhiteSpace(shortcutUrl))
            {
                MessageBox.Show("URLを入力してください");
            }
            else
            {
                MessageBox.Show("番号、名前、URLを入力してください");
            }
        }

        //ボタンの設定を保存する関数(ボタンの番号, ボタンの名前, リンク)
        private void SaveButtonSettings(int index, string name, string url)
        {
            Properties.Settings1.Default[$"Name{index}"] = name;
            Properties.Settings1.Default[$"Url{index}"] = url;
            Properties.Settings1.Default.Save(); //保存
        }
    }
}
