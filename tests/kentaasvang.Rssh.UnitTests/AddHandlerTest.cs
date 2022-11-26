namespace kentaasvang.Rssh.UnitTests;

using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Implementations;
using kentaasvang.Rssh.Interfaces;
using kentaasvang.Rssh.Models;
using kentaasvang.Rssh.Repositories;

public class AddHandlerTest
{
    [Fact]
    public void AddHandlerInsertNewConnection_ShouldCallRepoInsert()
    {
      // Arrange
      var connectionDetailRepoMock = new Mock<IConnectionDetailRepository>();
      var inputProvider = new Mock<IInputProvider>(); 

      inputProvider.Setup(provider => provider.GetInput()).Returns("randomString");
      connectionDetailRepoMock
        .Setup(repo => repo.Insert(It.IsAny<ConnectionDetailEntity>()))
        .Returns(new RepositoryResult<ConnectionDetailEntity>());

      var handler = new AddHandler(connectionDetailRepoMock.Object, inputProvider.Object);
      var name = "testName";

      // Act
      handler.InsertNewConnection(name);

      // Assert
      // TODO: assert dbContext is called with correct data
      // TODO: use Faker to provide dynamic data for inputProvider
      connectionDetailRepoMock.Verify(repo => repo.Insert(It.IsAny<ConnectionDetailEntity>()), Times.Once);
    }
}