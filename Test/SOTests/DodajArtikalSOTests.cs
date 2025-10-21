using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using Xunit;

namespace Test.SOTests
{
	public class DodajArtikalSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Call_Add_And_Set_Result()
		{
			// Arrange
			var artikal = new Artikal
			{
				Id = 0,
				Naziv = "Volan Golf 6",
				Cena = 799.99,
				Tip = Tip.VOLAN
			};

			var mockBroker = new Mock<IBroker>();

			// simuliramo da Add dodeljuje ID artiklu (kao što bi broker uradio u bazi)
			mockBroker
				.Setup(b => b.Add(It.IsAny<Artikal>()))
				.Callback<IEntity>(entity =>
				{
					var a = entity as Artikal;
					a.setId(5);
				});

			var so = new DodajArtikalSO(artikal, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			// ✅ proveri da li je Add pozvan tačno jednom
			mockBroker.Verify(b => b.Add(It.Is<Artikal>(a => a.Naziv == "Volan Golf 6")), Times.Once);

			// ✅ proveri da li je ID postavljen i rezultat vraćen
			Assert.Equal(5, so.Result.Id);
			Assert.Equal("Volan Golf 6", so.Result.Naziv);
			Assert.Equal(Tip.VOLAN, so.Result.Tip);
		}
	}
}
