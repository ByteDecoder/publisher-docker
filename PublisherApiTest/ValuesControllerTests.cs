using Microsoft.AspNetCore.Mvc;
using Moq;
using PublisherApi.Controllers;
using PublisherApi.Services;
using Xunit;

namespace PublisherApiTest {
  public class ValuesControllerTests {
    private readonly Mock<IMessageService> _messageServiceMock;
    public ValuesControllerTests() => _messageServiceMock = new Mock<IMessageService>();

    [Fact]
    public void CreateReturnsHttpOkCreateAPost() {
      // Arrange
      var controller = new ValuesController(_messageServiceMock.Object);
      _messageServiceMock.Setup(repo => repo.Enqueue(It.IsAny<string>()))
        .Returns(true).Verifiable();

      // Act 
      var actionResult = controller.Post("The super lupper");

      // Assert
      var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
      var returnValue = okObjectResult.Value;
      _messageServiceMock.Verify();
      _messageServiceMock.Verify(repo => repo.Enqueue(It.IsAny<string>()), Times.Once);
      Assert.Equal(true, returnValue.GetType().GetProperty("Success")?.GetValue(returnValue));
    }
  }
}
