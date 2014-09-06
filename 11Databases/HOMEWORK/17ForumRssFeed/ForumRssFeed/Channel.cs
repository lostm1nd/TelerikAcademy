namespace ForumRssFeed
{
    using System;
    using System.Collections.Generic;

    class Channel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public IList<Item> Item { get; set; }
    }
}