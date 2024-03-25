using System;

namespace WebTestGui
{
    public class Project
    {
        public Project(string projectDirectory)
        {
            m_RootDirectory = projectDirectory;
        }

        public string m_Name;
        public DateTime m_CreationDate;
        public string m_RootDirectory;
    }
}
