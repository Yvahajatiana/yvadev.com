using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yvadev.Web.ViewModels
{
    public abstract class PostRequestBaseModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Tags { get; set; }
    }
}
