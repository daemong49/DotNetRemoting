using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProduct;
using System.IO;
using System.Reflection;

using Spring.Context;
using Spring.Context.Support;
using System.Diagnostics;

using PointBiz;

namespace DotNetRemoting
{
    public class ProductServer : MarshalByRefObject, IProduct
    {
        string guid;


        
        public ProductServer()
        {
            guid = Guid.NewGuid().ToString();
            
        }

        public IAddPointBuild Builder { get; set; }

        

        public Product find()
        {

            string currentId = guid;
            string name = System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
            return new Product { Id = currentId, Name = name, Price = 100 };
            
        }

        public List<Product> findAll()
        {
            List<Product> listProducts = new List<Product>();
            listProducts.Add(new Product { Id = "po1", Name = "Product 1", Price = 100 });
            listProducts.Add(new Product { Id = "po2", Name = "Product 2", Price = 200 });
            listProducts.Add(new Product { Id = "po3", Name = "Product 3", Price = 300 });

            return listProducts;

        }

        public IAddPointBuild GetBuilder()
        {
            IAddPointBuild pointBuild = new PointBuilder();
            int point = pointBuild.CalculateAddPoint(10000, 3, 0.5m);
            Console.WriteLine(point);
            return pointBuild;
        }

        public AssemblyContainer GetAssembly()
        {
            AssemblyContainer container = new AssemblyContainer();

            string assemblyName = "PointBiz.dll";
            var file = new FileInfo(assemblyName);

            FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(assemblyName);
            container.AssemblyName = assemblyName;
            container.Version = fileVersion.FileVersion;
            container.Bytes = File.ReadAllBytes(file.FullName);

            return container;
        }

        public Func<decimal, decimal, decimal, int> GetFunc()
        {

            return (realPayAmt, addPointRate, plusPointRate) => { return (int)Math.Round(realPayAmt * (addPointRate + plusPointRate) / 100, 0); };
        }
    }
}
 