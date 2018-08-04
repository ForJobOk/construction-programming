using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonClickCount
{
    public partial class Form1 : Form
    {
        int clickCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*最初、このブロック内でclickCountを初期化していた
            　そうするとボタンを押すたびに初期化してしまうのでエラーがでた
               参考　https://oshiete.goo.ne.jp/qa/7820170.html*/

            clickCount++;
            label1.Text = clickCount.ToString();
        }
    }
}
