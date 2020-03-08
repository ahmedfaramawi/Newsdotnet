using News.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace News.Core.Entities
{
    public class Article : BaseEntity
    {
        public DateTime date { get; set; }
        public string title { get; set; }
        public string ShortDescription { get; set; }
        public string text { get; set; }
    }
}
