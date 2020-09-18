﻿using System;
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
        }
    }
}
