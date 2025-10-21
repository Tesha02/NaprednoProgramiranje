using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.SOTests
{
	public class VratiKupcaSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Return_Kupac_When_Found()
		{
			// Arrange
			var inputKupac = new Kupac { Ime = "Marko", Prezime = "Marković" };

			var expectedKupac = new Kupac
			{
				Id = 1,
				Ime = "Marko",
				Prezime = "Marković",
				Email = "marko@gmail.com",
				KontaktTelefon = "0651234567",
				Mesto = new Mesto { PostanskiBroj = "11000", Naziv = "Beograd" }
			};

			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<Kupac>()))
				.Returns(new List<IEntity> { expectedKupac });

			var so = new VratiKupcaSO(inputKupac, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetByCondition(inputKupac), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Equal("Marko", so.Result.Ime);
			Assert.Equal("Marković", so.Result.Prezime);
			Assert.Equal("Beograd", so.Result.Mesto.Naziv);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Return_Null_When_Not_Found()
		{
			// Arrange
			var inputKupac = new Kupac { Ime = "Petar", Prezime = "Petrović" };

			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<Kupac>()))
				.Returns(new List<IEntity>()); // prazna lista

			var so = new VratiKupcaSO(inputKupac, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetByCondition(inputKupac), Times.Once);
			Assert.Null(so.Result);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Broker_Fails()
		{
			// Arrange
			var inputKupac = new Kupac { Ime = "Nikola", Prezime = "Jovanović" };

			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<Kupac>()))
				.Throws(new Exception("Greška prilikom čitanja iz baze."));

			var so = new VratiKupcaSO(inputKupac, mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Greška prilikom čitanja iz baze.", ex.Message);
		}
	}
}
