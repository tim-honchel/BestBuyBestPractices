using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyBestPractices
{
    public class Program
    {

        static IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        static string connString = config.GetConnectionString("DefaultConnection");
        static IDbConnection conn = new MySqlConnection(connString);

        static void Main(string[] args)
        {

            InsertDepartment();
            GetAllDepartments();

            InsertProduct();
            GetAllProducts();
            



        }

        public static void GetAllDepartments()
        {
            var repo = new DapperDepartmentRepository(conn);
            var departments = repo.GetAllDepartments();
            foreach (var department in departments)
            {
                Console.WriteLine(department.Name);
            }
        }

        public static void InsertDepartment()
        {
            var repo = new DapperDepartmentRepository(conn);
            Console.WriteLine("Type a new department name: ");
            var newDepartment = Console.ReadLine();
            repo.InsertDepartment(newDepartment);
        }

        public static void GetAllProducts()
        {
            var repo = new DapperProductRepository(conn);
            var products = repo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }
        }

        public static void InsertProduct()
        {
            var repo = new DapperProductRepository(conn);
            Console.WriteLine("Type a new product name: ");
            var newProduct = Console.ReadLine();
            repo.CreateProducts(newProduct);
        }

    }
}
