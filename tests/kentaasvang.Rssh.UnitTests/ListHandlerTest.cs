namespace kentaasvang.Rssh.UnitTests;

using kentaasvang.Rssh.Commands;
using kentaasvang.Rssh.Implementations;
using kentaasvang.Rssh.Models;
using kentaasvang.Rssh.Repositories;

public class ListHandlerTest
{
  [Fact]
  public void ShouldListAllConnections()
  {
    // Arrange
    var fakeOutput = new FakeOutput();

    var repo = new Mock<IConnectionDetailRepository>();
    ListHandler handler = new(repo.Object);

    var returnList = BuildReturnList();

    repo.Setup(r => r.GetAll()).Returns(new RepositoryResult<List<ConnectionDetailEntity>>(){ Succeeded = true, Value = returnList});

    // Act
    handler.ListAllConnections();

    // Assert
    repo.Verify(repo => repo.GetAll(), Times.Once);

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