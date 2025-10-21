using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using Xunit;

namespace Test.SOTests
{
	public class ObrisiMestoSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Call_Delete_With_Correct_Mesto()
		{
			// Arrange
			var mesto = new Mesto
			{
				PostanskiBroj = "21000",
				Naziv = "Novi Sad"
			};

			var mockBroker = new Mock<IBroker>();

			// ne moramo ništa da simuliramo jer Delete ne vraća vrednost
			var so = new ObrisiMestoSO(mesto, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			// ✅ proveri da li je Delete pozvan tačno jednom sa pravim objektom
			mockBroker.Verify(
				b => b.Delete(It.Is<Mesto>(m => m.PostanskiBroj == "21000" && m.Naziv == "Novi Sad")),
				Times.Once);
		}
	}
}
