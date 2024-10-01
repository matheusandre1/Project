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
                .NotEmpty()
                .NotNull()
                .WithMessage("The Title is mandatory");

            RuleFor(x => x.Author)
                .NotNull()
                .NotEmpty()
                .WithMessage("The Author is mandatory");

            RuleFor(x => x.Thumbnail)
                .NotNull()
                .NotEmpty()                
                .WithMessage("The Thumbnail is mandatory");

            RuleFor(x => x.Url)
                .NotNull()
                .NotEmpty()
                .WithMessage("The Url is mandatory");

            RuleFor(x => x.Status)
                .NotEmpty()
                .NotNull()
                .IsInEnum()
                .WithMessage("The Slug is mandatory");

        }
    }
}
