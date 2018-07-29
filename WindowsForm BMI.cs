using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //変数の宣言
            float bmi; 
            float w;
            float h;
            string result;

            

            string weight = textBox1.Text; //入力した体重を変数に代入
             w  = float.Parse(weight);　//文字列として取得した体重を数値に型変換

            string height = textBox2.Text; //入力した身長を変数に代入
             h = float.Parse(height); //文字列として取得した身長を数値に型変換


           

            bmi = w / (h * h); 　//体重÷(身長×身長)＝BMI


            if (bmi >= 25)
            {
                result = bmi.ToString(); //計算結果を文字列に変換

                label4.Text = result +" "+ "あなたは肥満です";　//ラベル４に結果を表示
            }
            else if (bmi >= 20)
            {
                result = bmi.ToString(); //計算結果を文字列に変換

                label4.Text = result + " " + "あなたは標準体型です";　//ラベル４に結果を表示
            }
            else if (bmi < 20　&& bmi >=10)
            {
                result = bmi.ToString(); //計算結果を文字列に変換

                label4.Text = result + " " + "あなたはやせ型です";　//ラベル４に結果を表示
            }
            else if (bmi < 10)
            {
                result = bmi.ToString(); //計算結果を文字列に変換

                label4.Text = "身長はメートルで入力してください";　//ラベル４に結果を表示
            }
            
            
          

        }
    }
}
