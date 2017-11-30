namespace CarbuncleTech.Plugins.WhatLog
{
    using System;
    using System.Diagnostics;
    using ff14bot.AClasses;

    public class WhatLog : BotPlugin
    {
        public override string Author => @"Freiheit";
        public override Version Version => new Version(0, 0, 0, 1);
        public override string Name => "What Log?";
        public override string ButtonText => "Select Log";
        public override bool WantButton => true;

        public override void OnButtonPress()
        {
            Process.Start("explorer.exe", $@"/select,""{ff14bot.Helpers.Logging.LogFilePath}""");
        }
    }
}