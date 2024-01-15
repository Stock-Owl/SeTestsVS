using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace WebTestGui
{
    public class LauncherAttributes
    {
        public LauncherAttributes(Launcher parentLauncher)
        {
            m_ParentLauncher = parentLauncher;
            m_RecentlyOpenedTests = new List<RecentlyOpenedTest>();
            if (File.Exists(m_LauncherAttributesFile))
            {
                m_FirstTimeOpening = false;
                string loadedAttr = File.ReadAllText(m_LauncherAttributesFile);
                LoadAttributesFromFile(loadedAttr);
            }
            else
                File.Create(m_LauncherAttributesFile);
        }

        public void SaveAttributesToFile()
        {
            string outStr = "";
            for (int i = 0; i < m_RecentlyOpenedTests.Count; i++)
            {
                if (i != 0)
                    outStr += "$" + m_RecentlyOpenedTests[i].m_TestFilePath;
                else
                    outStr += m_RecentlyOpenedTests[i].m_TestFilePath;

                outStr += "ß" + m_RecentlyOpenedTests[i].m_LastOpenedDate;
            }
            File.WriteAllText(m_LauncherAttributesFile, outStr);
        }

        public void LoadAttributesFromFile(string rawAttributesContent)
        {
            string[] rawFormat = rawAttributesContent.Split("$");
            for (int i = 0; i < rawFormat.Length; i++)
            {
                string[] rawContents = rawFormat[i].Split("ß");

                RecentlyOpenedTest recentlyOpenedTest = new RecentlyOpenedTest(m_ParentLauncher);
                recentlyOpenedTest.m_TestFilePath = rawContents[0];
                recentlyOpenedTest.m_LastOpenedDate = rawContents[1];

                m_RecentlyOpenedTests.Add(recentlyOpenedTest);
            }
        }

        public void AddToRecentlyOpenedTests(string testsFilePath, string date)
        {
            RecentlyOpenedTest recentlyOpenedTest = new RecentlyOpenedTest(m_ParentLauncher);
            recentlyOpenedTest.m_TestFilePath = testsFilePath;
            recentlyOpenedTest.m_LastOpenedDate = date;
            m_RecentlyOpenedTests.Add(recentlyOpenedTest);
        }

        public void OrganiseRecentlyOpenedTests()
        {
            m_RecentlyOpenedTests.Sort((item1, item2) => DateTime.ParseExact(item1.m_LastOpenedDate, "M/d/yyyy H:mm", CultureInfo.InvariantCulture)
                                     .CompareTo(DateTime.ParseExact(item2.m_LastOpenedDate, "M/d/yyyy H:mm", CultureInfo.InvariantCulture)));
            m_RecentlyOpenedTests.Reverse();

            HashSet<string> uniqueNames = new HashSet<string>();
            List<RecentlyOpenedTest> uniqueList = new List<RecentlyOpenedTest>();

            foreach (RecentlyOpenedTest myClass in m_RecentlyOpenedTests)
            {
                if (uniqueNames.Add(myClass.m_TestFilePath))
                {
                    uniqueList.Add(myClass);
                }
            }

            m_RecentlyOpenedTests.Clear();
            m_RecentlyOpenedTests.AddRange(uniqueList);
        }

        public string m_LauncherAttributesFile =
            Path.GetDirectoryName(Application.ExecutablePath) + "/launcherattr.vsattr";

        public bool m_FirstTimeOpening = true;
        public List<RecentlyOpenedTest> m_RecentlyOpenedTests;

        public Launcher m_ParentLauncher;
    }
}
