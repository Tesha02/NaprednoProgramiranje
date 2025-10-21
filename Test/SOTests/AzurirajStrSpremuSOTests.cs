using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using Xunit;

namespace Test.SOTests
{
	public class AzurirajStrSpremuSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Call_Update_And_Change_StrSprema_Properties()
		{
			// Arrange
			var strSprema = new StrSprema
			{
				Id = 1,
				Naziv = "Osnovna škola",
				Opis = "Završena osnovna škola"
			};

			var mockBroker = new Mock<IBroker>();

			// simuliramo da broker ažurira podatke
			mockBroker
				.Setup(b => b.Update(It.IsAny<StrSprema>()))
				.Callback<IEntity>(entity =>
				{
					var s = entity as StrSprema;
					s.Naziv = "Visoka škola";
					s.Opis = "Završena visoka škola";
				});

			// koristimo konstruktor koji prima mock broker
			var so = new AzurirajStrSpremuSO(strSprema, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.Update(It.Is<StrSprema>(s => s.Id == 1)), Times.Once);
			Assert.Equal("Visoka škola", strSprema.Naziv);
			Assert.Equal("Završena visoka škola", strSprema.Opis);
		}
	}
}
