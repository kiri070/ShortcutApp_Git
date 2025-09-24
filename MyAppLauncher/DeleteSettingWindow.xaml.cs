using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyAppLauncher
{
    /// <summary>
    /// DeleteSettingWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class DeleteSettingWindow : Window
    {
        public DeleteSettingWindow()
        {
            InitializeComponent();
        }

        MainWindow mainWindow;

        //MainWindowの参照をもらう関数
        public void InputMainWindow_DeleteSetting(MainWindow window)
        {
            this.mainWindow = window;
        }

        //削除ボタン
        public void Delete_Setting(object sender, RoutedEventArgs e)
        {
            //半角数字で入力されているか確認
            if (!int.TryParse(NumberBox.Text, out int index))
            {
                MessageBox.Show("半角数字を入力してください");
                return;
            }

            //ダイアログを表示
            MessageBoxResult result = MessageBox.Show(
                "該当番号のボタンの設定を削除しますか",
                "確認",
                MessageBoxButton.OKCancel);

            //OKを押した場合
            if (result == MessageBoxResult.OK)
            {
                if (index >= 0 && index < mainWindow.urls.Count)
                {
                    Button btn = mainWindow.FindName($"Button{index}") as Button; //ボタンを取得
                    btn.Content = "empty"; //ボタンのテキストをemptyに変更
                    btn.Opacity = 0.5f; //ボタンを半透明にする
                    Properties.Settings1.Default[$"Name{index}"] = ""; //該当の保存名を削除
                    Properties.Settings1.Default[$"Url{index}"] = ""; //該当のURL保存を削除
                    mainWindow.urls[index - 1] = ""; //url保存リストから該当のurlを削除
                    Properties.Settings1.Default.Save(); //保存

                    MessageBox.Show("削除しました");
                }
                else
                {
                    MessageBox.Show("番号がありません");
                }
            }
            //キャンセルを押した場合
            else
            {
                MessageBox.Show("キャンセルしました");
            }
        }
    }
}
