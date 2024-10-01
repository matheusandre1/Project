using FluentValidation;

namespace Project.Api.Entities.Validators
{
    public class VideoValidator : AbstractValidator<Video>
    {
        public VideoValidator() 
        {
            RuleFor(x => x.Hat)
                .NotEmpty()
                .NotNull()
                .WithMessage("The Hat is mandatory");

            RuleFor(x => x.Title)
                .NotNull()
                .WithMessage("The Title is mandatory")
                .NotEmpty()
                .WithMessage("The Title is mandatory");

            RuleFor(x => x.Author)
                .NotNull()
                .WithMessage("The Author is mandatory")
                .NotEmpty()
                .WithMessage("The Author is mandatory");

            RuleFor(x => x.Thumbnail)
                .NotNull()
                .WithMessage("The Thumbnail is mandatory")
                .NotEmpty()
                .WithMessage("The Thumbnail is mandatory");

            RuleFor(x => x.Url)
                .NotNull()
                .WithMessage("The Url is mandatory")
                .NotEmpty()
                .WithMessage("The Url is mandatory");

            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("The Slug is mandatory")
                .NotNull()
                .WithMessage("The Slug is mandatory")
                .IsInEnum()
                .WithMessage("The Slug is mandatory");

        }
    }
}
