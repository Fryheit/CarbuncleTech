namespace CarbuncleTech.Plugins.SeleCR
{
    using System;
    using System.Linq;
    using System.Windows.Media;
    using Clio.Utilities.Helpers;
    using Common;
    using ff14bot;
    using ff14bot.AClasses;
    using ff14bot.Managers;

    public class SeleCR : BotPlugin
    {
        #region Plugin Metadata

#if RB_CN
        public override string Name => "职业战斗模块选择";
        public override string ButtonText => "设置";
#else
        public override string Name => "SeleCR";
        public override string ButtonText => "Configure";
#endif

        public override string Author => "Freiheit";
        public override Version Version => new Version(0, 0, 0, 1);
        public override string Description => "Automatically select a combat routine";
        public override bool WantButton => true;
        #endregion

        private SettingsWindow _settingsWindow;
        private readonly Color LogColor = Color.FromRgb(215, 40, 200);
        private bool _inPvpArea;
        private WaitTimer _pulseTimer;

        public override void OnButtonPress()
        {
            if (_settingsWindow == null || _settingsWindow.IsDisposed)
            {
                _settingsWindow = new SettingsWindow();
                _settingsWindow.Show();
            }
            else
            {
                _settingsWindow.BringToFront();
            }
        }

        public override void OnPulse()
        {
            if (_pulseTimer.IsFinished && _inPvpArea != WorldManager.InPvP)
            {
                _inPvpArea = WorldManager.InPvP;
                _pulseTimer.Reset();

                RoutineManager.PreferedRoutine = "";
                RoutineManager.PickRoutine();
            }
        }

        /// <summary>
        /// Event handler for RoutineManager.PickRoutineFired.
        /// Needs to be static, otherwise it will always fire...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void HandleRoutineSelection(object sender, EventArgs eventArgs)
        {
            // Since the plugin basically ignores it's own IsEnabled state, the required exit condition
            // needs to be checked here.
            if (!PluginManager.GetEnabledPlugins().Contains("SeleCR"))
                return;

            RoutineManager.PreferedRoutine = Settings.Instance.SelectRoutine();

            Logger.Log(Name, $"Automatically selected \"{RoutineManager.PreferedRoutine}\" as routine for {Core.Me.CurrentJob}.", LogColor);
        }

        /// <summary>
        /// Handles plugin start.
        /// </summary>
        /// <param name="bot"></param>
        private void HandleStart(BotBase bot)
        {
            RoutineManager.PickRoutineFired += HandleRoutineSelection;
        }

        /// <summary>
        /// Handles plugin stop.
        /// </summary>
        /// <param name="bot"></param>
        private void HandleStop(BotBase bot)
        {
            RoutineManager.PickRoutineFired -= HandleRoutineSelection;
        }

        /// <summary>
        /// Handles initializing/enabling the plugin and hooks the required event handlers.
        /// </summary>
        private void HandleInit()
        {
            TreeRoot.OnStart += HandleStart;
            TreeRoot.OnStop += HandleStop;
            RoutineManager.PickRoutineFired += HandleRoutineSelection;
        }

        /// <summary>
        /// Handles shutdown/disabling the plugin and releases the event handlers set by HandleInit().
        /// </summary>
        private void HandleShutdown()
        {
            TreeRoot.OnStop -= HandleStop;
            TreeRoot.OnStart -= HandleStart;
            RoutineManager.PickRoutineFired -= HandleRoutineSelection;
            RoutineManager.PreferedRoutine = "";
        }

        /// <summary>
        /// Technically this is not a clean solution. We need to hook up the plugin regardless to override routine
        /// selection. Therefore the HandleRoutineSelection method needs to evaluate whether the plugin is enabled
        /// or not...
        /// </summary>
        public override void OnInitialize()
        {
            _pulseTimer = new WaitTimer(new TimeSpan(0, 0, 0, 1));
            HandleInit();
        }

        public override void OnShutdown()
        {
            HandleShutdown();
            Logger.Log(Name, "Goodbye!");
        }

        public override void OnEnabled()
        {
            HandleInit();
            Logger.Log(Name, "Automatic combat routine selection activated.", LogColor);
        }

        public override void OnDisabled()
        {
            HandleShutdown();
            Logger.Log(Name, "Automatic combat routine selection disabled.", LogColor);
        }
    }
}