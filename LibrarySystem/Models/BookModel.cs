using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystem.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int Edition { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public int Writer { get; set; }
        public HttpPostedFile Image;
        
    }
}