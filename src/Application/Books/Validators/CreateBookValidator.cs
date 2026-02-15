using CleanArchitecture.Application.Books.Commands;

namespace CleanArchitecture.Application.Books.Validators;

public class CreateBookValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookValidator()
    {
        RuleFor(b => b.Title)
            .NotNull()
            .WithMessage("Title is required.");

        RuleFor(b => b.PublicationDate)
            .LessThan(DateTime.Now)
            .WithMessage("Publication date must be in the past.");

    }

}
