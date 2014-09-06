namespace RetrieveCategoriesCountFromNorthwind
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    class Program
    {
        static void Main()
        {
            SqlConnection northwindConnection = new SqlConnection(Connection.Default.ConnectionString);
            northwindConnection.Open();
            byte[] image;

            using (northwindConnection)
            {
                PrintCategoryCount(northwindConnection);

                Console.WriteLine(new String('=', 50));

                PrintCategoryAndDescription(northwindConnection);

                Console.WriteLine(new String('=', 50));

                PrintCategoryAndProduct(northwindConnection);

                Console.WriteLine(new String('=', 50));

                Console.WriteLine("Added row with id: {0}", AddProduct("Lemonade", false, northwindConnection));

                Console.WriteLine(new String('=', 50));

                Console.WriteLine("Added row with id: {0}", AddProduct("Pink lemonade", false, northwindConnection));

                Console.WriteLine(new String('=', 50));

                image = GetImageForCategory(1, northwindConnection);
            }

            if (image != null)
            {
                FileStream stream = File.OpenWrite(@"..\..\categoryImage.bmp");
                using (stream)
                {
                    stream.Write(image, 78, image.Length-78);
                }

                Console.WriteLine("Image should be in project directory");
            }
        }

        static byte[] GetImageForCategory(int categoryId, SqlConnection dbConnection)
        {
            SqlCommand getImage = new SqlCommand("SELECT Picture FROM Categories WHERE CategoryID = @id", dbConnection);
            getImage.Parameters.AddWithValue("@id", categoryId);

            byte[] image = (byte[])getImage.ExecuteScalar();

            return image;
        }

        static int AddProduct(string name, bool discontinued, SqlConnection dbConnection)
        {
            SqlCommand insertProduct = new SqlCommand("INSERT INTO Products(ProductName, Discontinued) " +
                "VALUES (@name, @disc)", dbConnection);
            insertProduct.Parameters.AddWithValue("@name", name);
            insertProduct.Parameters.AddWithValue("@disc", discontinued);
            insertProduct.ExecuteNonQuery();

            SqlCommand selectIdentity = new SqlCommand("SELECT @@Identity", dbConnection);
            int insertedId = (int)(decimal)selectIdentity.ExecuteScalar();

            return insertedId;
        }

        static void PrintCategoryAndProduct(SqlConnection dbConnection)
        {
            string command = "SELECT c.CategoryName, p.ProductName " +
                            "FROM Products p " +
                                "INNER JOIN Categories c " +
                                    "ON p.CategoryID = c.CategoryID " +
                            "ORDER BY c.CategoryName";

            SqlCommand getCategoryAndProduct = new SqlCommand(command, dbConnection);
            SqlDataReader categoryAndProduct = getCategoryAndProduct.ExecuteReader();
            using (categoryAndProduct)
            {
                while (categoryAndProduct.Read())
                {
                    Console.WriteLine("CategoryName: {0}, ProductName: {1}",
                        (string)categoryAndProduct["CategoryName"], (string)categoryAndProduct["ProductName"]);
                }
            }
        }

        static void PrintCategoryAndDescription(SqlConnection dbConnection)
        {
            SqlCommand getNameAndDescription = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbConnection);
            SqlDataReader namesAndDescriptions = getNameAndDescription.ExecuteReader();
            using (namesAndDescriptions)
            {
                while (namesAndDescriptions.Read())
                {
                    Console.WriteLine("CategoryName: {0}, Description: {1}",
                        (string)namesAndDescriptions["CategoryName"], (string)namesAndDescriptions["Description"]);
                }
            }
        }

        static void PrintCategoryCount(SqlConnection dbConnection)
        {
            SqlCommand getCategoryCount = new SqlCommand("SELECT COUNT(*) FROM Categories", dbConnection);
            int categoryCount = (int)getCategoryCount.ExecuteScalar();

            Console.WriteLine("Total categories in Northwind: {0}", categoryCount);
        }
    }
}
