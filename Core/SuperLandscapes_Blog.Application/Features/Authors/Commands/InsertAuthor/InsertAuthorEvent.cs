using SuperLandscapes_Blog.Domain.Common;
using SuperLandscapes_Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperLandscapes_Blog.Application.Features.Authors.Commands.InsertAuthor
{
    public class InsertAuthorEvent : BaseEvent
    {
        public Author Author { get; }

        public InsertAuthorEvent(Author authors) => this.Author = authors;
    }
}
