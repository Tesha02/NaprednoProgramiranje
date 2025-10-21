using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using Xunit;

namespace Test.SOTests
{
	public class ObrisiStrSpremuSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Call_Delete_With_Correct_StrSprema()
		{
			// Arrange
			var strSprema = new StrSprema
			{
				Id = 3,
				Naziv = "Master",
				Opis = "Završen master nivo"
			};

			var mockBroker = new Mock<IBroker>();
			var so = new ObrisiStrSpremuSO(strSprema, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(
				b => b.Delete(It.Is<StrSprema>(s => s.Id == 3 && s.Naziv == "Master")),
				Times.Once);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Not_Throw_When_Delete_Succeeds()
		{
			// Arrange
			var strSprema = new StrSprema { Id = 2, Naziv = "Srednja", Opis = "Srednja škola" };
			var mockBroker = new Mock<IBroker>();

			// broker uspešno briše
			mockBroker.Setup(b => b.Delete(It.IsAny<StrSprema>()));

			var so = new ObrisiStrSpremuSO(strSprema, mockBroker.Object);

			// Act & Assert
			var exception = Record.Exception(() => so.ExecuteConcreteOperation());
			Assert.Null(exception);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Broker_Fails()
		{
			// Arrange
			var strSprema = new StrSprema { Id = 5, Naziv = "Doktorat", Opis = "PhD nivo" };
			var mockBroker = new Mock<IBroker>();

			// simuliramo da broker baca izuzetak
			mockBroker
				.Setup(b => b.Delete(It.IsAny<StrSprema>()))
				.Throws(new Exception("Greška prilikom brisanja stručne spreme."));

			var so = new ObrisiStrSpremuSO(strSprema, mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Greška prilikom brisanja stručne spreme.", ex.Message);
		}
	}
}
