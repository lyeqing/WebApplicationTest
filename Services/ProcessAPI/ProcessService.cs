using System.Xml.Serialization;
using System.Xml;
using WebApplicationTest.Models.ProcessModels;
using System.Net;
using System.Collections.Generic;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace WebApplicationTest.Services.ProcessAPI
{
    public class ProcessService : IProcessService
    {
        public  string ProcessOrders()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Ordering));
            // get the order list
            List<string> orderList = new List<string>();
            List<RegexValue> regexValueList = new List<RegexValue>();
            if (File.Exists(@".\Temp\skus.txt"))
            {
                using (var reader = new StreamReader(@".\Temp\skus.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line == null) continue;
                        if (!line.StartsWith("SHIP"))
                        {
                            orderList.Add(line);
                        }
                        
                    }
                }
            } else
            {
                return "Error Order list is missing";
            }

            if (File.Exists(@".\Temp\ordering23.xml"))
            {
                Ordering ordering = new Ordering();
                var xmlString = File.ReadAllText(@".\Temp\ordering23.xml");
                using (StringReader reader = new StringReader(xmlString))
                {
                    ordering = (Ordering)serializer.Deserialize(reader);
                }
                List<Category> categories = ordering.Category.Categorie;

                findAllRegexValues(regexValueList, categories);
                using (StreamWriter file = new StreamWriter(@".\Temp\result.csv"))
                {
                    file.WriteLine("SKU" + "," + "category_id");
                    foreach (string order in orderList)
                    {
                        RegexValue regexValue = new RegexValue();
                        regexValue.Value = -999.0;
                        regexValue.Id = "2";
                        foreach (RegexValue regValue in regexValueList)
                        {
                            Regex rg = new Regex("^" + regValue.Pattern);
                            if (rg.IsMatch(order) && regValue.Value > regexValue.Value)
                            {
                                regexValue = regValue;
                            }
                        }

                        file.WriteLine(order + "," + regexValue.Id);
                    }
                }
            }
            else
            {
                return "Error Order form is missing";
            }

            
            return "done";
        }

        private static void findAllRegexValues(List<RegexValue> regexValueList, List<Category> categories)
        {
            foreach (Category category in categories)
            {
                if (category.Primary is not null )
                {
                    var primaryList = category.Primary.Split(",");
                    double authority = 5.0;
                    if (category.Authority is not null && double.TryParse(category.Authority, out double newDouble))
                    {
                        authority = newDouble;
                    }
                    if (category.Name is not null && category.Name.StartsWith("* "))
                    {
                        authority = authority - 2.5;
                    }
                    foreach (string primary in primaryList)
                    {
                        RegexValue regexValue = new RegexValue();
                        regexValue.Pattern = primary;
                        regexValue.Value = authority;
                        regexValue.Id = category.Id;
                        regexValueList.Add(regexValue);
                    }
                }
                if (category.Categorie.Count() > 0) {

                    findAllRegexValues(regexValueList, category.Categorie);               
                }
            }
        }

    }

}
