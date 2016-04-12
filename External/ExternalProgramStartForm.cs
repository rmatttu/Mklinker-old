using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mklinker.External {
    public partial class ExternalProgramStartForm : Form {
        string workingDirectory;

        public ExternalProgramStartForm() {
            InitializeComponent();

            workingDirectory = Environment.ExpandEnvironmentVariables("%USERPROFILE%");
        }


        public void Start(string command, Form owner) {
            ConsoleCommandInvoker cmdInvoker = new ConsoleCommandInvoker(command, workingDirectory,owner);
            cmdInvoker.consoleWriteLineEventHandler += cmdInvoker_consoleWriteLineEventHandler;
            int exitCode = cmdInvoker.Start();
            callBackConsole1.WriteLine("exit code = " + exitCode.ToString());
        }



        void cmdInvoker_consoleWriteLineEventHandler(object sender, ConsoleWriteLineEventArgs e) {
            switch (e.Type) {
                case ConsoleWriteLineType.Error:
                    callBackConsole1.WriteLineError(e.ConsoleOutputLine);
                    break;
                case ConsoleWriteLineType.Normal:
                    callBackConsole1.WriteLine(e.ConsoleOutputLine);
                    break;
            }
        }

    }
}
