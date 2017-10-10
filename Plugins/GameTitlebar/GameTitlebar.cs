namespace CarbuncleTech.Plugins.GameTitlebar
{
    using System;
    using System.Runtime.InteropServices;
    using ff14bot;
    using ff14bot.AClasses;

    public class GameTitlebar : BotPlugin
    {
        private const string OriginalTitle = @"FINAL FANTASY XIV";
        private const uint WM_SETTEXT = 0x000C;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint wmMsg, IntPtr wParam, string lParam);

        public override string Author => @"Freiheit";
        public override Version Version => new Version(0, 0, 0, 1);
        public override string Name => @"Custom Game Titlebar";

        private string _characterName = string.Empty;
        private uint _ticks;

        /// <summary>
        /// Sets a game client's window title.
        /// Use sparingly, it is expensive.
        /// </summary>
        /// <param name="customTitle"></param>
        private static void SetGameTitle(bool customTitle = true)
        {
            var mainWindowHdl = Core.Memory.Process.MainWindowHandle;
            var title = customTitle ? $@"{OriginalTitle} - {Core.Me.Name}" : OriginalTitle;
            
            SendMessage(mainWindowHdl, WM_SETTEXT, IntPtr.Zero, title);
        }

        public override void OnPulse()
        {
            if (_ticks >= 30)
            {
                _ticks = 0;

                var characterName = Core.Me.Name;

                if (_characterName != characterName)
                {
                    _characterName = characterName;
                    SetGameTitle(!string.IsNullOrEmpty(_characterName));
                }
            }
            else
            {
                _ticks++;    
            }
        }

        public override void OnEnabled()
        {
            SetGameTitle();
        }

        public override void OnDisabled()
        {
            SetGameTitle(false);
        }
    }
}