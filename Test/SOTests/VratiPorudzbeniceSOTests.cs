using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.SOTests
{
	public class VratiPorudzbeniceSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Return_All_Porudzbenice()
		{
			// Arrange
			var porudzbenice = new List<IEntity>
			{
				new Porudzbenica
				{
					Id = 1,
					UkupnaVr = 5000,
					DatumOd = new DateOnly(2025, 1, 10),
					DatumDo = new DateOnly(2025, 1, 11),
					Kupac = new Kupac { Id = 1, Ime = "Marko", Prezime = "Marković" },
					Radnik = new Radnik { Id = 2, Ime = "Jelena", Prezime = "Jovanović" },
					StavkePorudzbenica = new List<StavkaPorudzbenice>
					{
						new StavkaPorudzbenice { Id = 1, Kolicina = 2, UkupnaCena = 2000 },
						new StavkaPorudzbenice { Id = 2, Kolicina = 1, UkupnaCena = 3000 }
					}
				},
				new Porudzbenica
				{
					Id = 2,
					UkupnaVr = 2500,
					DatumOd = new DateOnly(2025, 2, 15),
					DatumDo = new DateOnly(2025, 2, 16),
					Kupac = new Kupac { Id = 2, Ime = "Petar", Prezime = "Petrović" },
					Radnik = new Radnik { Id = 3, Ime = "Maja", Prezime = "Milić" },
					StavkePorudzbenica = new List<StavkaPorudzbenice>()
				}
			};

			var mockBroker = new Mock<IBroker>();
			mockBroker.Setup(b => b.GetAll(It.IsAny<Porudzbenica>())).Returns(porudzbenice);

			var so = new VratiPorudzbeniceSO(mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetAll(It.IsAny<Porudzbenica>()), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Equal(2, so.Result.Count);
			Assert.Equal("Marko", so.Result[0].Kupac.Ime);
			Assert.Equal(2, so.Result[0].StavkePorudzbenica.Count);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Return_EmptyList_When_No_Porudzbenice()
		{
			// Arrange
			var mockBroker = new Mock<IBroker>();
			mockBroker.Setup(b => b.GetAll(It.IsAny<Porudzbenica>())).Returns(new List<IEntity>());

			var so = new VratiPorudzbeniceSO(mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetAll(It.IsAny<Porudzbenica>()), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Empty(so.Result);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Broker_Fails()
		{
			// Arrange
			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetAll(It.IsAny<Porudzbenica>()))
				.Throws(new Exception("Greška pri čitanju porudžbenica iz baze."));

			var so = new VratiPorudzbeniceSO(mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Greška pri čitanju porudžbenica iz baze.", ex.Message);
		}
	}
}
