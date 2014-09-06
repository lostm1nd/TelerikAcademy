namespace MusicCatalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    class Program
    {
        private const string MusicCatalogue = "../../../catalogue.xml";

        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(MusicCatalogue);
            XmlNode root = doc.DocumentElement;

            PrintArtistAndAlbumsCount(root);

            Console.WriteLine(new String('=', 50));

            PrintArtistAndAlbumsCountXPath(doc);

            Console.WriteLine(new String('=', 50));

            DeleteAlbumsWithPriceHigherThan20(doc);
            Console.WriteLine("Xml with removed albums can be found in the project directory");

            Console.WriteLine(new String('=', 50));

            //ReadSongTitlesWithXmlReader();

            Console.WriteLine(new String('=', 50));

            //ReadSongTitlesWithLinq();
        }

        private static void ReadSongTitlesWithLinq()
        {
            XDocument doc = XDocument.Load(MusicCatalogue);

            var songTitles = doc.Descendants("song").Descendants("title");

            foreach (var title in songTitles)
            {
                Console.WriteLine(title.Value);
            }

            Console.WriteLine(songTitles.Count());
        }

        private static void ReadSongTitlesWithXmlReader()
        {
            Console.WriteLine("Song titles");
            int titlesCount = 0;
            bool isSong = false;

            using (XmlReader reader = XmlReader.Create(MusicCatalogue))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "song")
                    {
                        isSong = true;
                    }

                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "song")
                    {
                        isSong = false;
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title" && isSong)
                    {
                        titlesCount += 1;
                        Console.WriteLine(reader.ReadElementContentAsString());
                    }
                }
            }

            Console.WriteLine(titlesCount);
        }

        private static void DeleteAlbumsWithPriceHigherThan20(XmlDocument doc)
        {
            string xPath = "catalogue/album[price > 20]";
            var expensiveAlbums = doc.SelectNodes(xPath);

            foreach (XmlNode exp in expensiveAlbums)
            {
                doc.DocumentElement.RemoveChild(exp);
            }

            doc.Save("../../../removed.xml");
        }

        private static void PrintArtistAndAlbumsCountXPath(XmlDocument document)
        {
            string xPath = "//artist";
            var artists = document.SelectNodes(xPath);
            Dictionary<string, int> albumsByArtist = new Dictionary<string, int>();

            foreach (XmlNode artist in artists)
            {
                if (!albumsByArtist.ContainsKey(artist.InnerText))
                {
                    albumsByArtist[artist.InnerText] = 0;
                }

                albumsByArtist[artist.InnerText] += 1;
            }

            foreach (var pair in albumsByArtist)
            {
                Console.WriteLine("Artist: {0}; Albums: {1}", pair.Key, pair.Value);
            }
        }

        private static void PrintArtistAndAlbumsCount(XmlNode root)
        {
            Dictionary<string, int> albumsByArtist = new Dictionary<string, int>();

            foreach (XmlNode album in root.ChildNodes)
            {
                string artist = album["artist"].InnerText;
                if (!albumsByArtist.ContainsKey(artist))
                {
                    albumsByArtist[artist] = 0;
                }

                albumsByArtist[artist] += 1;
            }

            foreach (var pair in albumsByArtist)
            {
                Console.WriteLine("Artist: {0}; Albums: {1}", pair.Key, pair.Value);
            }
        }
    }
}