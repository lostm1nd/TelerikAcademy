namespace CohesionAndCoupling
{
    using System;

    public static class FileUtils
    {
        public static string GetFileExtension(string fileName)
        {
            CheckForNullInputFile(fileName);

            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                // throw new ArgumentException("The file has no extension.");
                return "The file has no extension.";
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            CheckForNullInputFile(fileName);

            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string nameWithoutExtension = fileName.Substring(0, indexOfLastDot);
            return nameWithoutExtension;
        }

        private static void CheckForNullInputFile(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("The file name cannot be null.");
            }
        }
    }
}
