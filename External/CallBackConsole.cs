using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mklinker.External {
    public partial class CallBackConsole : UserControl {
        Color normal;
        Color error;
        delegate void WriteLineCallback(string str);
        delegate void WriteLineErrorCallback(string str);
        
        
        public CallBackConsole() {
            InitializeComponent();

            normal = Color.Black;
            error = Color.Red;
        }

        public void WriteLine(string str) {
            if (richTextBox1.InvokeRequired) {
                WriteLineCallback d = new WriteLineCallback(WriteLine);
                this.BeginInvoke(d, new object[] { str });
            } else {
                richTextBox1.SelectionLength = 0;
                richTextBox1.SelectionColor = normal;
                richTextBox1.Focus();
                richTextBox1.AppendText(DateAddedWriteLine(str));
            }
        }

        public void WriteLineError(string str) {
            if (richTextBox1.InvokeRequired) {
                WriteLineErrorCallback d = new WriteLineErrorCallback(WriteLineError);
                this.BeginInvoke(d, new object[] { str });
            } else {
                richTextBox1.SelectionLength = 0;
                richTextBox1.SelectionColor = error;
                richTextBox1.Focus();
                richTextBox1.AppendText(DateAddedWriteLine(str));
            }
        }

        string DateAddedWriteLine(string str) {
            //return  DateTime.Now.ToString("yyyy年MM月dd日_hh時mm分ss秒ffff ") + str + "\r\n";
            return DateTime.Now.ToString("hh時mm分ss秒 ") + str + "\r\n";
        }

    }
}
