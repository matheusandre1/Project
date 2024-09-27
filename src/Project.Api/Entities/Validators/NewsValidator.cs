using FluentValidation;

namespace Project.Api.Entities.Validators
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(x => x.Hat)
                .NotEmpty()
                .NotNull()
                .WithMessage("The Hat is mandatory");

            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()                
                .WithMessage("The Title is mandatory");

            RuleFor(x => x.Title)
                .MinimumLength(5)
                .WithMessage("The Title must be longer than 5 characters.");

            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull()                
                .WithMessage("The Title is mandatory");

            RuleFor(x => x.Text)
                .MinimumLength(20)
                .WithMessage("The Title must be longer than 20 characters.");

            RuleFor(x => x.Author)
                .NotEmpty()
                .NotNull()
                .WithMessage("The Author is mandatory");

            RuleFor(x => x.Status)
                .NotEmpty()
                .NotNull()
                .IsInEnum()
                .WithMessage("The Status is mandatory");


        }
    }
}
