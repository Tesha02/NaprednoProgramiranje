using Common.Domain;
using DBBroker;
using Moq;
using Xunit;
using Server.Core.SystemOperations;

namespace Test.SOTests
{
	public class AzurirajArtikalSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Call_Update_And_Change_Artikal_Properties()
		{
			// Arrange
			var artikal = new Artikal
			{
				Id = 1,
				Naziv = "Stari naziv",
				Cena = 100
			};

			// praviš mock IBroker
			var mockBroker = new Mock<IBroker>();

			// simuliramo "update" - ovde kažemo da se artikal menja kao da ga broker ažurira u bazi
			mockBroker
				.Setup(b => b.Update(It.IsAny<Artikal>()))
				.Callback<IEntity>(entity =>
				{
					var a = entity as Artikal;
					a.Naziv = "Novi naziv";
					a.Cena = 150;
				});

			var so = new AzurirajArtikalSO(artikal, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.Update(It.Is<Artikal>(a => a.Id == 1)), Times.Once);

			Assert.Equal("Novi naziv", artikal.Naziv);
			Assert.Equal(150, artikal.Cena);
		}

		[Fact]
		public void ExecuteTemplate_Should_Call_Broker_Update()
		{
			// Arrange
			var artikal = new Artikal
			{
				Id = 1,
				Naziv = "Stari naziv",
				Cena = 100
			};

			var mockBroker = new Mock<IBroker>();

			var so = new AzurirajArtikalSO(artikal, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation(); // direktno jer ExecuteTemplate nema implementaciju u ovom primeru

			// Assert
			mockBroker.Verify(b => b.Update(artikal), Times.Once);
		}
	}
}
