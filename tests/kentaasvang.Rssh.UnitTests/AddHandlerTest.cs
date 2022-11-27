namespace kentaasvang.Rssh.UnitTests;

using kentaasvang.Rssh.Implementations;
using kentaasvang.Rssh.Interfaces;
using kentaasvang.Rssh.Entities;
using kentaasvang.Rssh.Repositories;

public class AddHandlerTest
{
  private readonly Mock<IConnectionDetailRepository> _connectionDetailRepoMock;
  private readonly Mock<IInputProvider> _inputProvider;
  private readonly IAddHandler _sut;
  public AddHandlerTest()
  {
    _connectionDetailRepoMock = new Mock<IConnectionDetailRepository>();
    _inputProvider = new Mock<IInputProvider>(); 
    _sut = new AddHandler(_connectionDetailRepoMock.Object, _inputProvider.Object);
  }

  [Fact]
  public void AddCommand_ShouldCallRepoInsert()
  {
    // Arrange
    // var fakeOutput = new FakeOutput();
    var newConnectionName = "testName";

    // _inputProvider.Setup(provider => provider.GetInput()).Returns("randomString");

    // TODO: use Faker
    _connectionDetailRepoMock
      .Setup(repo => repo.Insert(It.IsAny<ConnectionDetailEntity>()))
      .Returns(new Result<ConnectionDetailEntity>());

    // Act
    _sut.InsertNewConnection(newConnectionName);

    // Assert
    _connectionDetailRepoMock.Verify(repo => repo.Insert(It.IsAny<ConnectionDetailEntity>()), Times.Once);
  }

  [Fact]
  public void AddCommand_WhenAllOk_ShouldOutputSuccessMessage()
  {
    // Arrange
    var fakeOutput = new FakeOutput();
    var newConnectionName = "testName";

    _connectionDetailRepoMock
      .Setup(repo => repo.Insert(It.IsAny<ConnectionDetailEntity>()))
      .Returns(new Result<ConnectionDetailEntity>()
      {
        Succeeded = true,
        Value = new ConnectionDetailEntity()
        {
          Name = newConnectionName,
          Username = "username",
          Ip = "0.0.0.0",
          Password = "password"
        }
      });

    // Act
    _sut.InsertNewConnection(newConnectionName);

    // Assert
    Assert.Contains($"Successfully inserted new connection: {newConnectionName}", FakeOutput.Output.ToString());
  }

  [Fact]
  public void AddCommand_WhenNotOk_ShouldOutputErrorMessage()
  {
    // Arrange
    var fakeOutput = new FakeOutput();
    var newConnectionName = "testName";
    var errorMessage = "my error message";

    _connectionDetailRepoMock
      .Setup(repo => repo.Insert(It.IsAny<ConnectionDetailEntity>()))
      .Returns(new Result<ConnectionDetailEntity>()
      {
        Succeeded = false,
        ErrorMessage = errorMessage
      });

    // Act
    _sut.InsertNewConnection(newConnectionName);

    // Assert
    Assert.Contains($"Something wen't wrong: ", FakeOutput.Output.ToString());
    Assert.Contains(errorMessage, FakeOutput.Output.ToString());
  }
}