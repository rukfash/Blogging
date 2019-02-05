using Blogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogging.ViewModels
{
    public partial class Post
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<string> TagList { get; set; }
        

        public Post()
        {

        }

        public Post(Models.Post post)
        {
            Slug = post.Slug;
            Title = post.Title;
            Description = post.Description;
            Body = post.Body;
            CreatedAt = post.CreatedAt;
            UpdatedAt = post.UpdatedAt;
            TagList = post.PostTag.Select(x => x.TagFkNavigation.TagName).ToList();
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
