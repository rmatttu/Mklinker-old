using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mklinker {
    public class Logger {
        readonly StreamWriter writer;

        public Logger() {
            writer = new StreamWriter("log.txt", true, Encoding.GetEncoding("shift-jis"));
            writer.WriteLine(DateTime.Now.ToString("[YYYY_MM_DD]_hh_mm_ss"));
        }

        public void WriteLine(string str) {
            writer.WriteLine(str);
        }

        public void flush() { writer.Flush(); }
        public void Close() {
            writer.WriteLine();
            writer.WriteLine();
            writer.Close();
        }

    }
}
