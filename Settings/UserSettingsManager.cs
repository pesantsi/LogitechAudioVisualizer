using System.IO;

namespace LogitechAudioVisualizer.Settings
{
    public class UserSettingsManager
    {
        private static UserSettingsManager m_instance;
        private WatcherService m_watcherService;

        public static UserSettingsManager Instance => m_instance ?? (m_instance = new UserSettingsManager());

        public UserSettings UserSettings { get; private set; }

        public void Init()
        {
            m_watcherService = new WatcherService();
            m_watcherService.FileChanged += OnWatcherServiceFileChanged;

            UserSettings = UserSettings.FromJson(File.ReadAllText("LogitechAudioVisualizer.Settings.json"));
        }

        private void OnWatcherServiceFileChanged(object sender, System.IO.FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
