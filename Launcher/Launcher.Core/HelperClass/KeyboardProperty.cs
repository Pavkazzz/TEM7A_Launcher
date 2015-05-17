using System.Diagnostics;

namespace Launcher.Core.HelperClass
{
    public static class KeyboardProperty
    {
        private static bool _isRunning = false;

        /// <summary>
        /// Запуск метода вызова клавиатуры.
        ///  </summary>

        public static void KeyboardRun()
        {
            if (!_isRunning)
            {
                Process[] chromes = Process.GetProcessesByName("TabTip");
                if (chromes.Length == 0)
                {
                    Process.Start(@"C:\\Program Files\\Common Files\\microsoft shared\\ink\\tabtip.exe");
                }
            }

            _isRunning = true;

        }

        /// <summary>
        /// Завершение процесса вызова клавиатуры.
        /// </summary>
        public static void KeyboardClose()
        {
            if (_isRunning)
            {
                Process[] processArray = Process.GetProcessesByName(@"TabTip");
                foreach (Process process in processArray)
                {
                    process.Kill();
                }
            }
            _isRunning = false;

        }
    }
}