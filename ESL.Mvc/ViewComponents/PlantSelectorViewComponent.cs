using ESL.Core.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ESL.Mvc.ViewComponents
{
    public class PlantSelectorViewComponent : ViewComponent
    {
        public class PlantSelectorModel
        {
            public List<PlantOption> Plants { get; set; } = new();
            public int? SelectedPlantId { get; set; }
            public string InputName { get; set; } = "SelectedPlant";
            public bool Required { get; set; }
        }

        public class PlantOption
        {
            public int Value { get; set; }
            public string Text { get; set; }
            public string ImagePath { get; set; }
        }

        public IViewComponentResult Invoke(int? selectedPlantId = null, string inputName = "SelectedPlant", bool required = false)
        {
            var model = new PlantSelectorModel
            {
                SelectedPlantId = selectedPlantId,
                InputName = inputName,
                Required = required,
                Plants = [.. PlantHelper.PlantList()
                    .Select(p => new PlantOption
                    {
                        Value = p.Value,
                        Text = p.Key,
                        ImagePath = $"/images/plants/{p.Key.ToLower()}.png"
                    })] // equivalent to PlantHelper.ToPlantImageList()
            };

            return View(model);
        }
    }
}
