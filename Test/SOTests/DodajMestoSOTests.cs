using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using Xunit;

namespace Test.SOTests
{
	public class DodajMestoSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Call_Add_With_Mesto()
		{
			// Arrange
			var mesto = new Mesto
			{
				PostanskiBroj = "11000",
				Naziv = "Beograd"
			};

			var mockBroker = new Mock<IBroker>();

			// simuliramo Add poziv - ne mora ništa da vraća
			mockBroker.Setup(b => b.Add(It.IsAny<Mesto>()));

			var so = new DodajMestoSO(mesto, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			// ✅ proveri da li je Add pozvan tačno jednom
			mockBroker.Verify(
				b => b.Add(It.Is<Mesto>(m => m.PostanskiBroj == "11000" && m.Naziv == "Beograd")),
				Times.Once);
		}
	}
}
