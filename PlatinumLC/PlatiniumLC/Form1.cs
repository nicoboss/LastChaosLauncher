using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using NAudio.Wave;
using System.Drawing;
using System.Globalization;

namespace PlatiniumLC
{
    public partial class Form1 : Form
    {
        //Declarations required for audio out and the MP3 stream
        IWavePlayer waveOutDevice;
        AudioFileReader audioFileReader;
        string ExecutablePath = Path.GetDirectoryName(Application.ExecutablePath);
        string PlatiniumClientPath;
        Process LastChaosLauncher = new Process();
        bool start_button_Enabled = true;
        bool fade_out_Enabled = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Only for the first start after the Installation
            if (Properties.Settings.Default.PlatiniumClientPath == "")
            {
                Properties.Settings.Default.PlatiniumClientPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PlatiniumLC_Client\";
                Properties.Settings.Default.Save();
            }
            PlatiniumClientPath = Properties.Settings.Default.PlatiniumClientPath;
            killSSH();
            waveOutDevice = new WaveOut();
            audioFileReader = new AudioFileReader(@".\Sound\lc.mp3");
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.PlaybackStopped += new EventHandler<StoppedEventArgs>(audio_loop);
            waveOutDevice.Play();
            //audioFileReader.Position = 45000000; // => beinahe Ende

            CopyFolder("./PlatiniumLC_Client", PlatiniumClientPath);


            Task.Factory.StartNew(() =>
            {
                try
                {
                    WebClient client = new WebClient();
                    Stream stream = client.OpenRead("http://lc.elderfun.ch/news.txt");
                    StreamReader reader = new StreamReader(stream);
                    Invoke((MethodInvoker)delegate ()
                    {
                        News_richTextBox.Text = reader.ReadToEnd();
                    });
                }
                catch (WebException)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        News_richTextBox.Text = "Die Newsdatei konnte nich von http://lc.elderfun.ch/news.txt " +
                                        "hinuntergeladen werden." + Environment.NewLine + Environment.NewLine +
                                        "Sind Sie etwa offline?";
                    });
                }
            });
        }

        private void audio_loop(object sender, EventArgs e)
        {
            audioFileReader.Position = 0;
            waveOutDevice.Play(); 
        }
        
        private void Start_button_Click(object sender, EventArgs e)
        {
            if(start_button_Enabled == false || fade_out_Enabled == true)
            {
                return;
            }

            start_button_Enabled = false;
            Start_button.ForeColor = Color.DarkGray;
            Start_button.Text = "Please wait";
            UpdateConsole_textBox.AppendText("Update started..." + Environment.NewLine);

            if (File.Exists(PlatiniumClientPath + "version.txt"))
            {
                var Version = File.ReadAllText(PlatiniumClientPath + "version.txt");
                try
                {
                    WebClient client = new WebClient();
                    Stream stream = client.OpenRead("http://lc.elderfun.ch/version.txt");
                    StreamReader reader = new StreamReader(stream);
                    var VersionNew = reader.ReadToEnd();

                    if (Version == VersionNew)
                    {
                        UpdateConsole_textBox.AppendText("No new version available" + Environment.NewLine);
                        Directory.SetCurrentDirectory(PlatiniumClientPath);
                        Process LC_Multiclient = new Process();
                        LC_Multiclient.StartInfo.FileName = "Multiclient.exe";
                        LC_Multiclient.StartInfo.UseShellExecute = false;
                        LC_Multiclient.Start();
                        Directory.SetCurrentDirectory(ExecutablePath);
                        UpdateConsole_textBox.AppendText("Platinium Last Chaos Client started!" + Environment.NewLine +
                                                          "done" + Environment.NewLine + Environment.NewLine);
                        Task wait = fade_out(7); // Oder this.Close();
                        //start_button_Enabled = true;
                        Start_button.ForeColor = Color.White;
                        Start_button.Text = "Start";
                        return;
                    }
                }
                catch (Exception ex) //when (ex is FileNotFoundException || ex is WebException) aber noch Win32Exception
                                     //von LC_Multiclient.Start(); falls Multiclient.exe nicht vorhanden ist.
                {
                    UpdateConsole_textBox.AppendText(ex.ToString() + Environment.NewLine);
                }
            }
            else
            {
                UpdateConsole_textBox.AppendText(@"Warning: File " + PlatiniumClientPath + "Version.txt not found!"
                                                  + Environment.NewLine + Environment.NewLine);   
            }

            try
            {
                Directory.SetCurrentDirectory(PlatiniumClientPath);
                LastChaosLauncher.StartInfo.FileName = "LastChaosLauncher.cmd";
                LastChaosLauncher.StartInfo.UseShellExecute = false;
                LastChaosLauncher.StartInfo.RedirectStandardOutput = true;
                LastChaosLauncher.StartInfo.CreateNoWindow = true;
                //LastChaosLauncher.StartInfo.WorkingDirectory = Path.GetFullPath(@".\PlatiniumClient\"); //Funktioniert irgendwie nicht!
                //LastChaosLauncher.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; Only works if UseShellExecute = true

                var OutputDataReceivedEvent = new DataReceivedEventHandler(
                    (s, eHandler) =>
                    {
                        if (eHandler.Data != null)
                        {
                            Invoke((MethodInvoker)delegate ()
                            {
                                UpdateConsole_textBox.AppendText(eHandler.Data.ToString() + Environment.NewLine);
                            });
                        }
                    }
                );

                LastChaosLauncher.EnableRaisingEvents = true;
                LastChaosLauncher.Exited += new EventHandler(
                    (s, eHandler) =>
                    {
                        //MessageBox.Show("Hi");
                        LastChaosLauncher.Close();
                        Invoke((MethodInvoker)delegate ()
                        {
                            UpdateConsole_textBox.AppendText("Platinium Last Chaos Client started!" + Environment.NewLine +
                                                              "done" + Environment.NewLine + Environment.NewLine);
                            Task wait = fade_out(7); // Oder this.Close();
                            //start_button_Enabled = true;
                            Start_button.ForeColor = Color.White;
                            Start_button.Text = "Start";
                        });
                        return;
                    }
                );

                LastChaosLauncher.OutputDataReceived += OutputDataReceivedEvent;
                LastChaosLauncher.ErrorDataReceived += OutputDataReceivedEvent;

                LastChaosLauncher.Start();
                Directory.SetCurrentDirectory(ExecutablePath);
                UpdateConsole_textBox.AppendText("rsync updater started" + Environment.NewLine);
                LastChaosLauncher.BeginOutputReadLine();
            }
            catch (Exception ex)
            {
                UpdateConsole_textBox.AppendText(ex.ToString() + Environment.NewLine);
                start_button_Enabled = true;
                Start_button.ForeColor = Color.White;
                Start_button.Text = "Start";
            }
        }

        private void Website_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://lc.elderfun.ch");
        }

        private void Register_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://lc.elderfun.ch/register.php?accept=none");
        }

        private void ClientFolder_button_Click(object sender, EventArgs e)
        {
            if (fade_out_Enabled == true)
            {
                return;
            }
            if (start_button_Enabled == false)
            {
                DialogResult AbortSync;
                if (CultureInfo.InstalledUICulture.TwoLetterISOLanguageName == "de")
                {
                    AbortSync = MessageBox.Show("Der Client Ordner kann nicht wärend einer synchronisazion verändert werden." + Environment.NewLine +
                                            "Wollen Sie die Synchronisation und somit auch das Starten des Clients abbrechen?" + Environment.NewLine +
                                            "Drücke \"Nein\" um nur den Client im Windows Explorer zu öffnen.",
                                            "Synchronisationsvorgang abbrechen?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                }
                else
                {
                    AbortSync = MessageBox.Show("The client folder can't be changed during synchronisation." + Environment.NewLine +
                                            "Do you want to abort the synching and so also starting of the client?" + Environment.NewLine +
                                            "Press \"No\" to only open the recent Client folder in the Windows Explorer.",
                                            "Abort rsync?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                }


                if (AbortSync == DialogResult.Yes)
                    killSync();
                else if (AbortSync == DialogResult.No)
                {
                    Process.Start(PlatiniumClientPath);
                    return;
                }
                else
                {
                    return;
                }
            }

            var folderBrowserDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                RootFolder = Environment.SpecialFolder.MyComputer,
                SelectedPath = PlatiniumClientPath,
                Description =
                    CultureInfo.InstalledUICulture.TwoLetterISOLanguageName
                    == "de"
                        ? @"Wählen Sie bitte das Verzeichniss in welchem sich der Platinium Last Chaos Client befinden soll. Der aktuelle Cient wird dabei verschoben => nicht erneut hinuntergeladen."
                        : @"Please select the folder where the Platinium Last Chaos Client should be. The recent client will be moved => not downloaded again.",
            };
            if (folderBrowserDlg.ShowDialog() == DialogResult.OK)
            {
                if (PlatiniumClientPath == folderBrowserDlg.SelectedPath)
                {
                    return;
                }
                Properties.Settings.Default.PlatiniumClientPath = folderBrowserDlg.SelectedPath + @"\";
                Properties.Settings.Default.Save();
                if (MoveFolderContent(PlatiniumClientPath, folderBrowserDlg.SelectedPath) == true)
                {
                    PlatiniumClientPath = folderBrowserDlg.SelectedPath + @"\";
                    MessageBox.Show("Client dictory sucessfully moved to " + PlatiniumClientPath, "Client dictory sucessfully changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                Process.Start(PlatiniumClientPath);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fade_out_Enabled == false)
            {
                e.Cancel = true;
                Task wait = fade_out(1);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            killSync();
        }

        public static void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                if (!File.Exists(dest))
                {
                    File.Copy(file, dest);
                }
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }

        public static void DeleteDirectory(string sourceFolder)
        {
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                File.Delete(file);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                DeleteDirectory(folder);
            }
            Directory.Delete(sourceFolder);
        }

        public static bool MoveFolderContent(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(sourceFolder))
            {
                MessageBox.Show("Sourcefolder doesn't exist!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (destFolder.Contains(sourceFolder) == true)
            {
                MessageBox.Show("The destinationfolder can't be in a subfolder of the sourcefolder!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            try
            {
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(destFolder, name);
                    if (File.Exists(dest))
                    {
                        File.Delete(dest);
                    }
                    File.Move(file, dest);
                }
                string[] folders = Directory.GetDirectories(sourceFolder);
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);
                    if (Directory.Exists(dest))
                    {
                        DeleteDirectory(dest);
                    }
                    Directory.Move(folder, dest);
                }

                try
                {
                    Directory.Delete(sourceFolder);
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void killSync()
        {
            try
            {
                //See http://stackoverflow.com/questions/3345363/kill-some-processes-by-exe-file-name
                //what should be do if above code return Exception(a 32 bit processes
                //cannot access modules of a 64 bit process) ? – Manish Aug 31 '13 at 11:29
                //Leave off ".exe".From MSDN: "The process name is a friendly name for the process,
                //such as Outlook, that does not include the .exe extension or the path" – slater Jun 3 '14 at 16:50
                //Beim Schliessen des Launchers alle Synchronisatzionsvorgänge abbrechen
                foreach (var process in Process.GetProcessesByName("rsync")) //
                {
                    process.Kill();
                }
                //foreach (var process in Process.GetProcessesByName("ssh"))
                //{
                //    process.Kill();
                //}
                LastChaosLauncher.Kill();
                LastChaosLauncher.Close();
            }
            catch //(InvalidOperationException) //for kill
            { }
        }

        private void killSSH()
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("ssh"))
                {
                    process.Kill();
                }
            }
            catch //(InvalidOperationException) //for kill
            { }
        }

        private async Task fade_out(int Seconds)
        {
            fade_out_Enabled = true;
            int steps = Seconds * 100;
            for (float i = steps; i > 0; i--)
            {
                this.Opacity = i / steps;
                audioFileReader.Volume = i / steps;
                await Task.Delay(10);
            }
            Application.Exit();
        }
    }
}


