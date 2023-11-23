using Monefy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Monefy.Services.Interfaces
{
    public interface ICategoryService
    {
        public ObservableCollection<CategoryModel> Categories { get; set; }
        public ObservableCollection<Brush> Colors { get; set; }

        public void Update();
        public ObservableCollection<CategoryModel> GetActiveCategories();

    }
}
