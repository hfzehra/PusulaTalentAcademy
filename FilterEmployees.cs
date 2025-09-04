using System.Collections.Generic;
using System.Text.Json;

namespace CaseSolutions
{
    internal class FilterEmployees
    {
        public static string FilterEmployeesFunc(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
        {
            var filtered = employees.
                Where(e=>e.Age>=25 && e.Age<=40)
               .Where(e=>e.Department=="IT" ||  e.Department=="Finance")
               .Where(e=>e.Salary>=5000 &&  e.Salary<=9000)
               .Where(e=>e.HireDate.Year> 2017 )
               .ToList();

            var names = filtered.Select(e=>e.Name).OrderByDescending(n=>n.Length).ThenBy(n=>n).ToList();
            var sumSalary = filtered.Sum(n=>n.Salary);
            var avgSalary = filtered.Any() ? filtered.Average(n => n.Salary):0 ;
            var maxSalary = filtered.Any() ? filtered.Max(n => n.Salary):0 ;
            var minSalary = filtered.Any() ? filtered.Min(n => n.Salary):0;
            var countEmployee = filtered.Count() ;

            var result = new
            {
                Names = names,
                SumSalary = sumSalary,
                AverageSalary = avgSalary,
                MaxSalary = maxSalary,
                MinSalary = minSalary,
                CountEmployee = countEmployee
            };

            return JsonSerializer.Serialize(result);

        }
        static void Main(string[] args)
        {
            var employees = new List<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)>
            {
                //Girdi1
                //("Ali", 30, "IT", 6000m, new DateTime(2018, 5, 1)),
                //("Ayşe", 35, "Finance", 8500m, new DateTime(2019, 3, 15)),
                //("Veli", 28, "IT", 7000m, new DateTime(2020, 1, 1)),

                //Girdi2
                //("Mehmet", 26, "Finance", 5000m, new DateTime(2021, 7, 1)),
                //("Zeynep", 39, "IT", 9000m, new DateTime(2018, 11, 20)),

                //Girdi3
                //("Burak", 41, "IT", 6000m, new DateTime(2018, 06, 01)),

                //Girdi4
                //("Canan", 29, "Finance", 8000m, new DateTime(2019, 9, 1)),
                //("Okan", 35, "IT", 7500m, new DateTime(2020, 5, 10)),

                //Girdi5
                //Case'deki çıktı kısmı hatalıdır. İsterlerde 2017 sonrası filtreleniyor. Elif 2017 de işe girmiş boş dönmesi gerekiyor.
                ("Elif",27,"Finance",6500m, new DateTime(2017,12,31))


            };

            string result = FilterEmployeesFunc(employees);
            Console.WriteLine(result);
        }
    }
}
