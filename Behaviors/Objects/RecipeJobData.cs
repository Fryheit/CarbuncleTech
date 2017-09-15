namespace CarbuncleTech.Behaviors.Objects
{
    using Newtonsoft.Json;

    /// <summary>
    /// Associates a recipe to a crafting profession.
    /// </summary>
    public class RecipeJobData
    {
        [JsonProperty("item")]
        public uint Item { get; set; }

        [JsonProperty("classjob")]
        public uint Job { get; set; }
    }
}