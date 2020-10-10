using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using bookStore.Models;

namespace bookStore.Models
{
    public class BookRepository:IBookRepository
    {
        MvcBookStoreEntities2 db = new MvcBookStoreEntities2();

        // 获取最畅销书籍
        public IList<Books> GetTopSellingBooks(int count)
        {
            return db.Books.Take(count).ToList();
        }

        public Books GetBookById(int id)
        {
            // 根据 ID 返回书籍
            return db.Books.Include("Categories").Single(b=>b.BookId==id);
        }

        // 根据 ID 删除书籍
        public void DeleteBookById(int id)
        {
            Books books = db.Books.Single(b => b.BookId == id);
            db.Books.DeleteObject(books);
            db.SaveChanges();
        }

        // 根据 ID 更新书籍
        public void UpdateBookById(Books book)
        {
            db.Books.Attach(book);
            db.ObjectStateManger.ChangeObjectState(book,EntityState.Modified);
            db.SaveChanges();
        }
            
        // 返回全部书籍
        public IList<Books> GetAllBoos()
        {
            return db.Books.Include("Categories").ToList();
        }

    }
}