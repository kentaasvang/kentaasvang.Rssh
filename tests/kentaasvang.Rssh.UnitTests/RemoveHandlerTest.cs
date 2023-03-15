using kentaasvang.Rssh.Implementations.Handlers;
using kentaasvang.Rssh.Interfaces.Handlers;
using kentaasvang.Rssh.Repositories;

namespace kentaasvang.Rssh.UnitTests;

public class RemoveHandlerTest
{
  public readonly Mock<IConnectionDetailRepository> _repoMock;
  public readonly IRemoveHandler _sut;

  public RemoveHandlerTest()
  {
    _repoMock = new Mock<IConnectionDetailRepository>();
    _sut = new RemoveHandler(_repoMock.Object);
  }

  [Fact]
  public void Remove_ShouldCallRepoDeleteWithName()
  {
    // Arrange
    var connectionName = "somename";
    _repoMock.Setup(r => r.Delete(It.IsAny<string>())).Returns(new Result<string>());

    // Act
    _sut.RemoveConnection(connectionName);

    // Assert
    _repoMock.Verify(repo => repo.Delete(connectionName), Times.Once);
  }

  [Fact]
  public void Remove_WhenAllOk_ShouldOutputSuccessMessage()
  {
    // Arrange
    var fakeOutput = new FakeOutput();
    var connectionName = "somename";

    _repoMock
      .Setup(r => r.Delete(It.IsAny<string>()))
      .Returns(new Result<string>(){ Succeeded = true});

    // Act
    _sut.RemoveConnection(connectionName);

    // Assert
    Assert.Contains($"Successfully removed connection: {connectionName}", FakeOutput.Output.ToString());
  }

  [Fact]
  public void Remove_WhenConnectionNotFound_ShouldOutputErrorMessage()
  {
    // Arrange
    var fakeOutput = new FakeOutput();
    var connectionName = "somename";

    _repoMock
      .Setup(r => r.Delete(It.IsAny<string>()))
      .Returns(new Result<string>(){ Succeeded = true});

    // Act
    _sut.RemoveConnection(connectionName);

    // Assert
    Assert.Contains($"Failed to remove connection: {connectionName}", FakeOutput.Output.ToString());
  }
}