

using ShopOnline.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    internal class Program
    {
        static void CreateDatabase()
        {
            using var context = new ShopContext();
            string dbnam = context.Database.GetDbConnection().Database;
            var kq = context.Database.EnsureCreated();
            if (kq)
            { Console.WriteLine("thanh cong"); }
            else
            { Console.WriteLine("that bai"); }
        }
        static void DeleteDatabase()
        {
            using var context = new ShopContext();
            string dbnam = context.Database.GetDbConnection().Database;
            Console.Write($"Có chắc chắn xóa {dbnam} (y) ? ");
            string input = Console.ReadLine()!;

            // // Hỏi lại cho chắc
            if (input.ToLower() == "y")
            {
                bool deleted =  context.Database.EnsureDeleted();
                string deletionInfo = deleted ? "đã xóa" : "không xóa được";
                Console.WriteLine($"{dbnam} {deletionInfo}");
            }
            
        }
        static void Main(string[] args)
        {
            CreateDatabase();

            Console.WriteLine("=======================");
        }
    }
}