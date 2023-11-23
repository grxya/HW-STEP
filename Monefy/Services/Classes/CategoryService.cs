using Monefy.Models;
using Monefy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Media;

namespace Monefy.Services.Classes
{
    public class CategoryService : ICategoryService
    {
        private readonly ISerializeService _serializeService;
        private const string _filepath = "categories.json";

        public ObservableCollection<Brush> Colors { get; set; } = new ObservableCollection<Brush>()
        {
            Brushes.DarkBlue,
            Brushes.HotPink,
            Brushes.LightBlue,
            Brushes.MediumPurple,
            Brushes.LightGreen,
            Brushes.Purple,
            Brushes.YellowGreen,
            Brushes.DeepSkyBlue,
            Brushes.Goldenrod,
            Brushes.DarkCyan,
            Brushes.DarkGoldenrod,
            Brushes.Red,
            Brushes.DarkBlue,
            Brushes.HotPink,
            Brushes.LightBlue
        };

        public ObservableCollection<CategoryModel> Categories { get; set; }

        public CategoryService(ISerializeService serializeService)
        {
            _serializeService = serializeService;

            Categories = _serializeService.Deserialize<CategoryModel>(_filepath) ?? new ObservableCollection<CategoryModel>();
        }

        public void Update()
        {
            _serializeService.Serialize(Categories, _filepath);
        }

        public ObservableCollection<CategoryModel> GetActiveCategories()
        {
            var activeCategories = new ObservableCollection<CategoryModel>
            (
                Categories.Where(t => t.Name != "-")
            );

            return activeCategories;
        }
    }
}
