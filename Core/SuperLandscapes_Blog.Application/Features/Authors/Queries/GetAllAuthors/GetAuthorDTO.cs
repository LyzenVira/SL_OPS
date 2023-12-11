using AutoMapper;
using SuperLandscapes_Blog.Application.Common.Mappings.Interface;
using SuperLandscapes_Blog.Domain.Entities;
using System.Text.Json.Serialization;

namespace SuperLandscapes_Blog.Application.Features.Authors.Queries.GetAllAuthors
{
    public class GetAuthorDTO : IMappingFrom<Author>
    {
        [JsonPropertyName("Id:")]
        public Guid Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string Employment { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string LinkedIn { get; set; } = null!;
        public string Description { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, GetAuthorDTO>();
        }
    }
}
