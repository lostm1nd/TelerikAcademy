namespace UsingOleDbWithExcel
{
    using System;
    using System.Data.OleDb;

    class Program
    {
        static void Main()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\scores.xlsx;" +
                "Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";

            ReadData(connectionString);

            AddData(connectionString, "Ivanov", 30);
            Console.WriteLine("After data insert");
            ReadData(connectionString);
        }

        private static void ReadData(string connectionString)
        {
            OleDbConnection scoresConnection = new OleDbConnection(connectionString);
            try
            {
                scoresConnection.Open();
                OleDbCommand query = new OleDbCommand("SELECT Name, Score FROM [Sheet1$]", scoresConnection);
                OleDbDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Name: {0}; Score: {1}", reader["Name"], reader["Score"]);
                }
            }
            finally
            {
                scoresConnection.Close();
            }
        }

        private static void AddData(string connectionString, string name, int score)
        {
            OleDbConnection scoresConnection = new OleDbConnection(connectionString);
            try
            {
                scoresConnection.Open();
                OleDbCommand query = new OleDbCommand("INSERT INTO [Sheet1$](Name, Score) VALUES (@name, @score)", scoresConnection);
                query.Parameters.AddWithValue("@name", name);
                query.Parameters.AddWithValue("@score", score);

                query.ExecuteNonQuery();
            }
            finally
            {
                scoresConnection.Close();
            }
            
        }
    }
}
