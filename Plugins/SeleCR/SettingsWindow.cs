using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ff14bot.Enums;
using ff14bot.Managers;

namespace CarbuncleTech.Plugins.SeleCR
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();

            picArcanist.ImageLocation = GetImageLocation("Arcanist.png");
            picAstrologian.ImageLocation = GetImageLocation("Astrologian.png");
            picBard.ImageLocation = GetImageLocation("Bard.png");
            picBlackMage.ImageLocation = GetImageLocation("BlackMage.png");
            picDarkKnight.ImageLocation = GetImageLocation("DarkKnight.png");
            picDragoon.ImageLocation = GetImageLocation("Dragoon.png");
            picMachinist.ImageLocation = GetImageLocation("Machinist.png");
            picMonk.ImageLocation = GetImageLocation("Monk.png");
            picNinja.ImageLocation = GetImageLocation("Ninja.png");
            picPaladin.ImageLocation = GetImageLocation("Paladin.png");
            picRedMage.ImageLocation = GetImageLocation("RedMage.png");
            picSamurai.ImageLocation = GetImageLocation("Samurai.png");
            picScholar.ImageLocation = GetImageLocation("Scholar.png");
            picSummoner.ImageLocation = GetImageLocation("Summoner.png");
            picWarrior.ImageLocation = GetImageLocation("Warrior.png");
            picWhiteMage.ImageLocation = GetImageLocation("WhiteMage.png");
            picMiner.ImageLocation = GetImageLocation("Miner.png");

            string[] routines = PopulateRoutines();
            cmbArcanist.Items.AddRange(routines);
            cmbAstrologian.Items.AddRange(routines);
            cmbBard.Items.AddRange(routines);
            cmbBlackMage.Items.AddRange(routines);
            cmbDarkKnight.Items.AddRange(routines);
            cmbDragoon.Items.AddRange(routines);
            cmbMachinist.Items.AddRange(routines);
            cmbMonk.Items.AddRange(routines);
            cmbNinja.Items.AddRange(routines);
            cmbPaladin.Items.AddRange(routines);
            cmbRedMage.Items.AddRange(routines);
            cmbSamurai.Items.AddRange(routines);
            cmbScholar.Items.AddRange(routines);
            cmbSummoner.Items.AddRange(routines);
            cmbWarrior.Items.AddRange(routines);
            cmbWhiteMage.Items.AddRange(routines);
            cmbNonBattle.Items.AddRange(routines);
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
            cmbArcanist.Text    = Settings.Instance.ArcanistRoutine;
            cmbAstrologian.Text = Settings.Instance.AstrologianRoutine;
            cmbBard.Text        = Settings.Instance.BardRoutine;
            cmbBlackMage.Text   = Settings.Instance.BlackMageRoutine;
            cmbDarkKnight.Text  = Settings.Instance.DarkKnightRoutine;
            cmbDragoon.Text     = Settings.Instance.DragoonRoutine;
            cmbMachinist.Text   = Settings.Instance.MachinistRoutine;
            cmbMonk.Text        = Settings.Instance.MonkRoutine;
            cmbNinja.Text       = Settings.Instance.NinjaRoutine;
            cmbPaladin.Text     = Settings.Instance.PaladinRoutine;
            cmbRedMage.Text     = Settings.Instance.RedMageRoutine;
            cmbSamurai.Text     = Settings.Instance.SamuraiRoutine;
            cmbScholar.Text     = Settings.Instance.ScholarRoutine;
            cmbSummoner.Text    = Settings.Instance.SummonerRoutine;
            cmbWhiteMage.Text   = Settings.Instance.WhiteMageRoutine;
            cmbWarrior.Text     = Settings.Instance.WarriorRoutine;
            cmbNonBattle.Text   = Settings.Instance.HandRoutine;
        }

        private void SettingsChanged(object sender, EventArgs e)
        {
            // TODO: Yeah, I know...

            if(sender == cmbArcanist)
                Settings.Instance.ArcanistRoutine = cmbArcanist.Text;

            if(sender == cmbAstrologian)
                Settings.Instance.AstrologianRoutine = cmbAstrologian.Text;

            if(sender == cmbBard)
                Settings.Instance.BardRoutine = cmbBard.Text;

            if(sender == cmbBlackMage)
                Settings.Instance.BlackMageRoutine = cmbBlackMage.Text;

            if(sender == cmbDarkKnight)
                Settings.Instance.DarkKnightRoutine = cmbDarkKnight.Text;

            if(sender == cmbDragoon)
                Settings.Instance.DragoonRoutine = cmbDragoon.Text;

            if(sender == cmbMachinist)
                Settings.Instance.MachinistRoutine = cmbMachinist.Text;

            if(sender == cmbMonk)
                Settings.Instance.MonkRoutine = cmbMonk.Text;

            if(sender == cmbNinja)
                Settings.Instance.NinjaRoutine = cmbNinja.Text;

            if(sender == cmbPaladin)
                Settings.Instance.PaladinRoutine = cmbPaladin.Text;

            if(sender == cmbRedMage)
                Settings.Instance.RedMageRoutine = cmbRedMage.Text;

            if(sender == cmbSamurai)
                Settings.Instance.SamuraiRoutine = cmbSamurai.Text;

            if(sender == cmbScholar)
                Settings.Instance.ScholarRoutine = cmbScholar.Text;

            if(sender == cmbSummoner)
                Settings.Instance.SummonerRoutine = cmbSummoner.Text;

            if(sender == cmbWarrior)
                Settings.Instance.WarriorRoutine = cmbWarrior.Text;

            if(sender == cmbWhiteMage)
                Settings.Instance.WhiteMageRoutine = cmbWhiteMage.Text;

            if(sender == cmbNonBattle)
                Settings.Instance.HandRoutine = cmbNonBattle.Text;

            Settings.Instance.Save();
        }
    }
}
