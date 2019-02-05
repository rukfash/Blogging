using Blogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogging.Shared
{
    public static class Helpers
    {
        public static ViewModels.Post CastObjectFromModel(Models.Post post)
        {
            ViewModels.Post _post = new ViewModels.Post(post);

            return _post;
        }

        public static Post CastObjectFromModel(ViewModels.Post post)
        {
            Post _post = new Post(post);

            return _post;
        }

        public static ViewModels.Post[] CastListFromModel(IEnumerable<Models.Post> posts)
        {
            var data = posts.Select(x => new ViewModels.Post()
            {
                
                Slug = x.Slug,
                Title = x.Title,
                Description = x.Description,
                Body = x.Body,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                TagList = x.PostTag.Select(y => y.TagFkNavigation.TagName).ToList()
            }).ToArray();

            return data;
        }
    }
}
