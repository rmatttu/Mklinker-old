using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mklinker.External {
    public enum ConsoleWriteLineType { Normal, Error };
    public delegate void ConsoleWriteLineEventHandler(object sender,ConsoleWriteLineEventArgs e);

    public class ConsoleWriteLineEventArgs {
        string consoleOutputLine;
        public string ConsoleOutputLine { get { return consoleOutputLine; } }

        ConsoleWriteLineType type;
        public ConsoleWriteLineType Type { get { return type; } }

        public ConsoleWriteLineEventArgs(string consoleOutputLine,ConsoleWriteLineType type) {
            this.consoleOutputLine = consoleOutputLine;
            this.type = type;
        }
    }


}
