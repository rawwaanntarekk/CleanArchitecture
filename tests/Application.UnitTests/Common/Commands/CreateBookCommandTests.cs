using System.ComponentModel.DataAnnotations;
using CleanArchitecture.Application.Books.Commands;
using CleanArchitecture.Application.Books.Validators;
using FluentValidation.TestHelper;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Common.Commands;

public class CreateBookCommandTests
{
    private readonly CreateBookValidator _validationRules;

    public CreateBookCommandTests()
    {
        _validationRules = new CreateBookValidator();
    }

    [Fact]
    public void CreateBook_WhenTitleIsNull_ShouldThrowValidationException()
    {
        // Arrange
        var command = new CreateBookCommand
        {
            Title = null!, // Invalid title
            Author = "Author Name",
            PublicationDate = DateTime.Now
        };

        TestValidationResult<CreateBookCommand>? results = _validationRules.TestValidate(command);

        results.ShouldHaveValidationErrors();
    }

    [Fact]
    public void CreateBook_WhenPublicationDateInThePast_ShouldTHrowException()
    {
        var command = new CreateBookCommand
        {
            Title = "Valid Title",
            Author = "Author Name",
            PublicationDate = DateTime.Now.AddDays(1) // Invalid publication date
        };

        var result = _validationRules.TestValidate(command);

        result.ShouldHaveValidationErrorFor(c => c.PublicationDate)
            .WithErrorMessage("Publication date must be in the past.");


    }

}
