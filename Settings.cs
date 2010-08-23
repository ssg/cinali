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
        const string runAtStartupKey = "RunAtStartup";
        const string runKey = "cinali";

        string[] defaultSites = new string[] {
            "www.example-site.com",
        };
        const string defaultOutputSubFolder = "cinali";
        const int defaultSpeedLimit = 16; // 16kbps default speed

        public string[] Sites { get; set; }
        public string OutputFolder { get; set; }
        public int SpeedLimit { get; set; }
        public bool RunAtStartup { get; set; }
        public bool NoLimit { get { return SpeedLimit == 0; } }

        public Settings()
        {
            Sites = defaultSites;
            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            OutputFolder = Path.Combine(desktopFolder, defaultOutputSubFolder);
            SpeedLimit = defaultSpeedLimit;
            RunAtStartup = true;
        }

        public void ReadFromRegistry()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(appRootKey);
            if (key == null)
            {
                return;
            }

            Sites = (string[])key.GetValue(sitesKey, Sites);                
            OutputFolder = (string)key.GetValue(outputFolderKey, OutputFolder);
            SpeedLimit = (int)key.GetValue(speedLimitKey, SpeedLimit);
            RunAtStartup = (bool)key.GetValue(runAtStartupKey, RunAtStartup);
            key.Close();
        }

        public void WriteToRegistry()
        {
            var key = Registry.CurrentUser.OpenSubKey(appRootKey, writable: true);
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(appRootKey);
            }
            key.SetValue(sitesKey, Sites);
            key.SetValue(outputFolderKey, OutputFolder);
            key.SetValue(speedLimitKey, SpeedLimit);
            key.SetValue(runAtStartupKey, RunAtStartup);
            key.Close();

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
            var key = Registry.CurrentUser.OpenSubKey(autoRunRootKey, writable:true);
            if (key == null)
            {
                return;
            }

            string cmd = String.Format(@"""{0}"" {1}",
                Assembly.GetExecutingAssembly().Location,
                AutoStartParameter);
            key.SetValue(runKey, cmd);
            key.Close();
        }

        private void removeFromStartup()
        {
            var key = Registry.CurrentUser.OpenSubKey(autoRunRootKey, writable:true);
            if (key == null)
            {
                return;
            }
            key.DeleteValue(runKey);
            key.Close();
        }

    }
}
