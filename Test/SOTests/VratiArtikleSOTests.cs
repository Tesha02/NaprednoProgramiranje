using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit;

namespace Test.SOTests
{
	public class VratiArtikleSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Return_All_Artikli()
		{
			// Arrange
			var artikli = new List<IEntity>
			{
				new Artikal { Id = 1, Naziv = "Volan Golf 6", Cena = 1200, Tip = Tip.VOLAN },
				new Artikal { Id = 2, Naziv = "Clio", Cena = 20, Tip = Tip.KAROSERIJA }
			};

			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetAll(It.IsAny<Artikal>()))
				.Returns(artikli);

			var so = new VratiArtikleSO(mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetAll(It.IsAny<Artikal>()), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Equal(2, so.Result.Count);
			Assert.Equal("Volan Golf 6", so.Result[0].Naziv);
			Assert.Equal("Clio", so.Result[1].Naziv);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Return_EmptyList_When_No_Artikli()
		{
			// Arrange
			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetAll(It.IsAny<Artikal>()))
				.Returns(new List<IEntity>());

			var so = new VratiArtikleSO(mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetAll(It.IsAny<Artikal>()), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Empty(so.Result);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Broker_Fails()
		{
			// Arrange
			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetAll(It.IsAny<Artikal>()))
				.Throws(new Exception("Greška pri čitanju artikala iz baze."));

			var so = new VratiArtikleSO(mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Greška pri čitanju artikala iz baze.", ex.Message);
		}
	}
}
