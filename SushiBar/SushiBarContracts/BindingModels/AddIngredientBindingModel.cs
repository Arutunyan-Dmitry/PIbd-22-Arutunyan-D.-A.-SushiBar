namespace SushiBarContracts.BindingModels
{
    public class AddIngredientBindingModel
    {
        public int StorageFacilityId { get; set; }
        public int IngredientId { get; set; }
        public int Count { get; set; }
    }
}
