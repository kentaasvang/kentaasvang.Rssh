namespace kentaasvang.Rssh.UnitTests;

using kentaasvang.Rssh.Implementations;
using kentaasvang.Rssh.Entities;
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
      .Returns(new Result<List<ConnectionDetailEntity>>());

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
    var returnList = BuildReturnList();
    _repoMock
      .Setup(r => r.GetAllUserNames())
      .Returns(new Result<List<ConnectionDetailEntity>>() { Succeeded = true, Value = returnList});

    // Act
    _sut.ListAllConnections();

    // Assert
    foreach(var entity in returnList)
      Assert.Contains(entity.Name, FakeOutput.Output.ToString());

  }

  private static List<ConnectionDetailEntity> BuildReturnList()
  {
    // TODO: Faker
    return new List<ConnectionDetailEntity>
    {
      new ConnectionDetailEntity()
      {
        Name = "name1",
        Ip = "0.0.0.0",
        Username = "username",
        Password = "password"
      },
      new ConnectionDetailEntity()
      {
        Name = "name2",
        Ip = "0.0.0.0",
        Username = "username",
        Password = "password"
      },
      new ConnectionDetailEntity()
      {
        Name = "name2",
        Ip = "0.0.0.0",
        Username = "username",
        Password = "password"
      },
    };
  }
}