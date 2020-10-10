using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace bookStore.Models
{
    public interface IBookRepository
    {
        // 其中的 Books 时数据库中的表，必须引用数据库之后，其才会生效。
        IList<Books> GetTopSellingBooks(int count);


        // 根据ID 获取书籍
        Books GetBookById(int id);

        // 根据 ID 删除书籍
        void DeleteBookById(int id);

        // 更新数据信息
        void UpdataBook(int id);

        // 添加新的书籍
        void AddToBooks(int id);

        // 获取全部书籍
        IList<Books> GetAllBoks();

    }
}
