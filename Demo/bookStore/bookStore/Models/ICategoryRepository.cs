using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookStore.Models
{
    public interface ICategoryRepository
    {
        // 获取所有类别
        IList<Categories> GetAllCategories();

        // 根据类别 id 获取类别并包含书籍
        Categories GetCategoriesById(int id);

        // 根据 id 获取书籍
        Books GetBooksById(int id);
    }
}
