using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace _xUnitSpecflow
{
    class Program
    {
        public static readonly string m_workingDirectory = System.IO.Path.GetFullPath(@"..\..\..\specflow.automation\bin\Debug");
        static void Main(string[] args)
        {
            List<string> m_include = new List<string>() { "featureTag2" };
            List<string> m_exclude = new List<string>() { "featureTag1" };

            var l_categories = SetCategories(m_include, m_exclude);
            //Console.WriteLine("Main Hello world!");

            const string LOG_DIR = @"..\..\..\xUnitSpecflow\bin\debug\report";
            const string LOG_FILE = LOG_DIR + @"\VSOut.txt";

            if (!Directory.Exists(LOG_DIR))
            {
                Directory.CreateDirectory(LOG_DIR);
            }

            if (File.Exists(LOG_FILE))
            {
                var l_dir = new DirectoryInfo(LOG_DIR);
                foreach (var file in l_dir.EnumerateFiles("*.*"))
                {
                    file.Delete();
                }
            }

            string command = @"/C ..\..\..\packages\xunit.runner.console.2.4.1\tools\net452\xunit.console.exe xUnitSpecflow.exe -xml testlog.xml" + l_categories;
            Console.WriteLine("command is: '{0}'", command);

            //Thread.Sleep(30000);

            // execute tags and log output
            var l_execution = new Process
            {
                StartInfo =
                {
                    // project bin directory
                    WorkingDirectory = Path.GetFullPath(@"..\..\..\xUnitSpecflow\bin\Debug"),
                    FileName = "cmd.exe",
                    Arguments = command,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Normal,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true
                },
                EnableRaisingEvents = true
            };

            StreamWriter l_log = File.AppendText(LOG_FILE);

            l_execution.OutputDataReceived += new DataReceivedEventHandler((s, e) => {
                l_log.WriteLine(e.Data);
                Trace.WriteLine(e.Data);
                Console.WriteLine(e.Data);

            });
            l_execution.ErrorDataReceived += new DataReceivedEventHandler((s, e) => {
                l_log.WriteLine(e.Data);
                Trace.WriteLine(e.Data);
                Console.WriteLine(e.Data);
            });

            l_execution.Start();

            l_execution.BeginOutputReadLine();
            l_execution.BeginErrorReadLine();
            l_execution.WaitForExit();
            l_log.Close();


        }


        private static string SetCategories(List<string> p_include, List<string> p_exclude)
        {
            var l_includedCategories = "";

            // include categories in execution, logical or 
            foreach (var l_tag in p_include)
            {
                l_includedCategories += " -trait \"Category=" + l_tag.Trim() + "\"";
            }

            // exclude categories, logical or
            foreach (var l_tag in p_exclude)
            {
                l_includedCategories += " -notrait \"Category=" + l_tag.Trim() + "\"";
            }
            Console.WriteLine("XUNit Traits are: '{0}'", l_includedCategories);
            return l_includedCategories;

        }
    }
}
