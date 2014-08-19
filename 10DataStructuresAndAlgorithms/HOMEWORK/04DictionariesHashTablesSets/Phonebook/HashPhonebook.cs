namespace Phonebook
{
    using System;
    using System.Collections.Generic;

    public class HashPhonebook
    {
        private Dictionary<string, List<string>> entries;

        public HashPhonebook()
        {
            this.entries = new Dictionary<string, List<string>>();
        }

        public void AddEntry(string name, string phone)
        {
            if (this.entries.ContainsKey(name))
            {
                this.entries[name].Add(phone);
            }
            else
            {
                this.entries.Add(name, new List<string> { phone });
            }
        }

        public void AddEntry(string name, string town, string phone)
        {
            string key = name + "-" + town;
            if (this.entries.ContainsKey(key))
            {
                this.entries[key].Add(phone);
            }
            else
            {
                this.entries.Add(key, new List<string> { phone });
            }
        }

        public List<string> Find(string name)
        {
            if (this.entries.ContainsKey(name))
            {
                return new List<string>(this.entries[name]);
            }

            throw new ArgumentException("No entry exists for: " + name);
        }

        public List<string> Find(string name, string town)
        {
            string key = name + "-" + town;
            if (this.entries.ContainsKey(key))
            {
                return new List<string>(this.entries[key]);
            }

            throw new ArgumentException("No entry exists for: " + key);
        }
    }
}
