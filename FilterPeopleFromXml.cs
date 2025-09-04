using System;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;

namespace FilterPeopleFromXml
{
    internal class FilterPeopleFromXml
    {

        public static string FilterPeopleFromXmlFunc(string xmlData)
        {
            var xdoc = XDocument.Parse(xmlData);

            var filtered = xdoc.Descendants("Person")
                .Select(p => new
                {
                    Name = (string)p.Element("Name"),
                    Age = (int)p.Element("Age"),
                    Department = (string)p.Element("Department"),
                    Salary = (int)p.Element("Salary"),
                    HireDate = DateTime.Parse((string)p.Element("HireDate"))
                })
                .Where(p => p.Age > 30
                         && p.Department == "IT"
                         && p.Salary > 5000
                         && p.HireDate.Year < 2019)
                .ToList();

            var names = filtered.Select(p => p.Name).OrderBy(n => n).ToList();
            var totalSalary = filtered.Sum(p => p.Salary);
            var averageSalary = filtered.Any() ? filtered.Average(p => p.Salary) : 0;
            var maxSalary = filtered.Any() ? filtered.Max(p => p.Salary) : 0;
            var count = filtered.Count;

            var result = new
            {
                Names = names,
                TotalSalary = totalSalary,
                AverageSalary = averageSalary,
                MaxSalary = maxSalary,
                Count = count
            };

            return JsonSerializer.Serialize(result);
        }

        static void Main(string[] args)
        {
            string xml1 = @"<People>
                                <Person>
                                    <Name>Ali</Name>
                                    <Age>35</Age>
                                    <Department>IT</Department>
                                    <Salary>6000</Salary>
                                    <HireDate>2018-06-01</HireDate>
                                 </Person>
                                <Person>
                                    <Name>Ayşe</Name>
                                    <Age>28</Age>
                                    <Department>HR</Department>
                                    <Salary>4500</Salary>
                                    <HireDate>2020-04-15</HireDate>
                                </Person>
                            </People>";

            Console.WriteLine(FilterPeopleFromXmlFunc(xml1));

            Console.WriteLine("----------------------------------");

            string xml2 = @"<People>
                                <Person>
                                    <Name>Mehmet</Name>
                                    <Age>40</Age>
                                    <Department>IT</Department>
                                    <Salary>7500</Salary>
                                    <HireDate>2017-02-01</HireDate>
                                </Person>
                           </People>";
            Console.WriteLine(FilterPeopleFromXmlFunc(xml2));

            Console.WriteLine("----------------------------------");

            string xml3 = @"<People>
                                <Person>
                                    <Name>Zeynep</Name>
                                    <Age>45</Age>
                                    <Department>IT</Department>
                                    <Salary>9000</Salary>
                                    <HireDate>2010-01-10</HireDate>
                                </Person>
                                <Person>
                                    <Name>Ahmet</Name>
                                    <Age>50</Age>
                                    <Department>IT</Department>
                                    <Salary>8000</Salary>
                                    <HireDate>2015-05-20</HireDate>
                                </Person>
                            </People>";
            Console.WriteLine(FilterPeopleFromXmlFunc(xml3));

            Console.WriteLine("----------------------------------");

            string xml4 = @"<People>
                                <Person>
                                    <Name>Fatma</Name>
                                    <Age>33</Age>
                                    <Department>Finance</Department>
                                    <Salary>6000</Salary>
                                    <HireDate>2018-11-01</HireDate>
                                </Person>
                            </People>";
            Console.WriteLine(FilterPeopleFromXmlFunc(xml4));

            Console.WriteLine("----------------------------------");
            string xml5 = @"<People>
                                <Person>
                                    <Name>Selim</Name>
                                    <Age>32</Age>
                                    <Department>IT</Department>
                                    <Salary>5500</Salary>
                                    <HireDate>2018-08-05</HireDate> 
                                </Person>
                            </People>";
            Console.WriteLine(FilterPeopleFromXmlFunc(xml5));



        }
    }
}
