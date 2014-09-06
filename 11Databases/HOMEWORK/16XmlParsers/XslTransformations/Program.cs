namespace XslTransformations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Xsl;

    class Program
    {
        private const string CatalogueStylesheet = "../../CatalogueStylesheet.xslt";
        private const string MusicCatalogueXml = "../../../catalogue.xml";
        private const string MusicCatalogueHtml = "../../../catalogue.html";

        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(CatalogueStylesheet);
            xslt.Transform(MusicCatalogueXml, MusicCatalogueHtml);
        }
    }
}