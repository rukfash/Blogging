using System;
using System.Collections.Generic;

namespace Blogging.Models
{
    public partial class Tag
    {
        public Tag()
        {
            PostTag = new HashSet<PostTag>();
        }

        public int TagPk { get; set; }
        public string TagName { get; set; }

        public ICollection<PostTag> PostTag { get; set; }
    }
}
