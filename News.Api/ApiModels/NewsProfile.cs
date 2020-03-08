using AutoMapper;
using News.Api.Models;
using News.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Api.ApiModels
{
    public class NewsProfile : Profile 
    {
        public NewsProfile()
        {
            CreateMap<Article, ArticleDTO>().ReverseMap();
        }
       
    }
}
