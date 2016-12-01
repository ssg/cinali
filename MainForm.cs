/*
Copyright 2010 Sedat Kapanoglu

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace cinali
{
    public partial class MainForm : Form
    {
        // defaults
        const string wgetArguments = "--mirror --user-agent={0} --random-wait --limit-rate={1}k --page-requisites http://{2}";
        const string wgetFileName = "wget.exe";
        const string wgetProcessName = "cinali-" + wgetFileName;
        const string userAgentsFileName = "UserAgents.txt";
        const string debugParameter = "-debug";

        bool mustStopNow = false;
        bool allowClose = false;
        bool showOutput = false;

        int perProcessLimit = 0;

        // user agents to rotate
        string[] userAgents;

        string wgetPath;
        Settings settings;

        Dictionary<Process, string> processList;

<<<<<<< HEAD
        bool isStartup = true;
=======
        bool isStartUp = true;
>>>>>>> origin/master

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            readSettings();

            userAgents = Resource.GetStringArray(userAgentsFileName);

            string path = Path.Combine(Path.GetTempPath(), wgetProcessName);
            Resource.ExtractFile(wgetFileName, path);
            wgetPath = path; // ensure no-exceptions

            var args = Environment.GetCommandLineArgs();
            if (args.Length > 0 && args[0] == Settings.AutoStartParameter)
            {
                start();
            }
        }

        /// <summary>
        /// Read settings and apply to form
        /// </summary>
        private void readSettings()
        {
            settings = new Settings();
            settings.ReadFromRegistry();
            sitesTextBox.Lines = settings.Sites;
            outputFolderTextBox.Text = settings.OutputFolder;
            noLimitCheckBox.Checked = settings.NoLimit;
            limitTextBox.Text = settings.SpeedLimit.ToString();
            limitPanel.Enabled = !settings.NoLimit;
            runAtStartupCheckBox.Checked = settings.RunAtStartup;

            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1] == debugParameter)
            {
                showOutput = true;
            }
        }

        /// <summary>
        /// Start the download operation
        /// </summary>
        private void start()
        {
            string[] siteNames = sitesTextBox.Lines;
            if (siteNames.Length == 0)
            {
                MessageBox.Show("Hiç site belirtilmemiş", 
                    "Olmadı", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (!Directory.Exists(settings.OutputFolder))
            {
                Directory.CreateDirectory(settings.OutputFolder);
            }

            startButton.Enabled = false;
            settingsPanel.Enabled = false;
            stopButton.Enabled = true;
            processList = new Dictionary<Process, string>();

            if (!settings.NoLimit)
            {
                perProcessLimit = settings.SpeedLimit / siteNames.Length;
                if (perProcessLimit < 1)
                {
                    perProcessLimit = 1;
                }
            }

            lock (processList)
            {
                foreach (string name in siteNames)
                {
                    startDownload(name);
                }
            }
        }

        private void startDownload(string name)
        {
            var rnd = new Random();
            string userAgent = userAgents[rnd.Next(userAgents.Length)];
            string arguments = String.Format(wgetArguments, userAgent, perProcessLimit, name);
            var processInfo = new ProcessStartInfo(wgetPath, arguments);
            processInfo.WorkingDirectory = settings.OutputFolder;
            processInfo.WindowStyle = showOutput ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden;
            Process process = new Process();
            process.StartInfo = processInfo;
            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(process_Exited);
            process.Start();
            processList[process] = name;
        }

        /// <summary>
        /// Triggered when a process is finished
        /// </summary>
        void process_Exited(object sender, EventArgs e)
        {
            Process process = (Process)sender;
            if (process.ExitCode > 0)
            {
                MessageBox.Show(String.Format("Wget çalışırken hata oluştu: 0x{0:x}",
                    process.ExitCode.ToString()), "Hata", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            lock (processList)
            {
                if (process.ExitCode == 0)
                {
                    startDownload(processList[process]);
                }
                processList.Remove(process);
                if (processList.Count == 0)
                {
                    mustStopNow = true;
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Durdurmak istediğinizden emin misiniz?",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                stop();
            }
        }

        /// <summary>
        /// Stop running operation 
        /// </summary>
        private void stop()
        {
            stopButton.Enabled = false;
            startButton.Enabled = true;
            settingsPanel.Enabled = true;
            if (processList == null)
            {
                return;
            }
            lock (processList)
            {
                foreach (var process in processList.Keys)
                {
                    process.Kill();
                }
                processList.Clear();
            }
        }

        /// <summary>
        /// Re-display main window
        /// </summary>
        private void restoreWindow()
        {
            Show();
            notifyIcon.Visible = false;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            restoreWindow();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // prevent application exit
            if (allowClose)
            {
                return;
            }
            Hide();
            notifyIcon.Visible = true;
            e.Cancel = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            settings.WriteToRegistry();
            stop();
            // we don't care about remaining wget.exe since we'll recreate it always
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            if (startButton.Enabled
                || MessageBox.Show("Hali hazırda işlem devam ediyor, iptal edip çıkmak istiyor musunuz?", "Alo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                allowClose = true;
                Close();
            }            
        }

        private void updateSpeedLimit()
        {
<<<<<<< HEAD
            if (isStartup)
            {
                isStartup = false;
=======
            if (isStartUp)
            {
                isStartUp = false;
>>>>>>> origin/master
                return;
            }

            if (noLimitCheckBox.Checked)
            {
                settings.NoLimit = noLimitCheckBox.Checked;
            }
            else
            {
                int value;
                if (int.TryParse(limitTextBox.Text, out value))
                {
                    settings.SpeedLimit = value;
                    settings.NoLimit = noLimitCheckBox.Checked;
                }
            }
        }

        private void noLimitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            limitPanel.Enabled = !noLimitCheckBox.Checked;
            updateSpeedLimit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            restoreWindow();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            allowClose = true;
            Close();
        }

        private void sitesTextBox_TextChanged(object sender, EventArgs e)
        {
            settings.Sites = sitesTextBox.Lines;
        }

        private void limitTextBox_TextChanged(object sender, EventArgs e)
        {
            updateSpeedLimit();
        }

        private void outputFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            settings.OutputFolder = outputFolderTextBox.Text;
        }

        private void runAtStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.RunAtStartup = runAtStartupCheckBox.Checked;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            start();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            using (var aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }

        private void browseFolder_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                outputFolderTextBox.Text = folderDialog.SelectedPath;
            }
        }

    }
}
