using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connectData
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建实体对象，此处的实体对象就是 数据库 文件
            aEntities db = new aEntities();

            // 一：投影查询！！！！！！！！！
            // 1.表达式输出
            //var a = from b in db.book select b; // 查询 数据表
           // 遍历输出
            //foreach (var c in a)
            //{
            //    Console.WriteLine("{0},{1},{2}", c.bookid, c.bookname, c.zz);
            //}

            // 2.基于函数的查询  函数输出
            //Console.WriteLine(db.book.Count());// 输出 book 表中有多少行


            // 二：条件查询！！！！！！！！！

            // 基于表达式的查询
            var book1 = from b in db.book where b.bookid == "1" select b;
            // 输出查询结果的编号
            foreach (var book in book1)
            {
                Console.WriteLine(book.bookid);
            }

            //基于函数的
            //   var a = db.s.Where(b => b.sno == "1");//根据学号查询
            //    foreach (var c in a)
            //    Console.WriteLine(c.name);

            //多条件查询(并且)
            //     var a = db.s.Where(b => b.name == "张三" && b.sex == "男");
            // foreach (var c in a)
            //   Console.WriteLine(c.sno);

            //多条件查询(或者)
            //   var a = db.s.Where(b => b.name == "张三" || b.sex == "男");
            //    foreach (var c in a)
            //  Console.WriteLine(c.sno);


            //模糊查询(like '张'%)
            //  var a = db.s.Where(b => b.name.StartsWith("张"));
            //  foreach (var c in a)
            //    Console.WriteLine(c.name);

            //模糊查询(相当于like %'三')
            //  var a = db.s.Where(b => b.name.EndsWith("三"));//
            //   foreach (var c in a)
            //    Console.WriteLine(c.name);


            //模糊查询(相当于like %'三'%)
            var a = db.s.Where(b => b.name.Contains("三"));//
            foreach (var c in a)
                Console.WriteLine(c.name);      
            Console.Read();
            
            // 9月18日加上
             //排序
            //基于表达式的
          //  var a = from b in db.s orderby b.name select b;
            //foreach (var c in a)
             //   Console.WriteLine(c.name);
          //  Console.Read();

           //基于函数的排序
            //var a = db.s.OrderBy(b => b.name);//b同样代表学生表
          //  foreach (var c in a)
           //  Console.WriteLine(c.name);
            // Console.Read();

            //从第三行开始取数据
          //  var a = db.s.OrderBy(b => b.sno).Skip(2);//skip(2)代表跳过两条数据，也就是从第三条数据开始取
            // foreach (var c in a)
            // Console.WriteLine(c.name);
            // Console.Read();

            //取四条数据
          //  var a = db.s.OrderBy(b => b.sno).Take(4);//take(4)代表取四条数据
           //  foreach (var c in a)
           //  Console.WriteLine(c.name);
           //  Console.Read();

            //取第二条到第四条数据
            var a = db.s.OrderBy(b => b.sno).Skip(1).Take(3);
            foreach (var c in a)
             Console.WriteLine(c.name);
             Console.Read();   
            
            //------------------------------------------
             //多表查询

            //var a=from b in db.cj //b是代表成绩表
             //     join c in db.c//c代表课程表
                  //on b.cno equals c.cno//通过课程号相等连接
                 // select b;//从b这张表中查找
          //  foreach (var d in a)
           //     Console.WriteLine(d.fs);
          //  Console.Read();


          //  var a = from b in db.cj
                  //  join c in db.c
                 //   on b.cno equals c.cno
                   // select new//如果你需要的字段来自于多张表，那么可以考虑用select new 
                    //{
                       // c.cname,//c是指代课程表
                       // b.fs//b是指代成绩表
                   // };
         //   foreach (var d in a)
               // Console.WriteLine("{0}  {1}",d.cname,d.fs);
           // Console.Read();



            //三张表连接查询

            var a = from b in db.cj//b代表成绩表
                    join c in db.c//c代表课程表
                    on b.cno equals c.cno//成绩表和课程表通过课程号来连接
                    join d in db.s//d代表学生表
                    on b.sno equals d.sno//成绩表和学生表通过学号来连接
                    select new
                    {
                        d.name,//学生表的姓名
                        c.cname,//课程表的课程名
                        b.fs//成绩表的分数
                    };
            foreach(var d in a)
                   Console.WriteLine("{0} {1}  {2}",d.name,d.cname,d.fs);
            Console.Read();
            
            //-----------------------------------09 22 课程
                aEntities db = new aEntities();
            //基于表达式的分组
            //统计每个学号的总分
         //   var a = from b in db.cj group b by b.sno;//group后面是表名，by后面是字段名
          //  foreach(var c in a)
          //  {
            //    Console.Write(c.Key+"     ");//c.key代表根据哪一个分组
             //   Console.WriteLine(c.Sum(d => d.fs));//d代表成绩表
           // }
          //  Console.Read();

            //基于函数的写法
        //    var a = db.cj.GroupBy(b => b.sno);
      // //     foreach(var c in a)
          //  {
             //   Console.Write(c.Key+"     ");//c.key代表根据哪一个分组
             //   Console.WriteLine(c.Sum(d => d.fs));//d代表成绩表
        //   }
     //  Console.Read();

          //  var a = db.s.GroupBy(b => b.sex);//b代表学生表，在学生表中根据性别分组
        //       foreach(var c in a)
         //  {
           //     Console.Write(c.Key+"     ");//c.key代表根据哪一个分组
          //   Console.WriteLine(c.Count());//d代表成绩表
        //  }
   //   Console.Read();


            //分组筛选
            //var a = from b in db.cj//b代表成绩表
                  //  group b by b.sno into g//通过学号分组,把查询的结果放在g这个变量中
                  //  where g.Count() > 2//某一个学号对应的记录大于2
                  //  orderby g.Count() descending//降序
                   // select new
                   // {
                     //   g.Key,//代表学号字段
                       //  数量=g.Count()//把每一个学号所对应的记录放在数量这个变量
                  //  };
         //    foreach(var c in a)
         //  {
              //  Console.Write(c.Key+"     ");
           //  Console.WriteLine(c.数量);
         // }
     // Console.Read();


            //统计每一个学生的平均成绩
          var f = from a in db.s//a代表学生表
                    join b in db.cj on a.sno equals b.sno into c//b代表成绩表，两张表通过学号连接，查询的结果放在c这个变量中
                    select new
                        {
                           a.name,
                            avg = c.Average(d => d.fs)//平均成绩
                        };
            foreach (var d in f)
            {
               Console.Write(d.name + "   ");
             Console.Write(d.avg + "  ");
                Console.WriteLine();
            }
            Console.Read();
            
            //---------------------0922增删查改
                   //增加
         //   var a = new s() { sno = "6", name = "鸣人", sex = "男" };//创建一个学生的对象，并且给学号姓名性别赋值
          //  db.s.Add(a);
          //  db.SaveChanges();//保存所改变的

            //如何考虑主键重复
         //   var a = db.s.Where(b => b.sno == "6").FirstOrDefault();
           // if(a==null)
           // {
               // var b = new s() { sno = "6", name = "鸣人", sex = "男" };//创建一个学生的对象，并且给学号姓名性别赋值
              //  db.s.Add(b);
               // db.SaveChanges();//保存所改变的
          //  }

            //修改
          //  var a = db.c.Where(b => b.cno == "3").SingleOrDefault();//首先查询
         //   var a = db.c.FirstOrDefault(b => b.cno == "3");
          //  if(a!=null)
          //  {
               // a.cname = "ASP.NET";
               // db.SaveChanges();
           // }

            //批量修改

         //   var a = db.s.Where(b => b.sex == "男");
          //  foreach (var c in a)
        //        c.sex = "女";
        //    db.SaveChanges();
            
           

            //删除
         //   var a = db.s.Where(b => b.sno == "6").FirstOrDefault();
         //   if (a != null)
           // {
              //  db.s.Remove(a);
              //  db.SaveChanges();
          //  }

            //批量删除
            var a = db.myuser.Where(b => b.password == "1");
           foreach(var c in a)
                db.myuser.Remove(c);
                db.SaveChanges();
            
        
        }
    }
}
