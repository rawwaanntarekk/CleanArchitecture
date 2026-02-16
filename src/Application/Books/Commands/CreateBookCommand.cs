namespace CleanArchitecture.Application.Books.Commands;

public record CreateBookCommand : IRequest<int>
{
    public string Title { get; init; } = null!;
    public string Author { get; init; } = null!;
    public DateTime PublicationDate { get; init; }
}
