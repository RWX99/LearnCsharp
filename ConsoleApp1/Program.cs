using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
        }

        /// <summary>
        /// 获取文件的哈希值
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        private static string GetFileHash(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hashBytes = md5.ComputeHash(stream);
                    var hashBuilder = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        hashBuilder.Append(b.ToString("x2"));
                    }
                    return hashBuilder.ToString().ToUpper();
                }
            }
        }

        /// <summary>
        /// 监视文件夹内文件变化
        /// </summary>
        /// <param name="watchPath">要监视的文件夹路径</param>
        private static void WatchedFolder(string watchPath)
        {
            if(!Directory.Exists(watchPath))
            {
                MessageBox.Show("要监视的目录不存在");
            }

            FileSystemWatcher watcher = new FileSystemWatcher
            {
                Path = watchPath,
                // 监视最后修改时间变化、文件新增和文件删除事件
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite
            };

            // 添加事件处理程序
            // 最后重命名变化事件处理程序
            watcher.Renamed += (object sender, RenamedEventArgs e) => Console.WriteLine($"{e.OldName,-40} 更名为 {e.Name} {new FileInfo(e.FullPath).LastWriteTime}");
            // 最后修改时间变化事件处理程序
            watcher.Changed += (object sender, FileSystemEventArgs e) => Console.WriteLine($"{e.Name,-40} 被修改 {new FileInfo(e.FullPath).LastWriteTime}");
            // 文件新增事件处理程序
            watcher.Created += (object sender, FileSystemEventArgs e) => Console.WriteLine($"{e.Name,-40} 被创建 {new FileInfo(e.FullPath).LastWriteTime}");
            // 文件删除事件处理程序
            watcher.Deleted += (object sender, FileSystemEventArgs e) => Console.WriteLine($"{e.Name,-40} 被删除 {new FileInfo(e.FullPath).LastWriteTime}");

            // 启动监视
            watcher.EnableRaisingEvents = true;

            // 等待用户退出程序
            Console.WriteLine("Press 'q' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        /// <summary>
        /// 启动外部程序
        /// </summary>
        /// <param name="exePath">要启动的外部程序路径</param>
        private static void StartExternalProcess(string exePath)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = "参数1 参数2",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);
        }
    }
}
