using System.ComponentModel;

namespace SushiBarContracts.ViewModels
{
    /// <summary>
    /// Ингредиент, требуемый для приготовления блюда
    /// </summary>
    public class IngredientViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название ингредиента")]
        public string IngredientName { get; set; }
    }
}
