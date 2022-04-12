using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DevExpress.Utils.About;
using WinXmlFixer.Extensions;
using WinXmlFixer.Models;
using WinXmlFixer.Service;

namespace WinXmlFixer
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly string _path = Application.StartupPath;
        private CancellationTokenSource _cancellationTokenSource;

        public MainForm()
        {
            InitializeComponent();
        }

        #region UIFunctions

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), @"Unhandled Thread Exception");
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show((e.ExceptionObject as Exception)?.ToString(), @"Unhandled UI Exception");
        }
        public delegate void WriteToLogD(string s, Color c);
        public void WriteToLog(string s, Color c)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new WriteToLogD(WriteToLog), s, c);
                    return;
                }

                if (logT.Lines.Length > 5000)
                {
                    logT.Text = "";
                }
                logT.SelectionStart = logT.Text.Length;
                logT.SelectionColor = c;
                var l = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " : " + s + Environment.NewLine;
                logT.AppendText(l);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void NormalLog(string s)
        {
            WriteToLog(s, Color.Black);
        }
        public void ErrorLog(string s)
        {
            WriteToLog(s, Color.Red);
        }
        public void SuccessLog(string s)
        {
            WriteToLog(s, Color.Green);
        }
        public void CommandLog(string s)
        {
            WriteToLog(s, Color.Blue);
        }

        public delegate void SetProgressD(int x);
        public void SetProgress(int x)
        {
            if (InvokeRequired)
            {
                Invoke(new SetProgressD(SetProgress), x);
                return;
            }
            if ((x <= 100))
            {
                //ProgressB.Value = x;
            }
        }
        public delegate void DisplayD(string s);
        public void Display(string s)
        {
            if (InvokeRequired)
            {
                Invoke(new DisplayD(Display), s);
                return;
            }
            displayT.Text = s;
        }

        #endregion

        private void TestButton_Click(object sender, EventArgs e)
        {
            try
            {
                ScanTestFiles();
            }
            catch (KnownException ex)
            {
                ErrorLog(ex.Message);
            }
            catch (Exception ex)
            {
                ErrorLog($"{ex.Message} ({ex.Location()})");
            }
        }

        private bool ParseFile(string path)
        {
            var fileName = Path.GetFileName(path);
            var doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(path));
            var emptyMaterialNodes = doc.SelectNodes("//Orders/Order[@ProjectReference='Webshop' or ProjectReference='Webshop BE']/Ordercontent/Articles/preceding-sibling::Material[1][not(descendant::*)]");
            if (emptyMaterialNodes == null) throw new KnownException($"Null orders");
            if (emptyMaterialNodes.Count == 0) return false;
            foreach (XmlNode order in emptyMaterialNodes)
            {
                order.ParentNode?.RemoveChild(order);
            }
            NormalLog($"{fileName} removed {emptyMaterialNodes.Count} empty Material modes");
            if (!Directory.Exists($"{_path}/xml/modified"))
                Directory.CreateDirectory($"{_path}/xml/modified");

            var settings = new XmlWriterSettings
            {
                Indent = true,
                //NewLineHandling = NewLineHandling.None
            };

            var writer = XmlWriter.Create($"{_path}/xml/modified/{fileName}", settings);
            doc.Save(writer);
            writer.Dispose();
            return true;
        }


        private void ScanTestFiles()
        {
            logT.Text = "";
            SuccessLog($"Work started");
            if (!Directory.Exists($"{_path}/xml/original")) throw new KnownException("Folder xml/original don't exist");
            var files = Directory.GetFiles($"{_path}/xml/original");
            foreach (var file in files)
            {
                try
                {
                    ParseFile(file);
                }
                catch (Exception e)
                {
                    ErrorLog($"{Path.GetFileName(file)} : {e.Message} ({e.Location()})");
                }
            }
            SuccessLog($"Work completed");
        }

        private void saveConfigButton_Click(object sender, EventArgs e)
        {
            var config = new Config
            {
                FtpHost = ftpHostI.Text,
                FtpUser = ftpUserI.Text,
                FtpPass = ftpPassI.Text,
                XmlLocation = xmlLocationI.Text,
                RunAt = runAtI.Time
            };
            try
            {
                File.WriteAllText("config", JsonSerializer.Serialize(config));
                SuccessLog($"Config saved");
            }
            catch (Exception exception)
            {
                ErrorLog($"Failed to save config : {exception.Message}");
            }
        }

        void LoadConfig()
        {
            if (!File.Exists("config")) return;
            try
            {
                var config = JsonSerializer.Deserialize<Config>(File.ReadAllText("config"));
                ftpUserI.Text = config.FtpUser;
                ftpHostI.Text = config.FtpHost;
                ftpPassI.Text = config.FtpPass;
                xmlLocationI.Text = config.XmlLocation;
                runAtI.Time = config.RunAt;
            }
            catch (Exception e)
            {
                ErrorLog($"failed to load config : {e.Message}");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private async void runOnceButton_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            try
            {
                await RunOnce(_cancellationTokenSource.Token);
            }
            catch (TaskCanceledException )
            {
                CommandLog("Canceled by user");
                Display("Canceled");
            }
        }

        private async Task RunOnce(CancellationToken ct)
        {
            logT.Text = "";
            SuccessLog("Start working");
            Display("Start working");
            FtpService ftp=null;
            try
            {
                ftp = new FtpService(ftpHostI.Text, ftpUserI.Text, ftpPassI.Text);
                NormalLog("Connecting to Ftp");
                await ftp.Connect(ct);
                NormalLog($"listing files under {xmlLocationI.Text}");
                var fileList = (await ftp.GetFilesList(xmlLocationI.Text, ct: ct)).Where(x => x.Contains("orderspecificatie_gordijnen")).ToList();
                NormalLog($"There is {fileList.Count} order files detected");
                for (var i = 0; i < fileList.Count; i++)
                {
                    Display($"Working on file {i + 1} / {fileList.Count}");
                    var remotePath = fileList[i];
                    await FixFtpFile(ftp, remotePath, ct);
                }
            }
            catch (TaskCanceledException)
            {
                throw;
            }
            catch (KnownException e)
            {
                ErrorLog(e.Message);
            }
            catch (Exception e)
            {
                ErrorLog(e.ToString());
            }
            finally
            {
                ftp?.Disconnect();
            }
            SuccessLog("Work completed");
            Display("Work completed");
        }

        private async Task FixFtpFile(FtpService ftp, string remotePath,CancellationToken ct)
        {
            var fileName = Path.GetFileName(remotePath);
            try
            {
                var localPath = $"{_path}/xml/original/{fileName}";
                var localDir = $"{_path}/xml/original";
                var localModifiedPath = $"{_path}/xml/modified/{fileName}";
                await ftp.DownloadFile(remotePath, localDir, ct);
                var modified = ParseFile(localPath);
                if (!modified) return;
                await ftp.UploadFile(localModifiedPath, remotePath, ct);
                NormalLog($"{fileName} uploaded");
            }
            catch (TaskCanceledException)
            {
                throw;
            }
            catch (KnownException e)
            {
                ErrorLog($"{fileName} : {e.Message}");
            }
            catch (Exception e)
            {
                ErrorLog($"{fileName} : {e.Message} ({e.Location()})");
            }
        }

        private async void runLoopButton_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            try
            {
                do
                {
                    var now = DateTime.Now;
                    var nextRun = new DateTime(now.Year, now.Month, now.Day, runAtI.Time.Hour, runAtI.Time.Minute, runAtI.Time.Second);
                    if (now > nextRun)
                        nextRun = nextRun.AddDays(1);
                    var toWait = (int)(nextRun - DateTime.Now).TotalMilliseconds;
                    Display($"Next run At {nextRun:dd/MM/yyyy HH:mm:ss}");
                    await Task.Delay(toWait,_cancellationTokenSource.Token);
                    await RunOnce(_cancellationTokenSource.Token);
                } while (true);
            }
            catch (TaskCanceledException)
            {
               CommandLog("Loop Canceled by user");
               Display("Canceled");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
