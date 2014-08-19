namespace HashTable
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string text = "Are you with me. Are you not. If you are with me, you better stop." +
                "With me or not, you are gone. Gone long gone.";

            string[] words = text.ToLower().Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            Hash<string, int> wordMap = new Hash<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (wordMap.ContainsKey(words[i]))
                {
                    wordMap[words[i]] += 1;
                }
                else
                {
                    wordMap[words[i]] = 1;
                }
            }

            foreach (var pair in wordMap)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }

            try
            {
                wordMap.Add("are", 23);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Trying to add 'are' - " + ex.Message);
            }

            wordMap.Remove("are");
            Console.WriteLine("After removing 'are' does the map still contains it: " + wordMap.ContainsKey("are"));

            Console.WriteLine("KeyValuePairs count: " + wordMap.Count);

            Console.WriteLine("All keys: " + string.Join(", ", wordMap.Keys));

            wordMap.Clear();
            Console.WriteLine("KeyValuePairs count after table being cleared: " + wordMap.Count);

        }
    }
}
