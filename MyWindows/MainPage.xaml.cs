using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using LRSkipAsync;
using LnkcntAsync;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace MyWindows
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region 初期設定
        private CS_LnkcntAsync lnkcnt;
        #endregion

        public MainPage()
        {
            this.InitializeComponent();

            lnkcnt = new CS_LnkcntAsync();

            TextBox01.Text = "";

            // 初期表示をクリアする
            ClearResultTextBox();
        }

        #region ［Ｌｎｋｃｎｔ］ボタン押下
        private async void button1_Click(object sender, RoutedEventArgs e)
        {   // [Lnkcnt]ボタン押下

            String KeyWord = TextBox01.Text;

            await lnkcnt.ExecAsync(KeyWord);
            WriteLineResult("\nResult : Wbuf[{0}]", lnkcnt.Wbuf);
            WriteLineResult("\n       : Lnkcnt[{0}]", lnkcnt.Lnkcnt);
        }
        #endregion

        #region ［Ｒｅｓｅｔ］ボタン押下
        private async void button3_Click(object sender, RoutedEventArgs e)
        {   // [Reset]ボタン押下
            ClearResultTextBox();			// 初期表示をクリアする
            
            await lnkcnt.ClearAsync();            // Lnkcntの内容を初期化する

            TextBox01.Text = "";
        }
        #endregion
    }
}
