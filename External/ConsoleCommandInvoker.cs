using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mklinker.External {
    class ConsoleCommandInvoker {
        public event ConsoleWriteLineEventHandler consoleWriteLineEventHandler;
        Process process;
        int exitCode;

        public ConsoleCommandInvoker(string str, string workingDirectory,Form owner) {
            process = new Process();
            process.StartInfo.WorkingDirectory = workingDirectory;
            //出力とエラーをストリームに書き込むようにする
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.StartInfo.ErrorDialog = true;
            process.StartInfo.ErrorDialogParentHandle = owner.Handle;
            //OutputDataReceivedとErrorDataReceivedイベントハンドラを追加
            process.OutputDataReceived += p_OutputDataReceived;
            process.ErrorDataReceived += p_ErrorDataReceived;

            process.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            process.StartInfo.RedirectStandardInput = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = "/c " + str;
        }

        public int Start() {
            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit();
            return process.ExitCode;
        }

        public void Close() {
            process.Close();
        }

        void p_ErrorDataReceived(object sender, DataReceivedEventArgs e) {
            if (consoleWriteLineEventHandler != null) {
                consoleWriteLineEventHandler(sender, new ConsoleWriteLineEventArgs(e.Data, ConsoleWriteLineType.Error));
            }
        }

        void p_OutputDataReceived(object sender, DataReceivedEventArgs e) {
            if (consoleWriteLineEventHandler != null) {
                consoleWriteLineEventHandler(sender, new ConsoleWriteLineEventArgs(e.Data, ConsoleWriteLineType.Normal));
            }
        }
    }
}
