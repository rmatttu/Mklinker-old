using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mklinker {
    public partial class Form1 : Form {
        MklinkStarter m;
        
        public Form1() {
            InitializeComponent();

            m = new MklinkStarter();

            //16x16サイズのUAC盾アイコンを取得する
            Icon shieldIcon = new Icon(SystemIcons.Shield, new Size(16, 16));
            Bitmap shieldBitmap = shieldIcon.ToBitmap();

            //ボタンに表示する
            //盾アイコンがテキストの左に表示されるようにする
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.Image = shieldBitmap;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void Form1_DragDrop(object sender, DragEventArgs e) {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if ( (e.Y - Location.Y) <= 72) textBox1.Text = fileName[0];
            else textBox2.Text = fileName[0];

        }

        private void button1_Click(object sender, EventArgs e) {
            m.Start(textBox1.Text, textBox2.Text, this);    
        }
    }
}
