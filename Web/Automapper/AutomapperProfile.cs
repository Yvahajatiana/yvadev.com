using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yvadev.Domain.Entities;
using Yvadev.Web.ViewModels;

namespace Yvadev.Web.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreatePostRequestModel, Post>();
            CreateMap<CreatePostRequestModel, SEO>();
            CreateMap<UpdatePostRequestModel, Post>();
            CreateMap<UpdatePostRequestModel, SEO>();
        }
    }
}
