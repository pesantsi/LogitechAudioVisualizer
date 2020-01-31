using System.IO;

namespace LogitechAudioVisualizer.Settings
{
    public class WatcherService
    {
        FileSystemWatcher m_watcher;
        public event FileSystemEventHandler FileChanged;

        public WatcherService()
        {
            m_watcher = new FileSystemWatcher();
            m_watcher.Path = Directory.GetCurrentDirectory();
            m_watcher.Filter = "*.json";
            m_watcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            m_watcher.Changed += OnFileChanged;

            m_watcher.EnableRaisingEvents = true;
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            FileChanged?.Invoke(sender, e);
        }
    }
}
