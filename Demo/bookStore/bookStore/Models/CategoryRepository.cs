using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using bookStore.Models;

namespace bookStore.Models
{
    public class CategoryRepository:ICategoryRepository
    {
        MvcBookStoreEntities2 db = new MvcBookStoreEntities2();

        // 返回书籍种类列表
        public IList<Categories> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        // 根据 ID 获取类别,并包含该类别书籍全部数据

        public Categories GetCategories(int id)
        {
            return db.Categories.Include("Books").Single(c => c.CategoryId == id);
        }


        // 根据 ID 获取书籍，并包含书籍类别书籍
        public Books GetBooksById(int id)
        {
            return db.Books.Include("Categories").Single(b => b.BookId == id);
        }
        

    }
}