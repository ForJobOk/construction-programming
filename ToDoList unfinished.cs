using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClearButtonClick
{
    public partial class Form1 : Form
    {
        List<TextBox> textList = new List<TextBox>(); //テキストボックス自体をリストとして扱える
        List<Button> buttonList = new List<Button>();  //ボタン自体をリストして扱える

        int clickCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//追加
        {
            clickCount++;
            TextBox[] text = new TextBox[clickCount]; //配列でクリックの回数分のテキストボックス
            Button[] button = new Button[clickCount]; //配列でクリックの回数分のボタン
            
            for (int i = 0; i <text.Length; i++) /*   i <= text.Length;にすると「インデックスが配列の境界外です」というエラー
                　　　　　　　　　　　　　　　　　    要素数＋１のループになるせい*/
            {

                text[i] = new TextBox();　　　　　　　　　//インスタンス生成
                text[i].Top = i * text[i].Height + 4;　　//貼り付け方
                text[i].Parent = this;　　　　　　　　　//フォームに貼り付け
                textList.Add(text[i]);　　　　　　　　　//生成されたテキストボックスをリストに追加


                button[i] = new Button();　　　　　　　　　　　　　　　　　　　　　　　　//インスタンス生成
                button[i].Top = i * button[i].Height;　　　　　　　　　　　　　　　　　　//貼り付け方
                button[i].Location = new Point(100,(i * button[i].Height) -(i - 1) * 4); //貼り付ける位置
                button[i].Size = new Size(100,20);　　　　　　　　　　　　　　　　　　　//ボタンの大きさ
                button[i].Text = "実行完了";　　　　　　　　　　　　　　　　　　　　　　//ボタンのテキスト
                button[i].Parent = this;　　　　　　　　　　　　　　　　　　　　　　　　//フォームに貼り付け
                button[i].Name = "b" +i.ToString();　　　　　　　　　　　　　　　　　　//それぞれに名前付け
                buttonList.Add(button[i]);　　　　　　　　　　　　　　　　　　　　　　//生成されたボタンをリストに追加

                button[i].Click += buttonI_Click;
               
            }

            
    }

        private void buttonI_Click(object sender, EventArgs e)　//実行完了ボタン
        {
            for (int i = 0; i <buttonList.Count; i++)　　　　　　//リストの要素数はLengthでは取得不可？
            {
                if (((Button)sender).Name == buttonList[i].Name) //(型名)sender　←　型キャスト　キャストしてから()で囲って名前を取得
                {
                    textList[i].Clear();　　　　　　　　　　　　//テキストボックスをクリア
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//消去
        {

                if (clickCount>0)
                {
                textList.Remove(textList[clickCount]);
                
                clickCount--;
                }

        }   
        
    }
}
