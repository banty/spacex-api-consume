using System;
using FluentAssertions;
using Moq;
using SpaceX.Applicaiton.Exceptions;
using SpaceX.Applicaiton.Query;
using SpaceX.Domain;
using SpaceX.Domain.Common;

namespace SpaceX.Api.Tests
{
	public class SpacexLaunchDetailQueryHandlerTests
	{

		private readonly Mock<ISpacexService> _spacexServceMock; 
		public SpacexLaunchDetailQueryHandlerTests()
		{
			_spacexServceMock = new();
		}
        private static List<Launch> launches = new List<Launch>
        {
            new Launch()
            {
                Id= "596eb600611279d39a00003c",
                FlightNumber=1,
                MissionName= "First Mission"
            }

        };
        [Fact]
		public async Task Handle_Should_ThrowInvalidId_WhenProvidedWithIncompativleId()
		{
			//Arrange
			var id = "id0001";
			var query = new GetLaunchDetailQuery(id);
			var sut = new GetLaunchDetailQueryHandler(_spacexServceMock.Object);

			//Acct
			Func<Task> act = async () =>  await sut.Handle(query, default);

			//Assert

			await act.Should().ThrowAsync<InvalidIdException>()
						.WithMessage("Invalid Launch Id Provided.");
		}

        [Fact]
        public async Task Handle_Should_ReturnValidLaunch_WhenProvidedWithValidId()
        {
            //Arrange
            var id = "596eb600611279d39a00003c";
            var query = new GetLaunchDetailQuery(id);

            _spacexServceMock.Setup(t => t.GetSingleLaunch(id, It.IsAny<CancellationToken>()))
                            .Returns(Task.FromResult<Launch?>(launches.First()));

            var sut = new GetLaunchDetailQueryHandler(_spacexServceMock.Object);

            //Acct
            var result=  await sut.Handle(query, default);

            //Assert

            result.Should().BeSameAs(launches.First());
            result?.Id.Should().BeSameAs(id);
        }
    }
}

