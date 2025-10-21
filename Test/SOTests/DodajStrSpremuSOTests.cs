using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using Xunit;

namespace Test.SOTests
{
	public class DodajStrSpremuSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Call_Add_And_Assign_Id()
		{
			// Arrange
			var strSprema = new StrSprema
			{
				Id = 0,
				Naziv = "Bachelor",
				Opis = "Završen osnovni nivo studija"
			};

			var mockBroker = new Mock<IBroker>();

			// simuliramo ponašanje brokera - dodeljuje ID kao da je iz baze
			mockBroker
				.Setup(b => b.Add(It.IsAny<StrSprema>()))
				.Callback<IEntity>(entity =>
				{
					var s = entity as StrSprema;
					s.setId(5);
				});

			var so = new DodajStrSpremuSO(strSprema, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			// ✅ proveri da je Add pozvan tačno jednom
			mockBroker.Verify(
				b => b.Add(It.Is<StrSprema>(s => s.Naziv == "Bachelor" && s.Opis == "Završen osnovni nivo studija")),
				Times.Once);

			// ✅ proveri da je ID dodeljen (simulirano ponašanje baze)
			Assert.Equal(5, strSprema.Id);
		}
	}
}
