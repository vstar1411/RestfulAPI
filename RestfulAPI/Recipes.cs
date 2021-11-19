using System;

namespace RestfulAPI
{
    public class Recipes
    {
        public int id { get; set; }
        public string title { get; set; }
        public string making_time { get; set; }
        public string serves { get; set; }

        public string ingredients { get; set; }
        public int cost { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}
