using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yvadev.Web.ViewModels;

namespace Yvadev.Web.Contracts
{
    public interface IPostUIService
    {
        void CreatePost(CreatePostRequestModel model);
        void UpdatePost(UpdatePostRequestModel model);
    }
}
