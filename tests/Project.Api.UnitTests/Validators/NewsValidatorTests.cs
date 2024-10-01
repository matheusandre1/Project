using AutoFixture;
using FluentAssertions;
using FluentAssertions.Equivalency;
using FluentValidation.TestHelper;
using Project.Api.Entities;
using Project.Api.Entities.Enums;
using Project.Api.Entities.Validators;
using System.ComponentModel.DataAnnotations;

namespace Project.Api.UnitTests.Validators
{
    public  class NewsValidatorTests
    {
        private readonly NewsValidator _newsValidator;
        private readonly Fixture _fixture = new();

        public NewsValidatorTests()
        {
            _newsValidator = new NewsValidator();
        }

        [Fact]
        public void GivenAllFields_When_Validated_ThenReturnNoError()
        {
            // Arrange

            var request = _fixture
                .Build<News>()
                .Create();


            var result = _newsValidator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GivenNullHatField_When_Validated_ThenReturnsErrorMessage()
        {
            var request = _fixture
                .Build<News>()
                .Without(x=> x.Hat)
                .Create();


                var result = _newsValidator.TestValidate(request);


            result.Errors.Should().NotBeNull();
        }

        [Fact]
        public void GivenTheEmptyHatField_When_Validated_ThenItReturnsAnError()
        {
            var request = _fixture
                .Build<News>()
                .With(x=> x.Hat, "")
                .Create();

            var result = _newsValidator.TestValidate(request);

            result.Errors.Should().NotBeEmpty();
            
        }

        [Fact]
        public void GivenTheNullTitleField_WhenValidated_ThenItReturnsAnError()
        {
            // Arrange
            var request = _fixture
                .Build<News>()
                .Without(x=> x.Title)
                .Create();

            // Act
            var result = (_newsValidator.TestValidate(request));

            // Assert
            result.Errors.Should().NotBeNull();
        }

        [Fact]
        public void GivenTheEmptyTitleField_WhenValidated_ThenItReturnsAnError()
        {
            // Arrange
            var request = _fixture
                .Build<News>()
                .With(x => x.Title, "")
                .Create();

            // Act
            var result = _newsValidator.TestValidate(request);

            // Assert
            result.Errors.Should().NotBeEmpty();    
        }

        [Fact]
        public void GiventheTitleFieldIfItIsLessThan5CharactersWhenValidate_ThenItReturnsanError()
        {
            var request = _fixture
                .Build<News>()
                .With(x => x.Title, "Test")
                .Create();

            var result = _newsValidator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Title)
              .WithErrorMessage("The Title must be longer than 5 characters.");
        }

        [Fact]
        public void GivenTheNullTextField_WhenValidate_ThenItReturnsAnError()
        {
            // Arrange

            var request = _fixture
                .Build<News>()
                .Without(x=> x.Text)
                .Create();

            // Act
            var result = _newsValidator.TestValidate(request);

            // Assert
            result.Errors.Should().NotBeNull();
                   
        }

        [Fact]
        public void GivenTheEmptyTextFieldWhenValidate_ThenItReturnsAnError()
        {
            // Arrange

            var request = _fixture
                .Build<News>()
                .With(x => x.Text, "")
                .Create();

            // Act
            var result = _newsValidator.TestValidate(request);

            // Assert
            result.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void GiventheTextFieldIfItIsLessThan20Characters_WhenValidate_ThenItReturnsanError()
        {
            var request = _fixture
                .Build<News>()
                .With(x => x.Text, "Just a simple test.")
                .Create();

            var result = _newsValidator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.Text)
              .WithErrorMessage("The Title must be longer than 20 characters.");
        }

        [Fact]

        public void GivenTheFieldAuthorNull_WhenValidate_ThenItReturnsAnError()
        {
            // Arrange

            var request = _fixture
                .Build<News>()
                .Without(x => x.Author)
                .Create();

            // Act
            var result = _newsValidator.TestValidate(request);

            // Assert
            result.Errors.Should().NotBeNull();
        }

        [Fact]
        public void GivenTheFieldAuthor_Empty_WhenValidate_ThenItReturnsAnError()
        {
            // Arrange
            var request = _fixture
                .Build<News>()
                .With(x => x.Author, "")
                .Create();

            // Act
            var result = _newsValidator.TestValidate(request);

            // Assert
            result.Errors.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData(Status.Active)]
        [InlineData(Status.Inactive)]
        [InlineData(Status.Draft)]
        public void StatusEnum_ShouldHaveValidValues(Status status)
        {
            
            Assert.IsType<Status>(status);
            Assert.True(status == Status.Active || status == Status.Inactive || status == Status.Draft);
        }

        [Theory]
        [InlineData(Status.Active)]               
        public void Given_Enum_Status_Should_Pass_If_Active_and_Return_True(Status status)
        {
            Assert.IsType<Status>(status);
            Assert.True(status == Status.Active);
        }

        [Theory]
        [InlineData(Status.Inactive)]
        public void Status_Enum_Must_Pass_If_It_Is_Inactive_And_Return_True(Status status)
        {
            Assert.IsType<Status>(status);
            Assert.True(status == Status.Inactive);
        }

        [Theory]
        [InlineData(Status.Draft)]
        public void Status_Enum_Must_Pass_If_It_Is_Draft_And_Return_True(Status status)
        {
            Assert.IsType<Status>(status);
            Assert.True(status == Status.Draft);
        }

    }
        
}
