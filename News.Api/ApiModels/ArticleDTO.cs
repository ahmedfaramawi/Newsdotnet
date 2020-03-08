using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News.Api.Models
{
    public class ArticleDTO
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }
        public string ShortDescription { get; set; }
        public string text { get; set; }
    }
}
