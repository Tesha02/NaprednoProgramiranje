using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.SOTests
{
	public class VratiKupceSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Return_All_Kupci()
		{
			// Arrange
			var kupci = new List<IEntity>
			{
				new Kupac
				{
					Id = 1,
					Ime = "Marko",
					Prezime = "Marković",
					Email = "marko@gmail.com",
					KontaktTelefon = "065123456",
					Mesto = new Mesto { PostanskiBroj = "11000", Naziv = "Beograd" }
				},
				new Kupac
				{
					Id = 2,
					Ime = "Jelena",
					Prezime = "Jovanović",
					Email = "jelena@gmail.com",
					KontaktTelefon = "066987654",
					Mesto = new Mesto { PostanskiBroj = "21000", Naziv = "Novi Sad" }
				}
			};

			var mockBroker = new Mock<IBroker>();
			mockBroker.Setup(b => b.GetAll(It.IsAny<Kupac>())).Returns(kupci);

			var so = new VratiKupceSO(mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetAll(It.IsAny<Kupac>()), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Equal(2, so.Result.Count);
			Assert.Equal("Marko", so.Result[0].Ime);
			Assert.Equal("Jelena", so.Result[1].Ime);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Return_EmptyList_When_No_Kupci()
		{
			// Arrange
			var mockBroker = new Mock<IBroker>();
			mockBroker.Setup(b => b.GetAll(It.IsAny<Kupac>())).Returns(new List<IEntity>());

			var so = new VratiKupceSO(mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetAll(It.IsAny<Kupac>()), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Empty(so.Result);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Broker_Fails()
		{
			// Arrange
			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetAll(It.IsAny<Kupac>()))
				.Throws(new Exception("Greška pri čitanju kupaca iz baze."));

			var so = new VratiKupceSO(mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Greška pri čitanju kupaca iz baze.", ex.Message);
		}
	}
}
