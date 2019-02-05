
using Blogging.Models;
using Blogging.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogging.Services.Implementations
{
    

    public class PostService : IPostService
    {
        private readonly BloggingContext _context;

        public PostService(BloggingContext context)
        {
            _context = context;
        }

        public ViewModels.Post[] GetPosts(string tag = "") {

            var data = _context.Post.Include(x => x.PostTag)
                .Where(x=>x.PostTag.Any(y=>  tag == "" || y.TagFkNavigation.TagName == tag))
                .Select(x => new ViewModels.Post()
            {
                Slug = x.Slug,
                Title = x.Title,
                Description = x.Description,
                Body = x.Body,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                TagList = x.PostTag.Select(y => y.TagFkNavigation.TagName).ToList()

            }).OrderByDescending(x=>x.CreatedAt).ToArray();

            return data;

        }

        public ViewModels.Post PutPosts(ViewModels.Post PostViewModel)
        {
            Post Post = _context.Post.Include(x => x.PostTag).Where(x => x.Slug == PostViewModel.Slug).FirstOrDefault();

            
            Post.UpdatedAt = DateTime.Now;
            _context.Entry(Post).State = EntityState.Modified;
            _context.SaveChanges();

            HandleTags(PostViewModel, Post);

            return ConvertToViewModel(Post);
        }

        public ViewModels.Post PostPosts(ViewModels.Post PostViewModel)
        {
            var Post = new Post(PostViewModel);
            Post.PostPk = 0;
            Post.CreatedAt = DateTime.Now;
            Post.Slug = NormalizeSlug(Post.Title);

            //ensure that there are no duplicate slugs
            int numberOfOccurences = _context.Post.Where(x => x.Slug.Contains(Post.Slug)).Count();
            if (numberOfOccurences > 0)
                Post.Slug = Post.Slug + '-' + ++numberOfOccurences;

            _context.Post.Add(Post);
            HandleTags(PostViewModel, Post);

            return ConvertToViewModel(Post);
        }

        public ViewModels.Post GetPost(string slug)
        {
            var data = _context.Post.Include(x => x.PostTag).Where(x => x.Slug.Equals(slug)).FirstOrDefault();
            return ConvertToViewModel(data); 
        }

        public ViewModels.Post ConvertToViewModel(Models.Post post)
        {
            ViewModels.Post Post = new ViewModels.Post();
            
            Post.Slug = post.Slug;
            Post.Title = post.Title;
            Post.Description = post.Description;
            Post.Body = post.Body;
            Post.CreatedAt = post.CreatedAt;
            Post.UpdatedAt = post.UpdatedAt;

            var tags = _context.PostTag.Include(x=>x.TagFkNavigation).Where(x => x.PostFk == post.PostPk).Select(x=>x.TagFkNavigation.TagName).ToList();

            Post.TagList = tags;

            return Post;
        }

        private void HandleTags(ViewModels.Post PostViewModel, Post Post)
        {
            var currentTags = _context.PostTag.Where(x => x.PostFk == Post.PostPk);
            var tagsToAdd = PostViewModel.TagList.Where(x => !currentTags.Any(y => y.TagFkNavigation.TagName == x));
            var tagsToRemove = currentTags.Where(x => !PostViewModel.TagList.Any(y => y == x.TagFkNavigation.TagName));

            foreach (var tagToAdd in tagsToAdd)
            {
                var tag = _context.Tag.Where(x => x.TagName == tagToAdd).FirstOrDefault();

                //if tag doesn't exist create new
                if (tag == null)
                {
                    tag = new Tag() { TagName = tagToAdd };
                    _context.Tag.Add(tag);
                    _context.SaveChanges();
                    _context.Entry(tag).Reload();
                }

                //assign tag to post
                PostTag posttag = new PostTag();
                posttag.PostFk = Post.PostPk;
                posttag.TagFk = tag.TagPk;

                _context.PostTag.Add(posttag);
                _context.SaveChanges();

            }

            _context.PostTag.RemoveRange(tagsToRemove);

            _context.SaveChanges();

        }

        static string NormalizeSlug(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark && !char.IsPunctuation(c) && c != ' ')
                {
                    stringBuilder.Append(c);
                }

                if (c == ' ')
                {
                    stringBuilder.Append('-');
                }
            }
            string normalizedSlug = stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToLower();
            return normalizedSlug;
        }


    }
}
