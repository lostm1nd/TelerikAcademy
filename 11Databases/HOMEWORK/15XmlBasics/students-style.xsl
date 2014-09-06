<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:x="urn:students">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Students</h1>
        <table bgcolor="#E0E0E0" cellspacing="1">
          <thead>
            <tr bgcolor="#EEEEEE">
              <th>
                Name
              </th>
              <th>
                Faculty Number
              </th>
              <th>
                Speciality
              </th>
              <th>
                Course
              </th>
              <th>
                Exams not passed
              </th>
            </tr>
          </thead>
          <xsl:for-each select="/x:students/x:student">
            <tr bgcolor="white" align="center">
              <td>
                <xsl:value-of select="x:name"/>
              </td>
              <td>
                <xsl:value-of select="x:facultynumber"/>
              </td>
              <td>
                <xsl:value-of select="x:speciality"/>
              </td>
              <td>
                <xsl:value-of select="x:course"/>
              </td>
              <td>
                <xsl:value-of select="count(x:exams/x:exam[@passed='false'])"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>