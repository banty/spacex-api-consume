using System;
using FluentAssertions;
using MediatR;
using Moq;
using SpaceX.Applicaiton.Exceptions;
using SpaceX.Applicaiton.Query;
using SpaceX.Domain;
using SpaceX.Domain.Common;


namespace SpaceX.Api.Tests
{
	public class SpaceXAllLaunchesQueryHandlerTests
	{

        private readonly Mock<ISpacexService> _spacexServiceMock;

        private static List<Launch> launches = new List<Launch>
        {
            new Launch()
            {
                FlightNumber=1,
                MissionName= "First Mission"
            },
            new Launch()
            {
                FlightNumber=2,
                MissionName= "Second Mission"
            },
            new Launch()
            {
                FlightNumber=3,
                MissionName= "Third Mission"
            }
        };

        public SpaceXAllLaunchesQueryHandlerTests()
        {
            _spacexServiceMock = new();
        }

        [Fact]
		public async Task Handle_Should_ThrowException_WhenNullValueReturned()
		{
            //arrange
			var query = new GetLaunchesQuery();
           _spacexServiceMock.Setup(t => t.GetLaunches("",It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<List<Launch>?>(null));
			var sut = new GetLaunchesQueryHandler(_spacexServiceMock.Object);
            //act

            Func<Task>  act = async () => await sut.Handle(query, default);
           
            //asert
            await act.Should().ThrowAsync<NotFoundExcption>()
                .WithMessage("No lauch found.");

        }
        [Fact]
		public async void Should_GetUpcomingLaunches_ValidLaunches()
		{
            //arrange
            var filter = "upcoming";
            var query = new GetLaunchesQuery(filter);

            _spacexServiceMock.Setup(t => t.GetLaunches(filter,It.IsAny<CancellationToken>()))
                               .Returns(Task.FromResult<List<Launch>?>(launches));

            var sut = new GetLaunchesQueryHandler(_spacexServiceMock.Object);
            //act

            var result = await sut.Handle(query, default);

            //assert

            result.Count().Should().Be(3);
            _spacexServiceMock.Verify(t => t.GetLaunches(filter,default),Times.Once);
              

		}
        [Fact]
        public async void Should_GetPastLaunches_ValidLaunches()
        {
            //arrange
            var filter = "past";
            var query = new GetLaunchesQuery(filter);

            _spacexServiceMock.Setup(t => t.GetLaunches(filter, It.IsAny<CancellationToken>()))
                               .Returns(Task.FromResult<List<Launch>?>(launches));

            var sut = new GetLaunchesQueryHandler(_spacexServiceMock.Object);
            //act

            var result = await sut.Handle(query, default);

            //assert

            result.Count().Should().Be(3);
            _spacexServiceMock.Verify(t => t.GetLaunches(filter, default), Times.Once);


        }
        

        
    }
}

