using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yvadev.Web.ViewModels
{
    public class CreatePostRequestModel : PostRequestBaseModel
    {
        public long UserId { get; set; }
    }
}
