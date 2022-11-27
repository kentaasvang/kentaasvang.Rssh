namespace kentaasvang.Rssh.UnitTests;

using kentaasvang.Rssh.Implementations;
using kentaasvang.Rssh.Repositories;
using kentaasvang.Rssh.Interfaces;

public class ListHandlerTest
{
  public readonly Mock<IConnectionDetailRepository> _repoMock;
  public readonly IListHandler _sut;

  public ListHandlerTest()
  {
    _repoMock = new Mock<IConnectionDetailRepository>();
    _sut = new ListHandler(_repoMock.Object);
  }

  [Fact]
  public void ListCommand_ShouldCallRepoGetAll()
  {
    // Arrange
    _repoMock
      .Setup(r => r.GetAllUserNames())
      .Returns(new Result<List<string>>());

    // Act
    _sut.ListAllConnections();

    // Assert
    _repoMock.Verify(repo => repo.GetAllUserNames(), Times.Once);

  }

  [Fact]
  public void ListCommand_ShouldOutputAllConnectionNames()
  {
    // Arrange
    var fakeOutput = new FakeOutput();
    var usernames = BuildReturnList();
    _repoMock
      .Setup(r => r.GetAllUserNames())
      .Returns(new Result<List<string>>() { Succeeded = true, Value = usernames});

    // Act
    _sut.ListAllConnections();

    // Assert
    foreach(var username in usernames)
      Assert.Contains(username, FakeOutput.Output.ToString());

  }

  private static List<string> BuildReturnList()
  {
    // TODO: Faker
    return new List<string>
    {
      "name1",
      "name2",
      "name3"
    };
  }
}