namespace kentaasvang.Rssh.UnitTests;

using kentaasvang.Rssh.Commands;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Implementations;
using kentaasvang.Rssh.Interfaces;
using kentaasvang.Rssh.Models;

public class ListHandlerTest
{
  [Fact]
  public void ShouldListAllConnections()
  {
    // Arrange
    var dbContextMock = new Mock<RsshDbContext>();
    ListHandler handler = new(dbContextMock.Object);

    // Act

    // Assert
    // TODO: assert dbContext is called with correct data
    // TODO: use Faker to provide dynamic data for inputProvider
    // dbContextMock.Verify(db => db.Add(It.IsAny<ConnectionDetail>()), Times.Once);
    // dbContextMock.Verify(db => db.SaveChanges(), Times.Once);
  }
}