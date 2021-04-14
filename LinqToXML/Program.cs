using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace LinqToXML
{
    class Program
    {
        static void Main()
        {
            // Part 1
            var lines = File.ReadAllLines("part1_data.txt");

            XDocument xml = new(new XElement("lines",
                lines.Select(line => new XElement("line", line))));

            xml.Save("part1_data.xml");

            // Part 2
            Dictionary<string, int> elementsCounter = new();

            foreach (var element in XDocument.Load("part2_data.xml").Root.Elements())
            {
                if (!elementsCounter.ContainsKey(element.Name.ToString()))
                {
                    elementsCounter.Add(element.Name.ToString(), 1);
                }
                else
                {
                    elementsCounter[element.Name.ToString()] += 1;
                }
            }

            foreach (var element in elementsCounter.OrderBy(element => element.Key))
            {
                Console.WriteLine($"{element.Key}\t{element.Value}");
            }
        }
    }
}
