using SushiBarContracts.Attributes;

namespace SushiBarContracts.ViewModels
{
    /// <summary>
    /// Ингредиент, требуемый для приготовления блюда
    /// </summary>
    public class IngredientViewModel
    {
        public int Id { get; set; }
        [Column(title: "Название ингредиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string IngredientName { get; set; }
    }
}
