using System.IO;
using System.Threading;

namespace LogitechAudioVisualizer.Settings
{
    public class UserSettingsManager
    {
        private static UserSettingsManager m_instance;
        private WatcherService m_watcherService;
        private string m_fileName = "LogitechAudioVisualizer.Settings.json";

        public static UserSettingsManager Instance => m_instance ?? (m_instance = new UserSettingsManager());

        public UserSettings UserSettings { get; private set; }

        public void Init()
        {
            m_watcherService = new WatcherService();
            m_watcherService.FileChanged += OnWatcherServiceFileChanged;

            LoadUserSettings();
        }
               
        private void OnWatcherServiceFileChanged(object sender, System.IO.FileSystemEventArgs e)
        {
            LoadUserSettings();
        }

        private void LoadUserSettings()
        {
            while(!CheckFile())
            {
                Thread.Sleep(500);
            }
            UserSettings = UserSettings.FromJson(File.ReadAllText(m_fileName));
        }

        private bool CheckFile()
        {
            try
            {
                File.Open(m_fileName, FileMode.Open, FileAccess.Read).Dispose();
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}
