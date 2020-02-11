using System;
using System.Windows;
using System.Windows.Threading;

namespace LogitechAudioVisualizer.Helpers
{
    public static class DispatcherHelper
    {
        public static void InvokeIfRequired(Action action, DispatcherPriority priority = DispatcherPriority.Normal)
        {
            Dispatcher dispatcher = GetDispatcher();

            if (dispatcher.CheckAccess())
                action();
            else
                dispatcher.Invoke(action, priority);
        }

        public static T InvokeIfRequired<T>(Func<T> action, DispatcherPriority priority = DispatcherPriority.Normal)
        {
            Dispatcher dispatcher = GetDispatcher();

            if (dispatcher.CheckAccess())
                return action();
            else
                return dispatcher.Invoke(action, priority);
        }

        public static void BeginInvokeIfRequired(Action action, DispatcherPriority priority = DispatcherPriority.Normal)
        {
            Dispatcher dispatcher = GetDispatcher();

            if (dispatcher.CheckAccess())
                action();
            else
                dispatcher.BeginInvoke(action, priority);
        }

        public static bool IsInvokeRequired => !GetDispatcher().CheckAccess();

        private static Dispatcher GetDispatcher()
        {
            return
                Application.Current?.Dispatcher ??
                Dispatcher.CurrentDispatcher;
        }
    }
}
