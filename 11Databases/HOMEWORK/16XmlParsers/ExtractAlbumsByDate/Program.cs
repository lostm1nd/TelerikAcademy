namespace ExtractAlbumsByDate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    class Program
    {
        private const string MusicCatalogue = "../../../catalogue.xml";

        static void Main()
        {
            GetAlbumsOlderThan(25);

            Console.WriteLine(new String('=', 50));

            GetAlbumsOlderThanWithLinq(25);

            Console.WriteLine(new String('=', 50));
        }

        private static void GetAlbumsOlderThanWithLinq(int years)
        {
            int year = DateTime.Now.Year - years;
            XDocument doc = XDocument.Load(MusicCatalogue);

            var albums = doc.Descendants("album").Where(a => int.Parse(a.Element("year").Value) < year);
            foreach (XElement album in albums)
            {
                Console.WriteLine(album.Element("title").Value + " from " + album.Element("year").Value + " year");
            }
        }

        private static void GetAlbumsOlderThan(int years)
        {
            int year = DateTime.Now.Year - years;
            string xPath = "/catalogue/album[year < " + year + "]";

            XmlDocument doc = new XmlDocument();
            doc.Load(MusicCatalogue);

            var albums = doc.SelectNodes(xPath);
            foreach (XmlNode album in albums)
            {
                Console.WriteLine(album["title"].InnerText + " from " + album["year"].InnerText + " year");
            }
        }
    }
}
