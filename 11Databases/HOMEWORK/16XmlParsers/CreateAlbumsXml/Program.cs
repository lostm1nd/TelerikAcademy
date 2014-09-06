namespace CreateAlbumsXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    class Program
    {
        private const string MusicCatalogue = "../../../catalogue.xml";
        private const string AlbumsXml = "../../../albums.xml";

        static void Main()
        {
            CreateAlbumsXml();
            Console.WriteLine("Xml with albums and artists can be found in the project directory");
        }

        private static void CreateAlbumsXml()
        {
            Dictionary<string, List<string>> dict = ReadCatalogueXml();

            WriteAlbumsXml(dict);
        }

        private static Dictionary<string, List<string>> ReadCatalogueXml()
        {
            Dictionary<string, List<string>> artistsAlbums = new Dictionary<string, List<string>>();

            using (XmlReader reader = XmlReader.Create(MusicCatalogue))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "album")
                    {
                        reader.ReadToDescendant("title");
                        string albumTitle = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("artist");
                        string artistName = reader.ReadElementContentAsString();

                        if (!artistsAlbums.ContainsKey(artistName))
                        {
                            artistsAlbums[artistName] = new List<string>();
                        }

                        artistsAlbums[artistName].Add(albumTitle);
                    }
                }
            }

            return artistsAlbums;
        }

        private static void WriteAlbumsXml(Dictionary<string, List<string>> dict)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Encoding = Encoding.GetEncoding("utf-8"),
                Indent = true,
                IndentChars = "\t"
            };

            using (XmlWriter writer = XmlWriter.Create(AlbumsXml, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("artists");
                foreach (var artist in dict)
                {
                    writer.WriteStartElement("artist");
                    writer.WriteElementString("name", artist.Key);
                    writer.WriteStartElement("albums");
                    foreach (var album in artist.Value)
                    {
                        writer.WriteElementString("album", album);
                    }

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
            }
        }
    }
}