namespace kentaasvang.Rssh.UnitTests;

using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Implementations;
using kentaasvang.Rssh.Interfaces;
using kentaasvang.Rssh.Models;
using kentaasvang.Rssh.Repositories;

public class AddHandlerTest
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void AddHandlerInsertNewConnection_ShouldCallRepoInsert(bool succeeded)
    {
      // Arrange
      var fakeOutput = new FakeOutput();
      var newConnectionName = "testName";

      var connectionDetailRepoMock = new Mock<IConnectionDetailRepository>();
      var inputProvider = new Mock<IInputProvider>(); 

      inputProvider.Setup(provider => provider.GetInput()).Returns("randomString");

      // TODO: use Faker
      var returnedConnectionDetailEnitty = new ConnectionDetailEntity
      {
        Name = newConnectionName,
        Ip = "0.0.0.0",
        Username = "username",
        Password = "password"
      };

      connectionDetailRepoMock
        .Setup(repo => repo.Insert(It.IsAny<ConnectionDetailEntity>()))
        .Returns(
          new RepositoryResult<ConnectionDetailEntity>() 
          { 
            Succeeded = succeeded, 
            Value = returnedConnectionDetailEnitty
          });

      var handler = new AddHandler(connectionDetailRepoMock.Object, inputProvider.Object);

      // Act
      handler.InsertNewConnection(newConnectionName);

      // Assert
      connectionDetailRepoMock
        .Verify(repo => repo.Insert(It.IsAny<ConnectionDetailEntity>()), Times.Once);

      if (succeeded)
        Assert.Contains($"Successfully inserted new connection: {newConnectionName}", FakeOutput.Output.ToString());
      else
        Assert.Contains("Something wen't wrong", FakeOutput.Output.ToString());
    }
}