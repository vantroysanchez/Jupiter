using Application.Headers.Queries.GetOnly;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Moq;

namespace Test.Application.Headers.Queries.GetOnly;

public class GetOnlyHeaderQueryHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsListOfHeaderOnlyDto()
    {
        // Arrange
        var mapperMock = new Mock<IMapper>();
        var headerServiceMock = new Mock<IHeaderService>();

        // Configura tu servicio mock para devolver datos ficticios
        var fakeHeaders = new List<Header>
        {
            new() { Id = 1, Code = 999, Description = "Description 1", Date = DateTime.Now, TotalAmount = 100.50m, Status = true },
            new() { Id = 2, Code = 998, Description = "Description 2", Date = DateTime.Now, TotalAmount = 150.75m, Status = false },
        };

        headerServiceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(fakeHeaders.AsQueryable());

        // Configura tu IMapper mock para devolver datos ficticios
        var fakeHeaderDtos = new List<HeaderOnlyDto>
        {
            new() { Code = 999, Description = "Description 1", Date = DateTime.Now, TotalAmount = 100.50m, Status = true },
            new() { Code = 998, Description = "Description 2", Date = DateTime.Now, TotalAmount = 150.75m, Status = false },
        };
        
        mapperMock.Setup(m => m.Map<List<HeaderOnlyDto>>(fakeHeaders)).Returns(fakeHeaderDtos);

        var queryHandler = new GetOnlyHeaderQueryHandler(mapperMock.Object, headerServiceMock.Object);
        var query = new GetOnlyHeaderQuery();

        // Act
        var result = await queryHandler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<HeaderOnlyDto>>(result);
        Assert.Equal(fakeHeaderDtos.Count, result.Count);

    }
}