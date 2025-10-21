using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.SOTests
{
	public class VratiArtikalSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Return_Artikal_When_Found()
		{
			// Arrange
			var artikalInput = new Artikal { Naziv = "Monitor" };

			var expectedArtikal = new Artikal
			{
				Id = 1,
				Naziv = "Volan Golf 6",
				Cena = 150.0,
				Tip = Tip.VOLAN
			};

			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<Artikal>()))
				.Returns(new List<IEntity> { expectedArtikal });

			var so = new VratiArtikalSO(artikalInput, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetByCondition(artikalInput), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Equal("Volan Golf 6", so.Result.Naziv);
			Assert.Equal(150.0, so.Result.Cena);
			Assert.Equal(Tip.VOLAN, so.Result.Tip);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Return_Null_When_Not_Found()
		{
			// Arrange
			var artikalInput = new Artikal { Naziv = "Nepostojeci" };

			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<Artikal>()))
				.Returns(new List<IEntity>()); // prazna lista

			var so = new VratiArtikalSO(artikalInput, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetByCondition(artikalInput), Times.Once);
			Assert.Null(so.Result);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Broker_Fails()
		{
			// Arrange
			var artikalInput = new Artikal { Naziv = "Volan RS8" };

			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<Artikal>()))
				.Throws(new Exception("Greška u bazi"));

			var so = new VratiArtikalSO(artikalInput, mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Greška u bazi", ex.Message);
		}
	}
}
