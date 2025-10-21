using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using Xunit;

namespace Test.SOTests
{
	public class DodajKupcaSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Call_Add_And_Set_Result()
		{
			// Arrange
			var kupac = new Kupac
			{
				Id = 0,
				Ime = "Petar",
				Prezime = "Petrović",
				Email = "petar.petrovic@example.com",
				KontaktTelefon = "0641234567",
				Mesto = new Mesto { PostanskiBroj = "11000", Naziv = "Beograd" }
			};

			var mockBroker = new Mock<IBroker>();

			// simuliramo da Add dodeljuje ID kupcu (kao u bazi)
			mockBroker
				.Setup(b => b.Add(It.IsAny<Kupac>()))
				.Callback<IEntity>(entity =>
				{
					var k = entity as Kupac;
					k.setId(15);
				});

			var so = new DodajKupcaSO(kupac, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			// ✅ proveri da je Add pozvan jednom
			mockBroker.Verify(b => b.Add(It.Is<Kupac>(x => x.Ime == "Petar" && x.Prezime == "Petrović")), Times.Once);

			// ✅ proveri da je rezultat postavljen
			Assert.Equal(15, so.Result.Id);
			Assert.Equal("Petar", so.Result.Ime);
			Assert.Equal("Beograd", so.Result.Mesto.Naziv);
		}
	}
}
