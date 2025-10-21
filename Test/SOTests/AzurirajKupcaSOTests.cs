using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using Xunit;

namespace Test.SOTests
{
	public class AzurirajKupcaSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Call_Update_And_Change_Kupac_Properties()
		{
			// Arrange
			var kupac = new Kupac
			{
				Id = 1,
				Ime = "Petar",
				Prezime = "Petrović",
				Email = "stari@email.com"
			};

			var mockBroker = new Mock<IBroker>();

			mockBroker
				.Setup(b => b.Update(It.IsAny<Kupac>()))
				.Callback<IEntity>(entity =>
				{
					var k = entity as Kupac;
					k.Email = "novi@email.com";
					k.Prezime = "Perić";
				});

			// 👇 Koristi konstruktor koji prima mock broker
			var so = new AzurirajKupcaSO(kupac, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.Update(It.Is<Kupac>(k => k.Id == 1)), Times.Once);
			Assert.Equal("novi@email.com", kupac.Email);
			Assert.Equal("Perić", kupac.Prezime);
		}
	}
}
