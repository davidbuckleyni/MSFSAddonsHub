using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.Models
{
    public class UploadSettings
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Dependency
        {
            public string name { get; set; }
            public string package_version { get; set; }
        }

        public class Neutral
        {
            public string LastUpdate { get; set; }
            public string OlderHistory { get; set; }
        }

        public class ReleaseNotes
        {
            public Neutral neutral { get; set; }
        }

      
            public List<Dependency> dependencies { get; set; }
            public string content_type { get; set; }
            public string title { get; set; }
            public string manufacturer { get; set; }
            public string creator { get; set; }
            public string package_version { get; set; }
            public string minimum_game_version { get; set; }
            public ReleaseNotes release_notes { get; set; }
            public string total_package_size { get; set; }
      

    }
}
