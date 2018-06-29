namespace CarbuncleTech.Plugins.SeleCR
{
    using System.ComponentModel;
    using System.Configuration;
    using Models;
    using ff14bot;
    using ff14bot.Enums;
    using ff14bot.Helpers;
    using ff14bot.Managers;
    using Newtonsoft.Json;

    public class Settings : JsonSettings
    {
        private Scenario _pve = new Scenario();
        public Scenario Pve
        {
            get => _pve;
            set { _pve = value; }
        }

        private Scenario _pvp = new Scenario();
        public Scenario Pvp
        {
            get => _pvp;
            set { _pvp = value; }
        }

        [Setting]
        [DefaultValue("")]
        public string HandRoutine { get; set; }

        [Setting]
        [DefaultValue(true)]
        public bool AutoSelectPve { get; set; }

        [Setting]
        [DefaultValue(false)]
        public bool AutoSelectPvp { get; set; }

        public Settings() : base(CharacterSettingsDirectory + "/CarbuncleTech/SeleCR.json")
        { }

        [JsonIgnore]
        private static Settings _instance;

        public static Settings Instance => _instance ?? (_instance = new Settings());

        public string SelectRoutine()
        {
            switch (Core.Me.CurrentJob)
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
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.ArcanistRoutine;

                        if (AutoSelectPve)
                            return Pve.ArcanistRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.ArcanistRoutine;

                        if (AutoSelectPvp)
                            return Pvp.ArcanistRoutine;
                    }
                    break;

                case ClassJobType.Archer:
                case ClassJobType.Bard:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.BardRoutine;

                        if (AutoSelectPve)
                            return Pve.BardRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.BardRoutine;

                        if (AutoSelectPvp)
                            return Pvp.BardRoutine;
                    }
                    break;

                case ClassJobType.Astrologian:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.AstrologianRoutine;

                        if (AutoSelectPve)
                            return Pve.AstrologianRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.AstrologianRoutine;

                        if (AutoSelectPvp)
                            return Pvp.AstrologianRoutine;
                    }
                    break;

                case ClassJobType.Thaumaturge:
                case ClassJobType.BlackMage:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.BlackMageRoutine;

                        if (AutoSelectPve)
                            return Pve.BlackMageRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.BlackMageRoutine;

                        if (AutoSelectPvp)
                            return Pvp.BlackMageRoutine;
                    }
                    break;

                case ClassJobType.Conjurer:
                case ClassJobType.WhiteMage:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.WhiteMageRoutine;

                        if (AutoSelectPve)
                            return Pve.WhiteMageRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.WhiteMageRoutine;

                        if (AutoSelectPvp)
                            return Pvp.WhiteMageRoutine;
                    }
                    break;

                case ClassJobType.DarkKnight:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.DarkKnightRoutine;

                        if (AutoSelectPve)
                            return Pve.DarkKnightRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.DarkKnightRoutine;

                        if (AutoSelectPvp)
                            return Pvp.DarkKnightRoutine;
                    }
                    break;

                case ClassJobType.Lancer:
                case ClassJobType.Dragoon:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.DragoonRoutine;

                        if (AutoSelectPve)
                            return Pve.DragoonRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.DragoonRoutine;

                        if (AutoSelectPvp)
                            return Pvp.DragoonRoutine;
                    }
                    break;

                case ClassJobType.Gladiator:
                case ClassJobType.Paladin:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.PaladinRoutine;

                        if (AutoSelectPve)
                            return Pve.PaladinRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.PaladinRoutine;

                        if (AutoSelectPvp)
                            return Pvp.PaladinRoutine;
                    }
                    break;

                case ClassJobType.Machinist:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.MachinistRoutine;

                        if (AutoSelectPve)
                            return Pve.MachinistRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.MachinistRoutine;

                        if (AutoSelectPvp)
                            return Pvp.MachinistRoutine;
                    }
                    break;

                case ClassJobType.Marauder:
                case ClassJobType.Warrior:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.WarriorRoutine;

                        if (AutoSelectPve)
                            return Pve.WarriorRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.WarriorRoutine;

                        if (AutoSelectPvp)
                            return Pvp.WarriorRoutine;
                    }
                    break;

                case ClassJobType.Pugilist:
                case ClassJobType.Monk:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.MonkRoutine;

                        if (AutoSelectPve)
                            return Pve.MonkRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.MonkRoutine;

                        if (AutoSelectPvp)
                            return Pvp.MonkRoutine;
                    }
                    break;

                case ClassJobType.Rogue:
                case ClassJobType.Ninja:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.NinjaRoutine;

                        if (AutoSelectPve)
                            return Pve.NinjaRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.NinjaRoutine;

                        if (AutoSelectPvp)
                            return Pvp.NinjaRoutine;
                    }
                    break;

                case ClassJobType.RedMage:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.RedMageRoutine;

                        if (AutoSelectPve)
                            return Pve.RedMageRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.RedMageRoutine;

                        if (AutoSelectPvp)
                            return Pvp.RedMageRoutine;
                    }
                    break;

                case ClassJobType.Samurai:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.SamuraiRoutine;

                        if (AutoSelectPve)
                            return Pve.SamuraiRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.SamuraiRoutine;

                        if (AutoSelectPvp)
                            return Pvp.SamuraiRoutine;
                    }
                    break;

                case ClassJobType.Scholar:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.ScholarRoutine;

                        if (AutoSelectPve)
                            return Pve.ScholarRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.ScholarRoutine;

                        if (AutoSelectPvp)
                            return Pvp.ScholarRoutine;
                    }
                    break;

                case ClassJobType.Summoner:
                    if (WorldManager.InPvP)
                    {
                        if (AutoSelectPvp)
                            return Pvp.SummonerRoutine;

                        if (AutoSelectPve)
                            return Pve.SummonerRoutine;
                    }
                    else
                    {
                        if (AutoSelectPve)
                            return Pve.SummonerRoutine;

                        if (AutoSelectPvp)
                            return Pvp.SummonerRoutine;
                    }
                    break;

                default:
                    return "";
            }

            // As a fallback simply use the current routine.
            return RoutineManager.Current.Name;
        }
    }
}
