using System.Diagnostics;

namespace WebTestGui
{
    internal static class AppConsts
    {
        public static readonly string s_AppName = "VS WebTeszt";
        public static readonly string s_AppVersion = "v1.0";
        public static readonly string s_AppDefaultFileExtension = ".vsteszt";

        public static string s_JsonOutputFilepath = "C:\\Users\\kmarton\\source\\repos\\SeTestsVS\\main.json";
        public static string s_MainPythonScriptFilepath = "C:\\Users\\kmarton\\source\\repos\\SeTestsVS\\main.py";

        public static bool s_IsEditingAlreadyExistingTest = false;
        public static string? s_LoadedTestFilepath;

        public static string? m_JsConsoleSourceFilepath;

        public static void StartTestWithPythonScript(string jSonContents)
        {
            File.WriteAllText(s_JsonOutputFilepath, jSonContents);

            Process.Start("CMD.exe", $"python {s_MainPythonScriptFilepath}");
        }
    }
}
