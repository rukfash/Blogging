using System;
using System.Collections.Generic;

namespace Blogging.Models
{
    public partial class PostTag
    {
        public int PostTagPk { get; set; }
        public int PostFk { get; set; }
        public int TagFk { get; set; }

        public Post PostFkNavigation { get; set; }
        public Tag TagFkNavigation { get; set; }
    }
}
