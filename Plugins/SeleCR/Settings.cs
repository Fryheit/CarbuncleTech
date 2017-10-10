namespace CarbuncleTech.Plugins.SeleCR
{
    using System.ComponentModel;
    using System.Configuration;
    using ff14bot;
    using ff14bot.Enums;
    using ff14bot.Helpers;
    using Newtonsoft.Json;
    
    public class Settings : JsonSettings
    {
        [Setting]
        [DefaultValue("")]
        public string ArcanistRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string SummonerRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string ScholarRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string BardRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string WhiteMageRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string PaladinRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string DragoonRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string RedMageRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string WarriorRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string MonkRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string NinjaRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string BlackMageRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string MachinistRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string DarkKnightRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string AstrologianRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string SamuraiRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string HandRoutine { get; set; }

        public Settings() : base(CharacterSettingsDirectory + "/CarbuncleTech/SeleCR.json")
        {

        }

        [JsonIgnore]
        private static Settings _instance;
        
        public static Settings Instance => _instance ?? (_instance = new Settings());

        public string SelectRoutine()
        {
            switch(Core.Me.CurrentJob)
            {
                case ClassJobType.Botanist:
                case ClassJobType.Fisher:
                case ClassJobType.Miner:
                    return HandRoutine;

                case ClassJobType.Alchemist:
                case ClassJobType.Armorer:
                case ClassJobType.Blacksmith:
                case ClassJobType.Carpenter:
                case ClassJobType.Culinarian:
                case ClassJobType.Goldsmith:
                case ClassJobType.Leatherworker:
                case ClassJobType.Weaver:
                    return HandRoutine;

                case ClassJobType.Arcanist:
                    return ArcanistRoutine;
                    
                case ClassJobType.Archer:
                case ClassJobType.Bard:
                    return BardRoutine;
                    
                case ClassJobType.Astrologian:
                    return AstrologianRoutine;
                    
                case ClassJobType.Thaumaturge:
                case ClassJobType.BlackMage:
                    return BlackMageRoutine;
                    
                case ClassJobType.Conjurer:
                case ClassJobType.WhiteMage:
                    return WhiteMageRoutine;
                    
                case ClassJobType.DarkKnight:
                    return DarkKnightRoutine;
                    
                case ClassJobType.Lancer:
                case ClassJobType.Dragoon:
                    return DragoonRoutine;
                
                case ClassJobType.Gladiator:
                case ClassJobType.Paladin:
                    return PaladinRoutine;
                    
                case ClassJobType.Machinist:
                    return MachinistRoutine;
                    
                case ClassJobType.Marauder:
                case ClassJobType.Warrior:
                    return WarriorRoutine;
                    
                case ClassJobType.Pugilist:
                case ClassJobType.Monk:
                    return MonkRoutine;
                    
                case ClassJobType.Rogue:
                case ClassJobType.Ninja:
                    return NinjaRoutine;
                    
                case ClassJobType.RedMage:
                    return RedMageRoutine;
                    
                case ClassJobType.Samurai:
                    return SamuraiRoutine;
                    
                default:
                    return "";
            }
        }
    }
}
