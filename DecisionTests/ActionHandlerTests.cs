using FinancialAdvisor;
using Moq;

namespace FinancialTests
{
    public class ActionHandlerTests
    {
        [Fact]
        public void LogDecision_ShouldLogMessage_WhenMessageIsValid()
        {
            // Arrange
            var mockInformationProvider = new Mock<IInformationProvider>();
            var actionHandler = new ActionHandler(mockInformationProvider.Object);
            string boodschap = "Beslissing genomen: Goedkeuring investering";

            // Act
            var exception = Record.Exception(() =>
            {
                actionHandler.LogDecision(boodschap);
            }); // Record.Exception is een xUnit methode die de exception opvangt die wordt gegooid. Als er geen exception wordt gegooid, is de waarde null.

            // Assert
            Assert.Null(exception); // Als exception null is dan is er geen exception opgetreden en is de test geslaagd. Als exception niet null is, is er een exception opgetreden en is de test mislukt.
        }

        [Fact]
        public void LogDecision_ShouldThrowException_WhenMessageIsNullOrEmpty()
        {
            // Arrange
            var mockInformationProvider = new Mock<IInformationProvider>();
            var actionHandler = new ActionHandler(mockInformationProvider.Object);

            // Act
            Exception exceptionForEmptyMessage = Record.Exception(() =>
            {
                actionHandler.LogDecision("");
            });

            Exception exceptionForNullMessage = Record.Exception(() =>
            {
                actionHandler.LogDecision(null);
            });

            // Assert
            Assert.IsType<InvalidInputException>(exceptionForEmptyMessage);
            Assert.IsType<InvalidInputException>(exceptionForNullMessage);
        }

        [Fact]
        public void SendNotification_ShouldSendNotification_WhenRecipientAndContentAreValid()
        {
            // Arrange
            var mockInformationProvider = new Mock<IInformationProvider>();
            var actionHandler = new ActionHandler(mockInformationProvider.Object);

            string ontvanger = "test@example.com";
            string inhoud = "Bericht inhoud";

            // Act
            var exception = Record.Exception(() =>
            {
                actionHandler.SendNotification(ontvanger, inhoud);
            });

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void SendNotification_ShouldThrowException_WhenRecipientOrContentIsNullOrEmpty()
        {
            // Arrange
            var mockInformationProvider = new Mock<IInformationProvider>();
            var actionHandler = new ActionHandler(mockInformationProvider.Object);

            // Act
            Exception exceptionForEmptyRecipient = Record.Exception(() =>
            {
                actionHandler.SendNotification("", "Inhoud");
            });

            Exception exceptionForNullRecipient = Record.Exception(() =>
            {
                actionHandler.SendNotification(null, "Inhoud");
            });

            Exception exceptionForEmptyContent = Record.Exception(() =>
            {
                actionHandler.SendNotification("test@example.com", "");
            });

            Exception exceptionForNullContent = Record.Exception(() =>
            {
                actionHandler.SendNotification("test@example.com", null);
            });

            // Assert
            Assert.IsType<InvalidInputException>(exceptionForEmptyRecipient);
            Assert.IsType<InvalidInputException>(exceptionForNullRecipient);
            Assert.IsType<InvalidInputException>(exceptionForEmptyContent);
            Assert.IsType<InvalidInputException>(exceptionForNullContent);
        }

        [Fact]
        public void ExecuteAction_ShouldExecuteAction_WhenActionIsValid()
        {
            // Arrange
            var mockInformationProvider = new Mock<IInformationProvider>();
            var actionHandler = new ActionHandler(mockInformationProvider.Object);

            string actie = "Test Actie";

            // Act
            var exception = Record.Exception(() =>
            {
                actionHandler.ExecuteAction(actie);
            });

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void ExecuteAction_ShouldThrowException_WhenActionIsNullOrEmpty()
        {
            // Arrange
            var mockInformationProvider = new Mock<IInformationProvider>();
            var actionHandler = new ActionHandler(mockInformationProvider.Object);

            // Act
            Exception exceptionForEmptyAction = Record.Exception(() =>
            {
                actionHandler.ExecuteAction("");
            });

            Exception exceptionForNullAction = Record.Exception(() =>
            {
                actionHandler.ExecuteAction(null);
            });

            // Assert
            Assert.IsType<InvalidInputException>(exceptionForEmptyAction);
            Assert.IsType<InvalidInputException>(exceptionForNullAction);
        }
    }
}