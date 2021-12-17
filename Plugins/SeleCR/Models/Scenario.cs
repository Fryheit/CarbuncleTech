using System.ComponentModel;
using System.Configuration;

namespace CarbuncleTech.Plugins.SeleCR.Models
{
	/// <summary>
	/// Description of Scenario.
	/// </summary>
	public class Scenario
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
        public string BlueMageRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string DancerRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string GunbreakerRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string ReaperRoutine { get; set; }

        [Setting]
        [DefaultValue("")]
        public string SageRoutine { get; set; }

        public Scenario()
		{

		}
	}
}
