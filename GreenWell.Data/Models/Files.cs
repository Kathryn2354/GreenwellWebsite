using System;
using System.Collections.Generic;

namespace Greenwell.Data.Models
{
    public partial class Files
    {
        public Files()
        {
            Tagmap = new HashSet<Tagmap>();
        }

        public int FileId { get; set; }
        public string Filename { get; set; }
        public string FullPath { get; set; }
        public string Author { get; set; }
        public DateTime? UploadDate { get; set; }
        public string ExtType { get; set; }
        public double? FileSize { get; set; }
        public bool? AdminOnly { get; set; }
        public bool? Approved { get; set; }


        public ICollection<Tagmap> Tagmap { get; set; }
    }
}
