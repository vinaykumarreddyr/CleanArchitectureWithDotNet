using FluentValidation;
using Mediator.Apllication.BlogAuthor.Command.CreateBlogAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.BlogAuthors.Command.CreateBlogAuthor
{
    public class CreateBlogAuthorValidation: AbstractValidator<CreateBlogAuthorCommand>
    {
        public CreateBlogAuthorValidation() {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required feild").MaximumLength(200).WithMessage("Maximum Lenght Exceeded");
            RuleFor(v => v.Isactive).NotEmpty().WithMessage("Must select this feild");
        }
    }
}
