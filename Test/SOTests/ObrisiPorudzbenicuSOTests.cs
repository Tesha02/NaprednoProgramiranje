using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using Xunit;

namespace Test.SOTests
{
	public class ObrisiPorudzbenicuSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Call_Delete_For_Stavke_And_Porudzbenica()
		{
			// Arrange
			var porudzbenica = new Porudzbenica { Id = 10 };
			var mockBroker = new Mock<IBroker>();

			var so = new ObrisiPorudzbenicuSO(porudzbenica, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.Delete(It.Is<StavkaPorudzbenice>(sp => sp.Porudzbenica == porudzbenica)), Times.Once);
			mockBroker.Verify(b => b.Delete(It.Is<Porudzbenica>(p => p.Id == 10)), Times.Once);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Not_Throw_Exception_When_Broker_Deletes_Successfully()
		{
			// Arrange
			var porudzbenica = new Porudzbenica { Id = 20 };
			var mockBroker = new Mock<IBroker>();

			mockBroker.Setup(b => b.Delete(It.IsAny<IEntity>())); // simulacija uspešnog brisanja

			var so = new ObrisiPorudzbenicuSO(porudzbenica, mockBroker.Object);

			// Act & Assert
			var exception = Record.Exception(() => so.ExecuteConcreteOperation());
			Assert.Null(exception); // ✅ ne sme da baci grešku
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Deleting_Stavke_Fails()
		{
			// Arrange
			var porudzbenica = new Porudzbenica { Id = 99 };
			var mockBroker = new Mock<IBroker>();

			// simuliramo da brisanje stavki baca exception
			mockBroker
				.Setup(b => b.Delete(It.Is<StavkaPorudzbenice>(sp => sp.Porudzbenica == porudzbenica)))
				.Throws(new Exception("Greška pri brisanju stavki."));

			var so = new ObrisiPorudzbenicuSO(porudzbenica, mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Greška pri brisanju stavki.", ex.Message);
		}
	}
}
