namespace kentaasvang.Rssh.UnitTests;

using kentaasvang.Rssh.Commands;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Models;

public class AddHandlerTest
{
    [Fact]
    public void WhenExecuted_ShouldCallDbContextSaveWithConnectionDetail()
    {
      // Arrange
      var dbContextMock = new Mock<DatabaseContext>();
      var inputProvider = new Mock<IInputProvider>(); 

      inputProvider.Setup(provider => provider.GetInput()).Returns("randomString");

      var handler = new AddHandler(dbContextMock.Object, inputProvider.Object);
      var name = "testName";

      // Act
      handler.Handler(name);

      // Assert
      dbContextMock.Verify(db => db.Add(It.IsAny<ConnectionDetail>()), Times.Once);
      dbContextMock.Verify(db => db.SaveChanges(), Times.Once);
    }
}