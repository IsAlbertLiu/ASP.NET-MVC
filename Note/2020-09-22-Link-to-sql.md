  多条件查询
 xsglxtEntities db = new xsglxtEntities();
            var a = db.s.Where(b => b.sno == "1"  && b.name == "张三丰");
            foreach (var c in a)
                Console.WriteLine(c.sex);
            Console.Read();




xsglxtEntities db = new xsglxtEntities();
            var a = db.s.Where(b => b.sno == "1" ||b.name == "张三丰");
            foreach (var c in a)
                Console.WriteLine(c.sex);
            Console.Read();


//模糊查询
            xsglxtEntities db = new xsglxtEntities();
           // var a = from b in db.s where b.name.Contains("张") select b;
            // var a = from b in db.s where b.name .StartsWith("张") select b;
           //  var a = from b in db.s where b.name.EndsWith("张") select b;


            //排序
         //   var c=(from a in db.s orderby a.name select a).Skip(1).Take(2);
         //   foreach (var b in c)
              //  Console.WriteLine(b.name);
          //  Console.Write(a.Count());
         
            
            //记数和最大值
            // var a = db.cj.Count();
           // Console.WriteLine(a);
        //    var price = db.cj.Max(c => c.grade);
          //  Console.WriteLine(price);


            //两张表联合查询
           // var a=from b in db.cj
          //        join c in db.c 
              //    on b.cno equals c.cno
              //    select b;
          //  foreach (var d in a)
            //    Console.WriteLine(d.fs);
               
            
            //两张表联合查询
          //  var a = from b in db.cj
                    //    join c in db.c
                 //   on b.cno equals c.cno
                      //  select new
                       // {
                            //c.cname,
                          //  b.fs
                      //  };
              //  foreach (var d in a)
              //  {
                   // Console.WriteLine(d.cname);
                 //   Console.WriteLine(d.fs);
               // }
            //三张表联合查询
          //  var f = from a in db.cj
                 //   join b in db.s
                 //   on a.sno equals b.sno
                  //  join c in db.c
                   // on a.cno equals c.cno
                   // select new
                       // {
                         //   b.name,
                         //   c.cname,
                         //   a.fs
                      //  };
           //  foreach (var d in f)
            // {
           //  Console.Write(d.name+"   ");
           //  Console.Write(d.cname+"  ");
           //  Console.Write(d.fs);
           //  Console.WriteLine();
            // }
            //分组
           

最简单的分组
  xsglxtEntities db = new xsglxtEntities();
            
            var a = from b in db.cj group b by b.sno;
             
           
            foreach(var d in a){
             Console.Write(d.Key + "   ");
             Console.Write(d.Sum(c => c.grade));
              Console.WriteLine();
            }
             
            Console.Read();

  xsglxtEntities db = new xsglxtEntities();
            //分组

  var a = db.cj.GroupBy(b => b.sno);
        var a=from b in db.cj group b by b.sno into g
             
              select new 
               {
                   g.Key,
                   数量 = g.Sum(c =>c.grade)
               };
            foreach(var d in a){
             Console.Write(d.Key + "   ");
              Console.Write(d.数量);
              Console.WriteLine();
            }
             
            Console.Read();




 //分组排序筛选
        var a=from b in db.cj group b by b.sno into g
              where g.Count()>2
              orderby g.Count() descending
              select new 
               {
                   g.Key,
                   数量 = g.Count()
               };
            foreach(var d in a){
             Console.Write(d.Key + "   ");
              Console.Write(d.数量);
              Console.WriteLine();



            //显示每个人的平均成绩
          //  var f = from a in db.s
                 //   join b in db.cj on a.sno equals b.sno into c
                 //   select new
                     //   {

                         //  a.name,
                         //   avg = c.Average(d => d.grade)
                    //    };
          //  foreach (var d in f)
         //   {
             //   Console.Write(d.name + "   ");
             //   Console.Write(d.avg + "  ");
              //  Console.WriteLine();
           // }



去掉重复项
 xsglxtEntities db = new xsglxtEntities();
            //分组排序筛选
            var a = (from b in db.cj select b.sno).Distinct();
             
           
            foreach(var d in a){
                Console.Write(d);
     
              Console.WriteLine();






修改

 xsglxtEntities db = new xsglxtEntities();
            var s = db.s.FirstOrDefault(b => b.name == "张三");
            if (s != null)
            {
                //更新属性值
               s.name= " JavaScript 语言与 Ajax 应用";
                s.sex = "女";
                //保存更改
                db.SaveChanges();
            }




添加
 xsglxtEntities db = new xsglxtEntities();
            var news = new s() { sno = "4", 
 name = "ASP.NET MVC 程序开发", 
sex= "男" }; 
 //添加到
 db.s.Add(news); 
 //保存到数据库
 db.SaveChanges();







删除

  xsglxtEntities db = new xsglxtEntities();
            var dels = db.s.FirstOrDefault(b => b.sno == "4");
            if (dels != null)
            {
                //删除实体
                db.s.Remove(dels);
                //保存到数据库
                db.SaveChanges();
            }


库模式

定义接口IBookRepository.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    public interface IBookRepository
    {
       

        //根据ID获取书籍
        Books GetBookById(int? id);

        //根据ID删除书籍
        void DeleteBookById(int? id);

        //更新书籍数据
        void UpdateBook(Books book);

        //添加新书籍
        void AddToBooks(Books book);

        //获取全部书籍
        IList<Books> GetAllBooks();

    }
}


定义类BookRepository.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    public class BookRepository : IBookRepository
    {
      
        /// <summary>
        /// 根据ID获取书籍
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Books GetBookById(int? id)
        {
            using (MvcBookStoreEntities db = new MvcBookStoreEntities())
            {
                //根据id返回书籍
                return db.Books.Single(b => b.BookId == id);
            }
        }

        /// <summary>
        /// 根据ID删除书籍
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBookById(int? id)
        {
            using (MvcBookStoreEntities db = new MvcBookStoreEntities())
            {
                //根据id删除书籍
                Books books = db.Books.Single(b => b.BookId == id);
                db.Books.Remove(books);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 更新书籍数据
        /// </summary>
        /// <param name="book"></param>
        public void UpdateBook(Books book)
        {
            using (MvcBookStoreEntities db = new MvcBookStoreEntities())
            {
                //根据id更新书籍
                //EF4.0的写法
                //db.Books.Attach(book);                
                //db.ObjectStateManager.ChangeObjectState(book, EntityState.Modified);

                //EF5.0的写法
                db.Set<Books>().Attach(book);
                db.Entry<Books>(book).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 添加新书籍
        /// </summary>
        /// <param name="book"></param>
        public void AddToBooks(Books book)
        {
            using (MvcBookStoreEntities db = new MvcBookStoreEntities())
            {
             
                //EF5.0的写法
                db.Books.Add(book);
                db.Entry<Books>(book).State = System.Data.EntityState.Added;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 获取全部书籍
        /// </summary>
        /// <returns></returns>
        public IList<Books> GetAllBooks()
        {
            using (MvcBookStoreEntities db = new MvcBookStoreEntities())
            {
                //返回全部书籍
                return db.Books.Include("Categories").ToList();
            }
        }
    }
}
调用
 BookRepository br = new BookRepository();
            Books bk = br.GetBookById(2);
            Console.WriteLine(bk.Title);
            Console.Read();
