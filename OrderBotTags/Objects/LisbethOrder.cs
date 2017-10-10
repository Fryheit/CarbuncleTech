namespace CarbuncleTech.OrderBotTags.Objects
{
    using Clio.XmlEngine;
    using Newtonsoft.Json;
    
    /// <summary>
    /// A single order within the Lisbeth crafting botbase.
    /// </summary>
    [XmlElement("LisbethOrder")]
    public class LisbethOrder
    {
        [XmlAttribute("Item"), JsonProperty("Item")]
        public uint Item { get; set; }

        [XmlAttribute("Group"), JsonProperty("Group")]
        public uint Group { get; set; }

        [XmlAttribute("Amount"), JsonProperty("Amount")]
        public uint Amount { get; set; }

        [XmlAttribute("Collectable"), JsonProperty("Collectable")]
        public bool Collectable { get; set; }

        [XmlAttribute("QuickSynth"), JsonProperty("QuickSynth")]
        public bool QuickSynth { get; set; }

        [XmlAttribute("SuborderQuickSynth"), JsonProperty("SuborderQuickSynth")]
        public bool SuborderQuickSynth { get; set; }

        [XmlAttribute("Hq"), JsonProperty("Hq")]
        public bool Hq { get; set; }

        [XmlAttribute("Food"), JsonProperty("Food")]
        public uint Food { get; set; }

        [XmlAttribute("Primary"), JsonProperty("Primary")]
        public bool Primary { get; set; }

        [XmlAttribute("Type"), JsonProperty("Type")]
        public string Job { get; set; }

        [XmlAttribute("Enabled"), JsonProperty("Enabled")]
        public bool Enabled { get; set; }

        [XmlAttribute("Manual"), JsonProperty("Manual")]
        public uint Manual { get; set; }

        [XmlAttribute("Medicine"), JsonProperty("Medicine")]
        public uint Medicine { get; set; }

        public LisbethOrder()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes the values of the class with some sane defaults.
        /// Because carbuncles don't use DefaultValue!
        /// </summary>
        private void Initialize()
        {
            Item = 0;
            Group = 0;
            Amount = 1;
            Collectable = false;
            QuickSynth = false;
            SuborderQuickSynth = false;
            Hq = false;
            Food = 0;
            Primary = true;
            Job = "";
            Enabled = true;
            Manual = 0;
            Medicine = 0;
        }
    }
}