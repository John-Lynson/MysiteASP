using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySite.DataAccess.Repositories
{
    public class CategoryService : ICategoryService
    {
        private CategoryRepository _categoryRepository;

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }

        // Implementeer andere interface methoden...
    }
}
