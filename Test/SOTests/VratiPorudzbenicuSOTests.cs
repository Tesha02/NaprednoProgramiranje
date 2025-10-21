using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.SOTests
{
	public class VratiPorudzbenicuSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Return_Porudzbenica_With_Stavke()
		{
			// Arrange
			var input = new Porudzbenica { Id = 1 };

			var expectedPorudzbenica = new Porudzbenica
			{
				Id = 1,
				UkupnaVr = 5000,
				DatumOd = new DateOnly(2025, 1, 10),
				DatumDo = new DateOnly(2025, 1, 11),
				Kupac = new Kupac { Id = 1, Ime = "Marko", Prezime = "Marković" },
				Radnik = new Radnik { Id = 2, Ime = "Jelena", Prezime = "Jovanović" }
			};

			var stavke = new List<IEntity>
			{
				new StavkaPorudzbenice { Id = 1, Kolicina = 2, UkupnaCena = 2000 },
				new StavkaPorudzbenice { Id = 2, Kolicina = 1, UkupnaCena = 3000 }
			};

			var mockBroker = new Mock<IBroker>();

			// 1️⃣ broker vraća porudžbenicu
			mockBroker
				.Setup(b => b.GetByCondition(It.Is<Porudzbenica>(x => x.Id == 1)))
				.Returns(new List<IEntity> { expectedPorudzbenica });

			// 2️⃣ broker vraća stavke
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<StavkaPorudzbenice>()))
				.Returns(stavke);

			var so = new VratiPorudzbenicuSO(input, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetByCondition(It.IsAny<Porudzbenica>()), Times.Once);
			mockBroker.Verify(b => b.GetByCondition(It.IsAny<StavkaPorudzbenice>()), Times.Once);

			Assert.NotNull(so.Result);
			Assert.Equal(1, so.Result.Id);
			Assert.Equal(2, so.Result.StavkePorudzbenica.Count);
			Assert.Equal(5000, so.Result.UkupnaVr);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Porudzbenica_Not_Found()
		{
			// Arrange
			var input = new Porudzbenica { Id = 99 };

			var mockBroker = new Mock<IBroker>();
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<Porudzbenica>()))
				.Returns(new List<IEntity>()); // prazno

			var so = new VratiPorudzbenicuSO(input, mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Porudžbenica nije pronađena.", ex.Message);
			mockBroker.Verify(b => b.GetByCondition(It.IsAny<Porudzbenica>()), Times.Once);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Stavke_Load_Fails()
		{
			// Arrange
			var input = new Porudzbenica { Id = 1 };

			var expectedPorudzbenica = new Porudzbenica { Id = 1 };

			var mockBroker = new Mock<IBroker>();

			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<Porudzbenica>()))
				.Returns(new List<IEntity> { expectedPorudzbenica });

			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<StavkaPorudzbenice>()))
				.Throws(new Exception("Greška prilikom čitanja stavki."));

			var so = new VratiPorudzbenicuSO(input, mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Greška prilikom čitanja stavki.", ex.Message);
		}
	}
}
