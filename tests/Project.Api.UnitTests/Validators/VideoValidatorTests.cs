using AutoFixture;
using FluentAssertions;
using FluentValidation.TestHelper;
using Project.Api.Entities;
using Project.Api.Entities.Validators;

namespace Project.Api.UnitTests.Validators
{
    public  class VideoValidatorTests
    {
        private readonly VideoValidator _videovalidator;
        private readonly Fixture _fixture = new();

        public VideoValidatorTests()
        {
            _videovalidator = new VideoValidator();
        }

        [Fact]
        public void GivenAllFieldsItDoesntWhenValidate_ThenReturnAnyError()
        {
            // Arrange
            var request = _fixture
                .Build<Video>()
                .Create();

            // Act

            var result = _videovalidator.Validate(request);

            // Assert

            result.IsValid.Should().BeTrue();            
        }

        [Fact]
        public void GivenTheInvaliFieldHat_WhenValidate_ThenReturnsMeAnError()
        {
            var request = _fixture
                .Build<Video>()
                .Without(x => x.Hat)
                .Create();

            var result = _videovalidator.TestValidate(request);

            result.Errors.Should().NotBeNull();            
        }

        [Fact]
        public void GivenFieldHatEmpty_WhenValidate_ThenMeReturnsMeAnError()
        {
            var request = _fixture
                .Build<Video>()
                .With(x => x.Hat, "")
                .Create();

            var result = _videovalidator.TestValidate(request);

            result.Errors.Should().NotBeEmpty();

            result.ShouldHaveValidationErrorFor(x => x.Hat)
                .WithoutErrorMessage("The Hat is mandatory");
        }

        [Fact]
        public void GivenFieldTitleNullWhenValidate_ThenReturnsMeAnError()
        {
            var request = _fixture
                .Build<Video>()
                .Without(x => x.Title)
                .Create();

            var result = _videovalidator.TestValidate(request);

            result.Errors.Should().NotBeNull();
        }

        [Fact]
        public void GivenFieldTitleEmptyWhenValidate_ThenReturnsMeAnError()
        {
            var request = _fixture
                .Build<Video>()
                .With(x => x.Title, "")
                .Create();

            var result = _videovalidator.TestValidate(request);

            result.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void GivenFieldAuthorNullWhenValidate_ThenReturnsMeAnError()
        {
            var request = _fixture
                .Build<Video>()
                .Without(x => x.Author)
                .Create();

            var result = _videovalidator.TestValidate(request);

            result.Errors.Should().NotBeNull();
        }

        [Fact]
        public void GivenFieldAuthorEmpty_WhenValidate_ReturnsMeAnError()
        {
            var request = _fixture
                .Build<Video>()
                .With(x => x.Author, "")
                .Create();

            var result = _videovalidator.TestValidate(request);

            result.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void GivenFieldThumbnailNull_WhenValidate_ThenReturnsMeAnError()
        {
            var request = _fixture
                .Build<Video>()
                .Without(x => x.Thumbnail)
                .Create();

            var result = _videovalidator.TestValidate(request);

            result.Errors.Should().NotBeNull();
            
        }

        [Fact]
        public void GivenFieldThumbnailEmpty_WhenValidate_ThenReturnsMeAnError()
        {
            var request = _fixture
                .Build<Video>()
                .With(x => x.Thumbnail, "")
                .Create();

            var result = _videovalidator.TestValidate(request);

            result.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void GivenFieldUrlNull_WhenValidate_ThenReturnsMeAnError()
        {
            var request = _fixture
                .Build<Video>()
                .Without(x => x.Url)
                .Create();

            var result = _videovalidator.TestValidate(request);

            result.Errors.Should().NotBeNull();
        }

        [Fact]
        public void GivenFieldUrlEmpty_WhenValidate_ThenReturnsMeAnError()
        {
            var request = _fixture
                .Build<Video>()
                .With(x => x.Url, "")
                .Create();

            var result = _videovalidator.TestValidate(request);

            result.Errors.Should().NotBeEmpty();
        }
    }
}
