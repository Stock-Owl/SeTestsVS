using Microsoft.Win32;

namespace WebTestGui.Utils
{
    internal static class BrowserHelper
    {
        public static string GetChromeExecutablePath()
        {
            string chromePath = null;

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe"))
            {
                if (key != null)
                {
                    chromePath = key.GetValue(null) as string;
                }
            }

            return chromePath;
        }

        public static string GetFirefoxExecutablePath()
        {
            string firefoxPath = null;

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Mozilla\Mozilla Firefox"))
            {
                if (key != null)
                {
                    string path = key.GetValue("CurrentVersion") as string;
                    if (!string.IsNullOrEmpty(path))
                    {
                        using (RegistryKey pathKey = key.OpenSubKey(path))
                        {
                            if (pathKey != null)
                            {
                                firefoxPath = pathKey.GetValue("PathToExe") as string;
                            }
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(firefoxPath))
            {
                string[] standardPaths =
                {
                @"C:\Program Files\Mozilla Firefox\firefox.exe",
                @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe"
            };

                foreach (string path in standardPaths)
                {
                    if (File.Exists(path))
                    {
                        firefoxPath = path;
                        break;
                    }
                }
            }

            return firefoxPath;
        }
    }
}
