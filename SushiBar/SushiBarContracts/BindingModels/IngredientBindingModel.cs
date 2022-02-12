namespace SushiBarContracts.BindingModels
{
    /// <summary>
    /// Ингридиент, требуемый для приготовления блюда
    /// </summary>
    public class IngredientBindingModel
    {
        public int? Id { get; set; }
        public string IngredientName { get; set; }
    }
}
