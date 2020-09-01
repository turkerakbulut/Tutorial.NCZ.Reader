#region Copyright (C) 2011-2020 Türker Akbulut

// Copyright (C) 2011-2020 Türker Akbulut
// https://turkerakbulut.com
// 
// Tutorial.NCZ.Reader is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// Tutorial.NCZ.Reader is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Tutorial.NCZ.Reader. If not, see <http://www.gnu.org/licenses/>.

#endregion
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace Tutorial.NCZ.Reader
{
    public enum LogLevel
    {
        ERROR,
        INFO,
        DEBUG
    }

    /// <summary>
    /// Asenkron File Logger
    /// </summary>
    public class NCZFileLogger
    {
        public static void Log(LogLevel level, string msg)
        {
            BackgroundProcess.Run(level + " : " + msg);
        }
    }

    public class BackgroundProcess
    {
        private string _msg;

        internal BackgroundProcess(string msg)
        {
            this._msg = msg;
        }

        private void Workerhandler(object sender, DoWorkEventArgs arg)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                backgroundProcess();
            });
        }

        private void backgroundProcess()
        {
            try
            {
                WriteLogFile(this._msg);
            }
            catch
            {
            }
        }

        public static void WriteLogFile(string message)
        {
            try
            {
                string yol = AppDomain.CurrentDomain.BaseDirectory + "Bin\\" + "NCZConverter.log";
                StreamWriter sw = File.AppendText(yol);
                sw.WriteLine("{0} : {1}", DateTime.Now.ToString(), message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        public void Run()
        {
            BackgroundWorker _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += Workerhandler;
            _backgroundWorker.RunWorkerAsync();
        }

        public static void Run(string msg)
        {
            BackgroundProcess process = new BackgroundProcess(msg);
            process.Run();
        }
    }
}