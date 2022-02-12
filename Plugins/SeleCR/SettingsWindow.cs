using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ff14bot.Managers;

namespace CarbuncleTech.Plugins.SeleCR
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();

            picArcanistPVE.ImageLocation = GetImageLocation("Arcanist.png");
            picArcanistPVP.ImageLocation = GetImageLocation("Arcanist.png");
            picAstrologianPVE.ImageLocation = GetImageLocation("Astrologian.png");
            picAstrologianPVP.ImageLocation = GetImageLocation("Astrologian.png");
            picBardPVE.ImageLocation = GetImageLocation("Bard.png");
            picBardPVP.ImageLocation = GetImageLocation("Bard.png");
            picBlackMagePVE.ImageLocation = GetImageLocation("BlackMage.png");
            picBlackMagePVP.ImageLocation = GetImageLocation("BlackMage.png");
            picDancerPVE.ImageLocation = GetImageLocation("Dancer.png");
            picDancerPVP.ImageLocation = GetImageLocation("Dancer.png");
            picDarkKnightPVE.ImageLocation = GetImageLocation("DarkKnight.png");
            picDarkKnightPVP.ImageLocation = GetImageLocation("DarkKnight.png");
            picDragoonPVE.ImageLocation = GetImageLocation("Dragoon.png");
            picDragoonPVP.ImageLocation = GetImageLocation("Dragoon.png");
            picGunbreakerPVE.ImageLocation = GetImageLocation("Gunbreaker.png");
            picGunbreakerPVP.ImageLocation = GetImageLocation("Gunbreaker.png");
            picMachinistPVE.ImageLocation = GetImageLocation("Machinist.png");
            picMachinistPVP.ImageLocation = GetImageLocation("Machinist.png");
            picMonkPVE.ImageLocation = GetImageLocation("Monk.png");
            picMonkPVP.ImageLocation = GetImageLocation("Monk.png");
            picNinjaPVE.ImageLocation = GetImageLocation("Ninja.png");
            picNinjaPVP.ImageLocation = GetImageLocation("Ninja.png");
            picPaladinPVE.ImageLocation = GetImageLocation("Paladin.png");
            picPaladinPVP.ImageLocation = GetImageLocation("Paladin.png");
            picRedMagePVE.ImageLocation = GetImageLocation("RedMage.png");
            picRedMagePVP.ImageLocation = GetImageLocation("RedMage.png");
            picSamuraiPVE.ImageLocation = GetImageLocation("Samurai.png");
            picSamuraiPVP.ImageLocation = GetImageLocation("Samurai.png");
            picScholarPVE.ImageLocation = GetImageLocation("Scholar.png");
            picScholarPVP.ImageLocation = GetImageLocation("Scholar.png");
            picSummonerPVE.ImageLocation = GetImageLocation("Summoner.png");
            picSummonerPVP.ImageLocation = GetImageLocation("Summoner.png");
            picWarriorPVE.ImageLocation = GetImageLocation("Warrior.png");
            picWarriorPVP.ImageLocation = GetImageLocation("Warrior.png");
            picWhiteMagePVE.ImageLocation = GetImageLocation("WhiteMage.png");
            picWhiteMagePVP.ImageLocation = GetImageLocation("WhiteMage.png");
            picMinerPVE.ImageLocation = GetImageLocation("Miner.png");
            picBlueMagePVE.ImageLocation = GetImageLocation("BlueMage.png");
            picReaperPVE.ImageLocation = GetImageLocation("Reaper.png");
            picReaperPVP.ImageLocation = GetImageLocation("Reaper.png");
            picSagePVE.ImageLocation = GetImageLocation("Sage.png");
            picSagePVP.ImageLocation = GetImageLocation("Sage.png");
            

            string[] routines = PopulateRoutines();
            cmbArcanistPVE.Items.AddRange(routines);
            cmbArcanistPVP.Items.AddRange(routines);
            cmbAstrologianPVE.Items.AddRange(routines);
            cmbAstrologianPVP.Items.AddRange(routines);
            cmbBardPVE.Items.AddRange(routines);
            cmbBardPVP.Items.AddRange(routines);
            cmbBlackMagePVE.Items.AddRange(routines);
            cmbBlackMagePVP.Items.AddRange(routines);
            cmbDancerPVE.Items.AddRange(routines);
            cmbDancerPVP.Items.AddRange(routines);
            cmbDarkKnightPVE.Items.AddRange(routines);
            cmbDarkKnightPVP.Items.AddRange(routines);
            cmbDragoonPVE.Items.AddRange(routines);
            cmbDragoonPVP.Items.AddRange(routines);
            cmbGunbreakerPVE.Items.AddRange(routines);
            cmbGunbreakerPVP.Items.AddRange(routines);
            cmbMachinistPVE.Items.AddRange(routines);
            cmbMachinistPVP.Items.AddRange(routines);
            cmbMonkPVE.Items.AddRange(routines);
            cmbMonkPVP.Items.AddRange(routines);
            cmbNinjaPVE.Items.AddRange(routines);
            cmbNinjaPVP.Items.AddRange(routines);
            cmbPaladinPVE.Items.AddRange(routines);
            cmbPaladinPVP.Items.AddRange(routines);
            cmbRedMagePVE.Items.AddRange(routines);
            cmbRedMagePVP.Items.AddRange(routines);
            cmbSamuraiPVE.Items.AddRange(routines);
            cmbSamuraiPVP.Items.AddRange(routines);
            cmbScholarPVE.Items.AddRange(routines);
            cmbScholarPVP.Items.AddRange(routines);
            cmbSummonerPVE.Items.AddRange(routines);
            cmbSummonerPVP.Items.AddRange(routines);
            cmbWarriorPVE.Items.AddRange(routines);
            cmbWarriorPVP.Items.AddRange(routines);
            cmbWhiteMagePVE.Items.AddRange(routines);
            cmbWhiteMagePVP.Items.AddRange(routines);
            cmbNonBattlePVE.Items.AddRange(routines);
            cmbBlueMagePVE.Items.AddRange(routines);
            cmbSagePVE.Items.AddRange(routines);
            cmbSagePVP.Items.AddRange(routines);
            cmbReaperPVE.Items.AddRange(routines);
            cmbReaperPVP.Items.AddRange(routines);
        }

        private string GetImageLocation(string fileName)
        {
            return Path.Combine(Environment.CurrentDirectory, $@"Plugins\CarbuncleTech\Data\Images\{fileName}");
        }

        private string[] PopulateRoutines()
        {
            HashSet<string> routines = new HashSet<string>();

            foreach (var routine in RoutineManager.AllRoutines)
            {
                string routineDirectory = routine.Name.Split(' ')[0];
                routines.Add(routineDirectory);
            }

            routines.Add(string.Empty);

            return routines.ToArray();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
        	/* Scenario PVE */
            cmbArcanistPVE.Text    = Settings.Instance.Pve.ArcanistRoutine;
            cmbAstrologianPVE.Text = Settings.Instance.Pve.AstrologianRoutine;
            cmbBardPVE.Text        = Settings.Instance.Pve.BardRoutine;
            cmbBlackMagePVE.Text   = Settings.Instance.Pve.BlackMageRoutine;
            cmbDancerPVE.Text      = Settings.Instance.Pve.DancerRoutine;
            cmbDarkKnightPVE.Text  = Settings.Instance.Pve.DarkKnightRoutine;
            cmbDragoonPVE.Text     = Settings.Instance.Pve.DragoonRoutine;
            cmbGunbreakerPVE.Text  = Settings.Instance.Pve.GunbreakerRoutine;
            cmbMachinistPVE.Text   = Settings.Instance.Pve.MachinistRoutine;
            cmbMonkPVE.Text        = Settings.Instance.Pve.MonkRoutine;
            cmbNinjaPVE.Text       = Settings.Instance.Pve.NinjaRoutine;
            cmbPaladinPVE.Text     = Settings.Instance.Pve.PaladinRoutine;
            cmbRedMagePVE.Text     = Settings.Instance.Pve.RedMageRoutine;
            cmbSamuraiPVE.Text     = Settings.Instance.Pve.SamuraiRoutine;
            cmbScholarPVE.Text     = Settings.Instance.Pve.ScholarRoutine;
            cmbSummonerPVE.Text    = Settings.Instance.Pve.SummonerRoutine;
            cmbWhiteMagePVE.Text   = Settings.Instance.Pve.WhiteMageRoutine;
            cmbWarriorPVE.Text     = Settings.Instance.Pve.WarriorRoutine;
            cmbNonBattlePVE.Text   = Settings.Instance.HandRoutine;
            cmbBlueMagePVE.Text    = Settings.Instance.Pve.BlueMageRoutine;
            cmbSagePVE.Text = Settings.Instance.Pve.SageRoutine;
            cmbReaperPVE.Text = Settings.Instance.Pve.ReaperRoutine;
            
            chkEnableInPve.Checked = Settings.Instance.AutoSelectPve;

        	/* Scenario PVP */
            cmbArcanistPVP.Text    = Settings.Instance.Pvp.ArcanistRoutine;
            cmbAstrologianPVP.Text = Settings.Instance.Pvp.AstrologianRoutine;
            cmbBardPVP.Text        = Settings.Instance.Pvp.BardRoutine;
            cmbBlackMagePVP.Text   = Settings.Instance.Pvp.BlackMageRoutine;
            cmbDancerPVP.Text      = Settings.Instance.Pvp.DancerRoutine;
            cmbDarkKnightPVP.Text  = Settings.Instance.Pvp.DarkKnightRoutine;
            cmbDragoonPVP.Text     = Settings.Instance.Pvp.DragoonRoutine;
            cmbGunbreakerPVP.Text  = Settings.Instance.Pvp.GunbreakerRoutine;
            cmbMachinistPVP.Text   = Settings.Instance.Pvp.MachinistRoutine;
            cmbMonkPVP.Text        = Settings.Instance.Pvp.MonkRoutine;
            cmbNinjaPVP.Text       = Settings.Instance.Pvp.NinjaRoutine;
            cmbPaladinPVP.Text     = Settings.Instance.Pvp.PaladinRoutine;
            cmbRedMagePVP.Text     = Settings.Instance.Pvp.RedMageRoutine;
            cmbSamuraiPVP.Text     = Settings.Instance.Pvp.SamuraiRoutine;
            cmbScholarPVP.Text     = Settings.Instance.Pvp.ScholarRoutine;
            cmbSummonerPVP.Text    = Settings.Instance.Pvp.SummonerRoutine;
            cmbWhiteMagePVP.Text   = Settings.Instance.Pvp.WhiteMageRoutine;
            cmbWarriorPVP.Text     = Settings.Instance.Pvp.WarriorRoutine;
            chkEnableInPvp.Checked = Settings.Instance.AutoSelectPvp;
            cmbReaperPVP.Text = Settings.Instance.Pvp.ReaperRoutine;
            cmbSagePVP.Text = Settings.Instance.Pvp.SageRoutine;
        }

        private void SettingsChanged(object sender, EventArgs e)
        {
			// Arcanist
            if(sender == cmbArcanistPVE)
                Settings.Instance.Pve.ArcanistRoutine = cmbArcanistPVE.Text;

            if(sender == cmbArcanistPVP)
                Settings.Instance.Pvp.ArcanistRoutine = cmbArcanistPVP.Text;

            // Astrologian
            if(sender == cmbAstrologianPVE)
                Settings.Instance.Pve.AstrologianRoutine = cmbAstrologianPVE.Text;

            if(sender == cmbAstrologianPVP)
                Settings.Instance.Pvp.AstrologianRoutine = cmbAstrologianPVP.Text;

            // Bard
            if(sender == cmbBardPVE)
                Settings.Instance.Pve.BardRoutine = cmbBardPVE.Text;

            if(sender == cmbBardPVP)
            	Settings.Instance.Pvp.BardRoutine = cmbBardPVP.Text;

            // Black Mage
            if(sender == cmbBlackMagePVE)
                Settings.Instance.Pve.BlackMageRoutine = cmbBlackMagePVE.Text;

            if(sender == cmbBlackMagePVP)
                Settings.Instance.Pvp.BlackMageRoutine = cmbBlackMagePVP.Text;

            // Dancer
            if(sender == cmbDancerPVE)
                Settings.Instance.Pve.DancerRoutine = cmbDancerPVE.Text;

            if(sender == cmbDancerPVP)
                Settings.Instance.Pvp.DancerRoutine = cmbDancerPVP.Text;

            // Dark Knight
            if(sender == cmbDarkKnightPVE)
                Settings.Instance.Pve.DarkKnightRoutine = cmbDarkKnightPVE.Text;

            if(sender == cmbDarkKnightPVP)
                Settings.Instance.Pvp.DarkKnightRoutine = cmbDarkKnightPVP.Text;

            // Dragoon
            if(sender == cmbDragoonPVE)
                Settings.Instance.Pve.DragoonRoutine = cmbDragoonPVE.Text;

            if(sender == cmbDragoonPVP)
                Settings.Instance.Pvp.DragoonRoutine = cmbDragoonPVP.Text;

            // Gunbreaker
            if(sender == cmbGunbreakerPVE)
                Settings.Instance.Pve.GunbreakerRoutine = cmbGunbreakerPVE.Text;

            if(sender == cmbGunbreakerPVP)
                Settings.Instance.Pvp.GunbreakerRoutine = cmbGunbreakerPVP.Text;

            // Machinist
            if(sender == cmbMachinistPVE)
                Settings.Instance.Pve.MachinistRoutine = cmbMachinistPVE.Text;

            if(sender == cmbMachinistPVP)
                Settings.Instance.Pvp.MachinistRoutine = cmbMachinistPVP.Text;

            // Monk
            if(sender == cmbMonkPVE)
                Settings.Instance.Pve.MonkRoutine = cmbMonkPVE.Text;

            if(sender == cmbMonkPVP)
                Settings.Instance.Pvp.MonkRoutine = cmbMonkPVP.Text;

            // Ninja
            if(sender == cmbNinjaPVE)
                Settings.Instance.Pve.NinjaRoutine = cmbNinjaPVE.Text;

            if(sender == cmbNinjaPVP)
                Settings.Instance.Pvp.NinjaRoutine = cmbNinjaPVP.Text;

            // Paladin
            if(sender == cmbPaladinPVE)
                Settings.Instance.Pve.PaladinRoutine = cmbPaladinPVE.Text;

            if(sender == cmbPaladinPVP)
                Settings.Instance.Pvp.PaladinRoutine = cmbPaladinPVP.Text;

            // Red Mage
            if(sender == cmbRedMagePVE)
                Settings.Instance.Pve.RedMageRoutine = cmbRedMagePVE.Text;

            if(sender == cmbRedMagePVP)
                Settings.Instance.Pvp.RedMageRoutine = cmbRedMagePVP.Text;

            // Samurai
            if(sender == cmbSamuraiPVE)
                Settings.Instance.Pve.SamuraiRoutine = cmbSamuraiPVE.Text;

            if(sender == cmbSamuraiPVP)
                Settings.Instance.Pvp.SamuraiRoutine = cmbSamuraiPVP.Text;

            // Scholar
            if(sender == cmbScholarPVE)
                Settings.Instance.Pve.ScholarRoutine = cmbScholarPVE.Text;

            if(sender == cmbScholarPVP)
                Settings.Instance.Pvp.ScholarRoutine = cmbScholarPVP.Text;

            // Summoner
            if(sender == cmbSummonerPVE)
                Settings.Instance.Pve.SummonerRoutine = cmbSummonerPVE.Text;

            if(sender == cmbSummonerPVP)
                Settings.Instance.Pvp.SummonerRoutine = cmbSummonerPVP.Text;

            // Warrior
            if(sender == cmbWarriorPVE)
                Settings.Instance.Pve.WarriorRoutine = cmbWarriorPVE.Text;

            if(sender == cmbWarriorPVP)
                Settings.Instance.Pvp.WarriorRoutine = cmbWarriorPVP.Text;

            // White Mage
            if(sender == cmbWhiteMagePVE)
                Settings.Instance.Pve.WhiteMageRoutine = cmbWhiteMagePVE.Text;

            if(sender == cmbWhiteMagePVP)
                Settings.Instance.Pvp.WhiteMageRoutine = cmbWhiteMagePVP.Text;
            
            // Sage
            if(sender == cmbSagePVE)
                Settings.Instance.Pve.SageRoutine = cmbSagePVE.Text;

            if(sender == cmbSagePVP)
                Settings.Instance.Pvp.SageRoutine = cmbSagePVP.Text;
            
            // Reaper
            if(sender == cmbReaperPVE)
                Settings.Instance.Pve.ReaperRoutine = cmbReaperPVE.Text;

            if(sender == cmbReaperPVP)
                Settings.Instance.Pvp.ReaperRoutine = cmbReaperPVP.Text;

            // Non battle
            if(sender == cmbNonBattlePVE)
                Settings.Instance.HandRoutine = cmbNonBattlePVE.Text;

            // Blue Mage
            if (sender == cmbBlueMagePVE)
                Settings.Instance.Pve.BlueMageRoutine = cmbBlueMagePVE.Text;

            if(sender == chkEnableInPve)
            	Settings.Instance.AutoSelectPve = chkEnableInPve.Checked;

            if(sender == chkEnableInPvp)
            	Settings.Instance.AutoSelectPvp = chkEnableInPvp.Checked;

            Settings.Instance.Save();
        }
    }
}
