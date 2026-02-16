using CleanArchitecture.Application.Books.Commands;
using CleanArchitecture.Application.Books.Validators;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Books.Handlers.Commands;

internal class CreateBookCommandHandler(IApplicationDbContext applicationDbContext, CreateBookValidator validationRules) : IRequestHandler<CreateBookCommand, int>
{
    public Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        applicationDbContext.Books.Add(new Domain.Entities.BooksModule.Book
        {
            Title = request.Title,
            Author = request.Author,
            PublicationDate = request.PublicationDate
        });

        validationRules.ValidateAndThrow(request);

        return applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}
