using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Apllication.Blogs.Command.CreateBlog
{
    internal class CreateBlogCommandValidation : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidation() {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is Required Feild").
                MaximumLength(200).WithMessage("Name must be less than 200 characters");
            RuleFor(v => v.Description).NotEmpty().WithMessage("Description is Required Feild").MaximumLength(100).WithMessage("Description must be less than 200 characters");
            RuleFor(v=>v.Author).NotEmpty().WithMessage("Author is Required Feild").
                MaximumLength(200).WithMessage("Author must be less than 200 characters");
        }
    }
}
