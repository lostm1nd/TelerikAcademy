namespace SearchingStringWithTrie
{
    using System;
    using System.Linq;
    using System.IO;
    using Gma.DataStructures.StringSearch;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            ITrie<int> trie = new SuffixTrie<int>(2);

            BuildTrie("SomeBigTextFile.txt", trie);

            var wordCount = trie.Retrieve("array").ToArray();

            Console.WriteLine("The word 'array' occurs {0} times", wordCount.Length);
        }

        private static void BuildTrie(string filePath, ITrie<int> trie)
        {
            IEnumerable<PairStringInt> words = ReadFile(filePath);
            foreach (var word in words)
            {
                trie.Add(word.Word, word.Line);
            }
        }

        private static IEnumerable<PairStringInt> ReadFile(string filePath)
        {
            ICollection<PairStringInt> result = new List<PairStringInt>(1024 * 1024);
            char[] separators = new char[] { '(', ' ', ',', '=', ')', '"', '{', '}', '-', '[', ']' };

            using (StreamReader reader = new StreamReader(filePath))
            {
                Console.WriteLine("Reading file: " + filePath);
                string line = reader.ReadLine();
                int lineNumber = 1;

                while (line != null)
                {
                    string[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        result.Add(new PairStringInt(word, lineNumber));
                    }

                    line = reader.ReadLine();
                    lineNumber++;
                }
            }

            return result;
        }
    }

    class PairStringInt
    {
        public PairStringInt(string word, int line)
        {
            this.Word = word;
            this.Line = line;
        }
        
        public string Word { get; set; }
        public int Line { get; set; }
    }
}
