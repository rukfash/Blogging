using System;
using System.Collections.Generic;

namespace Blogging.Models
{
    public partial class Post
    {
        public Post()
        {
            PostTag = new HashSet<PostTag>();
        }

        public Post(ViewModels.Post PostViewModel)
        {
            
            Slug = PostViewModel.Slug;
            Title = PostViewModel.Title;
            Description = PostViewModel.Description;
            Body = PostViewModel.Body;
            CreatedAt = PostViewModel.CreatedAt;
            UpdatedAt = PostViewModel.UpdatedAt;
        }

        public int PostPk { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<PostTag> PostTag { get; set; }
    }
}
