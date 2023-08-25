namespace WebTestGui
{
    public class FileWatcher : IDisposable
    {
        private readonly string filePath;
        private FileSystemWatcher fileSystemWatcher;

        public event Func<string, Task> FileChanged;

        public FileWatcher(string filePath, bool clearLogImmediately = false)
        {
            this.filePath = filePath;

            m_ClearLogImmediately = clearLogImmediately;

            // Inicializáljuk a fájlfigyelőt
            fileSystemWatcher = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(filePath)!,
                Filter = Path.GetFileName(filePath),
                EnableRaisingEvents = true
            };

            fileSystemWatcher.Changed += async (sender, e) =>
            {
                // Aszinkron eseménykezelő a fájl változására
                if (FileChanged != null)
                {
                    string content = await ReadAndClearFileAsync();
                    await FileChanged(content);
                }
            };
        }

        private async Task<string> ReadAndClearFileAsync()
        {
            try
            {
                string content = await File.ReadAllTextAsync(filePath);
                if (m_ClearLogImmediately)
                {
                    await File.WriteAllTextAsync(filePath, string.Empty);
                }
                return content;
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }

        public void Dispose()
        {
            // Felszabadítjuk a figyelő erőforrásokat
            fileSystemWatcher.Dispose();
        }

        bool m_ClearLogImmediately;
    }
}
