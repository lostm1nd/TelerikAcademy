<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" encoding="UTF-8" indent="yes"/>

  <xsl:template match="/">
    <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;</xsl:text>
    <html>
      <head>
        <meta charset="UTF-8" />
        <title>Music Catalogue</title>
      </head>
      <body>
        <h1>Music Catalogue</h1>
        <table border="1">
          <tr bgcolor="#CCCCCC">
            <th>Artist</th>
            <th>Album</th>
            <th>Songs</th>
            <th>Price</th>
          </tr>

          <xsl:for-each select="catalogue/album">

            <xsl:variable name="color">
              <xsl:choose>
                <xsl:when test="position() mod 2 = 0">
                  <xsl:value-of select="'#eee'"/>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="'#efe'"/>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:variable>

            <tr bgcolor="{$color}">
              <td>
                <xsl:value-of select="artist"/>
              </td>
              <td>
                <xsl:value-of select="title"/>
              </td>
              <td>
                <xsl:apply-templates select="songs"/>
              </td>
              <td>
                <xsl:value-of select="price"/>
                <span> USD</span>
              </td>
            </tr>

          </xsl:for-each>

        </table>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="songs">
    <ul>
      <xsl:for-each select="song">
        <li>
          <xsl:value-of select="title"/>
        </li>
      </xsl:for-each>
    </ul>
  </xsl:template>

</xsl:stylesheet>