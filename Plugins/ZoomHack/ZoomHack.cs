namespace CarbuncleTech.Plugins.ZoomHack
{
    using System;
    using System.Windows.Media;
    using System.Xml.XPath;
    using Common;
    using ff14bot;
    using ff14bot.AClasses;

    public class ZoomHack : BotPlugin
    {        
        #region Plugin Metadata
        public override string Author => @"Freiheit";
        public override Version Version => new Version(0, 0, 0, 1);
        public override string Name => "Zoom Hack";
        #endregion

        #region Variables
        private bool _isInitialized;
        private int _structAddress;
        private int _zoomMax;
        #endregion

        private readonly Color LogColor = Color.FromRgb(51, 204, 255);

        private const string ZoomHackOffsetUrl =
            @"https://github.com/jayotterbein/FFXIV-Zoom-Hack/raw/master/Offsets.xml";

        #region Overrides
        public override void OnInitialize()
        {
            _isInitialized = LoadOffsetsFromWeb();
        }

        public override void OnEnabled()
        {
            SetMaxZoom(200f);
        }

        public override void OnDisabled()
        {
            SetMaxZoom();
        }
        #endregion
        
        /// <summary>
        /// Downloads offsets for the Zoom Hack from GitHub.
        /// </summary>
        /// <returns>Did the offsets download properly?</returns>
        private bool LoadOffsetsFromWeb()
        {
            try
            {
                var xPathDocument = new XPathDocument(ZoomHackOffsetUrl);
                var xPathNavigator = xPathDocument.CreateNavigator();

                var structAddressStr = xPathNavigator.SelectSingleNode(@"/Root/DX11/StructureAddress")?.Value;

#if RB_CN
                structAddressStr = "1BF9B20";
#endif
                var zoomMaxStr = xPathNavigator.SelectSingleNode(@"/Root/DX11/ZoomMax")?.Value;

                _structAddress = Convert.ToInt32(structAddressStr, 16);
                if (_structAddress > 0)
                    Logger.Log(Name, $@"Determined 0x{_structAddress:X} to be the StructAddress", LogColor);

                _zoomMax = Convert.ToInt32(zoomMaxStr, 16);
                if (_zoomMax > 0)
                    Logger.Log(Name, $@"Determined 0x{_zoomMax:X} to be the ZoomMax", LogColor);
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        private void SetMaxZoom(float maxZoom = 20f)
        {
            if (!_isInitialized)
            {
                Logger.Log(Name, @"Plugin did not initialize properly. Aborting.", LogColor);
                return;
            }
            
            if(_structAddress > 0 && _zoomMax > 0)
                Core.Memory.Write(Core.Memory.Read<IntPtr>(Core.Memory.Process.MainModule.BaseAddress + _structAddress) + _zoomMax, maxZoom);
            else
                Logger.Log(Name, $@"No offsets available, {Name} will not work.", LogColor);
        }
    }
}