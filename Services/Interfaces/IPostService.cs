using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogging.Services.Interfaces
{
    public interface IPostService
    {
        ViewModels.Post[] GetPosts(string tag = "");
        ViewModels.Post PutPosts(ViewModels.Post post);
        ViewModels.Post PostPosts(ViewModels.Post post);
        ViewModels.Post GetPost(string slug);
    }
}
