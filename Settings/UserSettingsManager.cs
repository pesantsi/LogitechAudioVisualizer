using System.IO;

namespace LogitechAudioVisualizer.Settings
{
    public class UserSettingsManager
    {
        private static readonly UserSettingsManager m_instance;
        private WatcherService m_watcherService;
        private RootObject m_rootObject;

        public static UserSettingsManager Instance { get { return m_instance ?? new UserSettingsManager(); } }
        public UserSettings UserSettings { get => m_rootObject.UserSettings; }

        public void Init()
        {
            m_watcherService = new WatcherService();
            m_watcherService.FileChanged += OnWatcherServiceFileChanged;

            m_rootObject = RootObject.FromJson(File.ReadAllText("LogitechAudioVisualizer.Settings.json"));
        }

        private void OnWatcherServiceFileChanged(object sender, System.IO.FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
