using FluentValidation;

namespace Project.Api.Entities.Validators
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(x => x.Hat)
                .NotEmpty()
                .WithMessage("The Hat is mandatory");
                

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("The Title is mandatory")
                .NotNull()                
                .WithMessage("The Title is mandatory");

            RuleFor(x => x.Title)
                .MinimumLength(5)
                .WithMessage("The Title must be longer than 5 characters.");

            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("The Title is mandatory")
                .NotNull()                
                .WithMessage("The Title is mandatory");

            RuleFor(x => x.Text)
                .MinimumLength(20)
                .WithMessage("The Title must be longer than 20 characters.");

            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("The Author is mandatory")
                .NotNull()
                .WithMessage("The Author is mandatory");

            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("The Status is mandatory")
                .NotNull()
                .WithMessage("The Status is mandatory")
                .IsInEnum()
                .WithMessage("The Status is mandatory");


        }
    }
}
