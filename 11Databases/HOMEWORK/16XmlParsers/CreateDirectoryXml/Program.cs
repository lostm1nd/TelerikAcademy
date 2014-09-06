namespace CreateDirectoryXml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    class Program
    {
        private const string DirectoriesXmlWriter = "../../../directories.xml";
        private const string DirectoriesXElement = "../../../directories-x.xml";

        static void Main()
        {
            DirectoriesWithXmlWriter(@"I:\Microsoft");

            DirectoriesWithXDocument(@"I:\Microsoft");
        }

        private static void DirectoriesWithXmlWriter(string startDirectory)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Encoding = Encoding.GetEncoding("utf-8"),
                Indent = true,
                IndentChars = "\t"
            };

            using (XmlWriter writer = XmlWriter.Create(DirectoriesXmlWriter, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("directories");
                CreateDirectoriesXmlWriter(new DirectoryInfo(startDirectory), writer);
                writer.WriteEndDocument();
            }

            Console.WriteLine("Xml file created with XmlWriter (directories.xml) is in the project directory");
        }

        private static void CreateDirectoriesXmlWriter(DirectoryInfo directory, XmlWriter writer)
        {
            writer.WriteStartElement("directory");
            writer.WriteAttributeString("name", directory.Name);

            foreach (var file in directory.GetFiles())
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", file.Name);
                writer.WriteEndElement();
            }

            foreach (DirectoryInfo child in directory.GetDirectories())
            {
                CreateDirectoriesXmlWriter(child, writer);
            }

            writer.WriteEndElement();
        }

        private static void DirectoriesWithXDocument(string startDirectory)
        {
            XElement root = new XElement("directories");

            CreateDirectoriesXElement(new DirectoryInfo(startDirectory), root);

            root.Save(DirectoriesXElement);
            Console.WriteLine("Xml file created with XElement (directories-x.xml) is in the project directory");
        }

        private static void CreateDirectoriesXElement(DirectoryInfo directoryInfo, XElement root)
        {
            var currentDir = new XElement("directory", new XAttribute("name", directoryInfo.Name));
            root.Add(currentDir);

            foreach (var file in directoryInfo.GetFiles())
            {
                currentDir.Add(new XElement("file", new XAttribute("name", file.Name)));
            }

            foreach (var dir in directoryInfo.GetDirectories())
            {
                CreateDirectoriesXElement(dir, currentDir);
            }
        }
    }
}