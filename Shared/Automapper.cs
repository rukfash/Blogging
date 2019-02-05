using AutoMapper;
using System.Linq;

namespace Blogging.Shared
{
    public class Automapper : Profile
    {
        /// <summary>
        /// Define model mapping and custom mapping rules
        /// More information about autommaper configuration: https://cpratt.co/using-automapper-creating-mappings/
        /// </summary>
        public Automapper()
        {

            //Address model mapping
            //CreateMap<Models.Post, ViewModels.Post>().ForMember(dest => dest.TagList,
            //     opts => opts.MapFrom(src => src.PostTag != null ? src.PostTag.Select(x => x.TagFkNavigation.TagName) : null));

        }
    }
}
