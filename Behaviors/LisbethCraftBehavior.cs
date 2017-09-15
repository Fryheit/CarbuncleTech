namespace CarbuncleTech.Behaviors
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Objects;
    using Clio.XmlEngine;
    using ff14bot.Enums;
    using ff14bot.Helpers;
    using ff14bot.Managers;
    using ff14bot.NeoProfiles;
    using Newtonsoft.Json;
    using TreeSharp;
    
    [XmlElement("LisbethCraft")]
    // ReSharper disable once UnusedMember.Global
    public class LisbethCraftBehavior : ProfileBehavior
    {
        #region Variables
        private const string RecipeJobDataFile = @"Plugins\CarbuncleTech\Data\Recipes.json";

        private bool _isDone;
        private object _lisbeth;
        private MethodInfo _lisbethJsonMethod;
        private List<RecipeJobData> _recipeJobList;
        #endregion

        #region XML Elements
        [XmlElement("LisbethOrders")]
        // ReSharper disable once MemberCanBePrivate.Global
        public List<LisbethOrder> LisbethOrders { get; set; }
        #endregion
        
        #region Overrides
        public override bool IsDone => _isDone;
        
        protected override void OnStart()
        {
            _isDone = false;
            
            InitializeLisbeth();
            
            LisbethOrders = LisbethOrders ?? new List<LisbethOrder>();
            _recipeJobList = _recipeJobList ?? LoadRecipeJobData();
            Logging.Write($@"Carbuncles know {_recipeJobList.Count} recipes.");
        }

        protected override void OnResetCachedDone()
        {
            _isDone = false;
        }
        
        protected override Composite CreateBehavior()
        {
            return new ActionRunCoroutine(ctx => Execute());
        }
        #endregion

        /// <summary>
        /// Lisbeth orderlists require a job given for each order.
        /// Since there is no API in RebornBuddy to determine the applicable crafting jobs for a recipe, we have to use
        /// xivdb JSON data to act as our mapping table. This method loads the mapping table into our internal list.
        /// </summary>
        /// <returns>List of recipe-job relations</returns>
        private List<RecipeJobData> LoadRecipeJobData()
        {
            var returnList = new List<RecipeJobData>();
            var recipeJobDataJson =
                Path.Combine(Environment.CurrentDirectory, RecipeJobDataFile);

            if (!File.Exists(recipeJobDataJson))
                LogError(@"Recipes.json not found. Cannot initialize database for LisbethCraft behavior.");
            else
                returnList = JsonConvert
                    .DeserializeObject<IEnumerable<RecipeJobData>>(File.ReadAllText(recipeJobDataJson)).ToList();

            return returnList;
        }

        /// <summary>
        /// Tries to find and load Lisbeth. Ripped straight from Saga's LisbethBehavior.
        /// </summary>
        private void InitializeLisbeth()
        {
            if (_lisbethJsonMethod != null)
                return;

            var loader = BotManager.Bots.FirstOrDefault(c => c.Name == @"Lisbeth");
            
            _lisbeth = loader?.GetType().GetProperty(@"Lisbeth")?.GetValue(loader);
            _lisbethJsonMethod = _lisbeth?.GetType().GetMethod(@"ExecuteFromJson");

            Logging.Write($@"Lisbeth Found: {_lisbeth != null}");
            Logging.Write($@"Lisbeth JSON Method Found: {_lisbethJsonMethod != null}");
        }

        /// <summary>
        /// Returns the name for a given job id.
        /// </summary>
        /// <param name="job"></param>
        /// <returns>Name of the class/job</returns>
        private static string GetJob(uint job)
        {
            // TODO: Less shitty way of doing this...
            return ((ClassJobType)job).ToString();
        }

        /// <summary>
        /// Goes through a list of LisbethOrder objects and will check against CarbuncleTech's recipe database whether
        /// the order contains a valid item or not.
        /// </summary>
        /// <param name="listToProcess">List of orders to process</param>
        /// <returns>A filtered list of orders without any invalid/unknown items</returns>
        private IEnumerable<LisbethOrder> FilterValidOrders(IEnumerable<LisbethOrder> listToProcess)
        {
            var resultList = new List<LisbethOrder>();
            
            foreach (var order in listToProcess)
            {
                var recipe = _recipeJobList.FirstOrDefault(r => r.Item == order.Item);
                if (recipe != null)
                {
                    if(string.IsNullOrEmpty(order.Job))
                        order.Job = GetJob(recipe.Job);
                    
                    resultList.Add(order);
                }
                else
                {
                    LogError($@"Recipe for item {order.Item} not found. Removing from orders...");
                }
            }

            return resultList;
        }

        /// <summary>
        /// Execute the behavior.
        /// </summary>
        /// <returns>Task has ended</returns>
        private async Task<bool> Execute()
        {
            if (_lisbeth == null || _lisbethJsonMethod == null)
            {
                LogError(@"Lisbeth not found. Aborting!");
                _isDone = true;
                return true;
            }

            var validOrders = FilterValidOrders(LisbethOrders);
            var json = JsonConvert.SerializeObject(validOrders);
            
            if (_lisbethJsonMethod != null && !string.IsNullOrWhiteSpace(json))
                // TODO: Proper error handling
                await (Task<bool>) _lisbethJsonMethod.Invoke(_lisbeth, new object[] {json});

            _isDone = true;
            return true;
        }
    }
}