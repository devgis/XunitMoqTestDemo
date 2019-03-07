using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            StudentRepositories r = new StudentRepositories();
            Student student = new Student()
            {
                ID = Guid.NewGuid().ToString(),
                Name = "张三" + rd.Next(1, 100000),
                Age = rd.Next(12, 20),
                Remark="Remarks"+ rd.Next(1, 100000)
            };
            //int i =r.Add(student);
            //Console.WriteLine(i);
            if (r.AddBySql(student))
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failed");
            }
            
            Console.Read();
        }
    }
}
