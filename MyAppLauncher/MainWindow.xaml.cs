using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyAppLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> urls = new List<string>(new string[8]); //urlのリスト
        private ButtonManager buttonManager; //ButtonManager
        private DeleteSettingWindow deleteSettingWindow;
        public bool register = false; //新規登録ボタンを押したかどうか

        //開くときに呼ばれる
        public MainWindow()
        {
            InitializeComponent();
            buttonManager = new ButtonManager(this); // MainWindow を渡す
            deleteSettingWindow = new DeleteSettingWindow();
            deleteSettingWindow.InputMainWindow_DeleteSetting(this); //MainWindowを渡す
            LoadButtonSettings(); //設定項目をロード

            // このウィンドウが閉じられたらアプリごと終了
            this.Closed += (s, e) => Application.Current.Shutdown();
        }

        //ショートカットキー関数
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            int buttonNum;
            //Alt + Ctrl... + 0~9
            if((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                && (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt)))
            {
                if (e.Key >= Key.D0 && e.Key <= Key.D9)
                {
                    buttonNum = e.Key - Key.D0; //e.Key(列挙型)から数値を取り出す ex.3をおしたら37 - 34 = 3
                    string buttonFn;
                    buttonFn = "Start_Button" + buttonNum.ToString(); //メソッド名を作成
                    var method = this.GetType().GetMethod(buttonFn); //メソッドに変換
                    method?.Invoke(this, new object[] { null, null }); //メソッドを実行
                }
            }
        }

        //設定項目読み込み関数
        private void LoadButtonSettings()
        {
            for (int i = 0; i < urls.Count; i++)
            {
                string name = Properties.Settings1.Default[$"Name{i + 1}"]?.ToString(); //名前を読み込み
                string url = Properties.Settings1.Default[$"Url{i + 1}"]?.ToString(); //リンクを読み込み

                Button btn = FindName($"Button{i + 1}") as Button; //ボタンを取得
                if (btn != null && !string.IsNullOrWhiteSpace(name))
                {
                    btn.Content = name; //ボタンの名前を適応
                }

                urls[i] = url; //リンクを適応

                //urlがなかったら
                if (string.IsNullOrWhiteSpace(urls[i]))
                {
                    btn.Opacity = 0.5f; //ボタンを半透明
                }
                else
                {
                    btn.Opacity = 1f; //ボタンを半透明にする
                }
            }
        }

        //設定項目削除するウィンドウを開く
        public void Click_DeleteSetting(object sender, RoutedEventArgs e)
        {
            DeleteSettingWindow deleteSettingWindow = new DeleteSettingWindow();
            deleteSettingWindow.InputMainWindow_DeleteSetting(this); // MainWindowを渡す
            deleteSettingWindow.ShowDialog(); // 毎回新しいインスタンスを表示
        }

        //GoogleChromeを開くボタン
        public void Click_GoogleButton(object sender, RoutedEventArgs e)
        {
            buttonManager.Start_GoogleChrome();
        }

        //Xを開くボタン
        public void Click_X(object sender, RoutedEventArgs e)
        {
            buttonManager.Start_X();
        }

        //ChatGPTを開くボタン
        public void Click_ChatGPT(object sender, RoutedEventArgs e)
        {
            buttonManager.Start_ChatGPT();
        }

        //ユーザー指定のURL
        //任意ショートカットのボタン処理を実行する関数
        public void Button_URL(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button; //ボタンを取得
            string buttonFn = "Start_" + btn.Name; //名前を関数名に変換
            var method = this.GetType().GetMethod(buttonFn); //このスクリプトの関数を取得
            method?.Invoke(this, new object[] { null, null }); //関数を実行
        }

        //ボタン1
        public void Start_Button1(object sender, RoutedEventArgs e)
        {
            if (urls[0] == null) return;
            buttonManager.Button1_URL();
        }
        //ボタン2
        public void Start_Button2(object sender, RoutedEventArgs e)
        {
            if (urls[1] == null) return;
            buttonManager.Button2_URL();
        }
        //ボタン3
        public void Start_Button3(object sender, RoutedEventArgs e)
        {
            if (urls[2] == null) return;
            buttonManager.Button3_URL();
        }
        //ボタン4
        public void Start_Button4(object sender, RoutedEventArgs e)
        {
            if (urls[3] == null) return;
            buttonManager.Button4_URL();
        }
        //ボタン5
        public void Start_Button5(object sender, RoutedEventArgs e)
        {
            if (urls[4] == null) return;
            buttonManager.Button5_URL();
        }
        //ボタン6
        public void Start_Button6(object sender, RoutedEventArgs e)
        {
            if (urls[5] == null) return;
            buttonManager.Button6_URL();
        }
        //ボタン7
        public void Start_Button7(object sender, RoutedEventArgs e)
        {
            if (urls[6] == null) return;
            buttonManager.Button7_URL();
        }
        //ボタン8
        public void Start_Button8(object sender, RoutedEventArgs e)
        {
            if (urls[7] == null) return;
            buttonManager.Button8_URL();
        }

        //新規登録ウィンドウを開くボタン
        public void Click_NewRegisterWindow(object sender, RoutedEventArgs e)
        {
            //MainWindowをInputWindowに渡す
            InputWindow inputWindow = new InputWindow();
            inputWindow.InputMainWindow(this);

            inputWindow.ShowDialog(); //このウィンドウを閉じるまで操作不可にする
        }
    }
}