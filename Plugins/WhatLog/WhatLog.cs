namespace CarbuncleTech.Plugins.WhatLog
{
    using System;
    using System.Diagnostics;
    using ff14bot.AClasses;

    public class WhatLog : BotPlugin
    {
#if RB_CN
        public override string Name => "啥，日志？";
        public override string ButtonText => "选择日志文件";
#else
        public override string Name => "What Log?";
        public override string ButtonText => "Select Log";
#endif

        public override string Author => @"Freiheit";
        public override Version Version => new Version(0, 0, 0, 1);
        public override bool WantButton => true;

        public override void OnButtonPress()
        {
            Process.Start("explorer.exe", $@"/select,""{ff14bot.Helpers.Logging.LogFilePath}""");
        }
    }
}