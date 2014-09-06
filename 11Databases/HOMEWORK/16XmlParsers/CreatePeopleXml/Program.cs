namespace CreatePeopleXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Xml;
    using System.Text;
    
    class Person
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Town { get; set; }
    }

    class Program
    {
        private const string PeopleXml = "../../../people.xml";

        static void Main()
        {
            List<Person> people = ReadInput();

            CreatePeopleXml(people);
            Console.WriteLine("The new xml file is in the project directory");
        }

        private static List<Person> ReadInput()
        {
            List<Person> people = new List<Person>();
            using (StreamReader reader = new StreamReader("../../people.txt"))
            {
                string input = reader.ReadLine();
                while (input != null)
                {
                    string[] tokens = input.Split(' ');
                    people.Add(new Person
                    {
                        Name = tokens[0],
                        Phone = tokens[1],
                        Town = tokens[2]
                    });

                    input = reader.ReadLine();
                }
            }

            return people;
        }

        private static void CreatePeopleXml(List<Person> people)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Encoding = Encoding.GetEncoding("utf-8"),
                Indent = true,
                IndentChars = "\t"
            };

            using (XmlWriter writer = XmlWriter.Create(PeopleXml, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("people");
                foreach (var person in people)
                {
                    writer.WriteStartElement("person");

                    writer.WriteElementString("name", person.Name);
                    writer.WriteElementString("phone", person.Phone);
                    writer.WriteElementString("town", person.Town);

                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
            }
        }
    }
}
