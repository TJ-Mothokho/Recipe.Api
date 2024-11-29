using AutoMapper;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CreateCommentDTO, Comment>()
                .ForMember(comment => comment.CreatedAt, map => map.MapFrom(_ => DateTime.Now))
                .ForMember(comment => comment.Status, map => map.MapFrom(_ => "Active"));

            CreateMap<Comment, ReadCommentDTO>();
        }
    }
}
