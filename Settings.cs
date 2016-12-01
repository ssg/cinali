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
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace cinali
{
    public class Settings
    {
        public const string AutoStartParameter = "-start";

        const string appRootKey = @"SOFTWARE\cinali";
        const string autoRunRootKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        // registry keys
        const string sitesKey = "Sites";
        const string outputFolderKey = "OutputFolder";
        const string speedLimitKey = "SpeedLimit";
        const string noLimitKey = "NoLimit";
        const string runAtStartupKey = "RunAtStartup";
        const string runKey = "cinali";

        string[] defaultSites = new string[] {
            "www.example-site.com",
        };
        const string defaultOutputSubFolder = "cinali";
        const int defaultSpeedLimit = 16; // 16kbps default speed
        const bool defaultNoLimit = false;

        public string[] Sites { get; set; }
        public string OutputFolder { get; set; }
        private int speedLimit;
        public int SpeedLimit { get { return speedLimit; } set { speedLimit = value; } }
        public bool RunAtStartup { get; set; }
        public bool NoLimit { get; set; }

        public Settings()
        { 
            Sites = defaultSites;
            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            OutputFolder = Path.Combine(desktopFolder, defaultOutputSubFolder);
            SpeedLimit = defaultSpeedLimit;
            NoLimit = defaultNoLimit;
            RunAtStartup = true;
        }

        public void ReadFromRegistry()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(appRootKey))
            {
                if (key == null)
                {
                    return;
                }

                Sites = (string[])key.GetValue(sitesKey, Sites);
                OutputFolder = (string)key.GetValue(outputFolderKey, OutputFolder);
                SpeedLimit = (int)key.GetValue(speedLimitKey, SpeedLimit);
                NoLimit = Convert.ToBoolean(key.GetValue(noLimitKey, NoLimit));
                RunAtStartup = Convert.ToBoolean(key.GetValue(runAtStartupKey, RunAtStartup));
            }
        }

        public void WriteToRegistry()
        {
            using (var key = Registry.CurrentUser.CreateSubKey(appRootKey))
            {
                key.SetValue(sitesKey, Sites);
                key.SetValue(outputFolderKey, OutputFolder);
                key.SetValue(speedLimitKey, SpeedLimit);
                key.SetValue(noLimitKey, NoLimit);
                key.SetValue(runAtStartupKey, RunAtStartup);
            }

            if (RunAtStartup)
            {
                addToStartup();
            }
            else
            {
                removeFromStartup();
            }
        }

        private void addToStartup()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(autoRunRootKey, writable: true))
            {
                if (key == null)
                {
                    return;
                }

                string cmd = String.Format(@"""{0}"" {1}",
                    Assembly.GetExecutingAssembly().Location,
                    AutoStartParameter);
                key.SetValue(runKey, cmd);
            }
        }

        private void removeFromStartup()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(autoRunRootKey, writable: true))
            {
                if (key == null)
                {
                    return;
                }
                if (key.GetValue(runKey) != null)
                {
                    key.DeleteValue(runKey);
                }
            }
        }

    }
}
