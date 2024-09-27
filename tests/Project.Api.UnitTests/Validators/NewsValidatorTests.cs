using AutoFixture;
using FluentAssertions;
using Project.Api.Entities;
using Project.Api.Entities.Validators;

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
        public void Given_All_Fields_When_Validated_ReturnNoError()
        {
            // Arrange

            var request = _fixture.Build<News>()
                .Create();


            var result = _newsValidator.Validate(request);

            result.IsValid.Should().BeTrue();
        }
    }
}
