namespace CarbuncleTech.Plugins.SeleCR.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public enum JobRole
    {
        Tank,
        Healer,
        MeleeDps,
        PhysicalRangedDps,
        MagicalRangedDps,
        Limited
    }

    public class JobDefinition
    {
        public string DisplayName { get; }
        public string IconFileName { get; }
        public JobRole Role { get; }
        public bool HasPvp { get; }
        public Func<Scenario, string> Getter { get; }
        public Action<Scenario, string> Setter { get; }

        public JobDefinition(string displayName, string iconFileName, JobRole role,
            Func<Scenario, string> getter, Action<Scenario, string> setter, bool hasPvp = true)
        {
            DisplayName = displayName;
            IconFileName = iconFileName;
            Role = role;
            Getter = getter;
            Setter = setter;
            HasPvp = hasPvp;
        }

        public static string IconPath(string fileName) =>
            Path.Combine(Environment.CurrentDirectory, "Plugins", "CarbuncleTech", "Data", "Images", fileName);

        public static readonly IReadOnlyList<JobDefinition> All = new List<JobDefinition>
        {
            // Tanks
            new("Paladin", "Paladin.png", JobRole.Tank, s => s.PaladinRoutine, (s, v) => s.PaladinRoutine = v),
            new("Warrior", "Warrior.png", JobRole.Tank, s => s.WarriorRoutine, (s, v) => s.WarriorRoutine = v),
            new("Dark Knight", "DarkKnight.png", JobRole.Tank, s => s.DarkKnightRoutine, (s, v) => s.DarkKnightRoutine = v),
            new("Gunbreaker", "Gunbreaker.png", JobRole.Tank, s => s.GunbreakerRoutine, (s, v) => s.GunbreakerRoutine = v),

            // Healers
            new("White Mage", "WhiteMage.png", JobRole.Healer, s => s.WhiteMageRoutine, (s, v) => s.WhiteMageRoutine = v),
            new("Scholar", "Scholar.png", JobRole.Healer, s => s.ScholarRoutine, (s, v) => s.ScholarRoutine = v),
            new("Astrologian", "Astrologian.png", JobRole.Healer, s => s.AstrologianRoutine, (s, v) => s.AstrologianRoutine = v),
            new("Sage", "Sage.png", JobRole.Healer, s => s.SageRoutine, (s, v) => s.SageRoutine = v),

            // Melee DPS
            new("Monk", "Monk.png", JobRole.MeleeDps, s => s.MonkRoutine, (s, v) => s.MonkRoutine = v),
            new("Dragoon", "Dragoon.png", JobRole.MeleeDps, s => s.DragoonRoutine, (s, v) => s.DragoonRoutine = v),
            new("Ninja", "Ninja.png", JobRole.MeleeDps, s => s.NinjaRoutine, (s, v) => s.NinjaRoutine = v),
            new("Samurai", "Samurai.png", JobRole.MeleeDps, s => s.SamuraiRoutine, (s, v) => s.SamuraiRoutine = v),
            new("Reaper", "Reaper.png", JobRole.MeleeDps, s => s.ReaperRoutine, (s, v) => s.ReaperRoutine = v),
            new("Viper", "Viper.png", JobRole.MeleeDps, s => s.ViperRoutine, (s, v) => s.ViperRoutine = v),

            // Physical Ranged DPS
            new("Bard", "Bard.png", JobRole.PhysicalRangedDps, s => s.BardRoutine, (s, v) => s.BardRoutine = v),
            new("Machinist", "Machinist.png", JobRole.PhysicalRangedDps, s => s.MachinistRoutine, (s, v) => s.MachinistRoutine = v),
            new("Dancer", "Dancer.png", JobRole.PhysicalRangedDps, s => s.DancerRoutine, (s, v) => s.DancerRoutine = v),

            // Magical Ranged DPS
            new("Arcanist", "Arcanist.png", JobRole.MagicalRangedDps, s => s.ArcanistRoutine, (s, v) => s.ArcanistRoutine = v),
            new("Summoner", "Summoner.png", JobRole.MagicalRangedDps, s => s.SummonerRoutine, (s, v) => s.SummonerRoutine = v),
            new("Black Mage", "BlackMage.png", JobRole.MagicalRangedDps, s => s.BlackMageRoutine, (s, v) => s.BlackMageRoutine = v),
            new("Red Mage", "RedMage.png", JobRole.MagicalRangedDps, s => s.RedMageRoutine, (s, v) => s.RedMageRoutine = v),
            new("Pictomancer", "Pictomancer.png", JobRole.MagicalRangedDps, s => s.PictomancerRoutine, (s, v) => s.PictomancerRoutine = v),

            // Limited Jobs (no PvP queue)
            new("Blue Mage", "BlueMage.png", JobRole.Limited, s => s.BlueMageRoutine, (s, v) => s.BlueMageRoutine = v, hasPvp: false),
#if !RB_TC
            new("Beastmaster", "Beastmaster.png", JobRole.Limited, s => s.BeastmasterRoutine, (s, v) => s.BeastmasterRoutine = v, hasPvp: false),
#endif
        };
    }
}
