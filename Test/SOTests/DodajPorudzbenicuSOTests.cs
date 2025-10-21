using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.SOTests
{
	public class DodajPorudzbenicuSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Call_Add_For_Porudzbenica_And_Stavke()
		{
			// Arrange
			var porudzbenica = new Porudzbenica
			{
				Id = 0,
				DatumOd = new DateOnly(2025, 10, 18),
				DatumDo = new DateOnly(2025, 10, 25),
				UkupnaVr = 1500.0f,
				Radnik = new Radnik { Id = 1 },
				Kupac = new Kupac { Id = 2 },
				StavkePorudzbenica = new List<StavkaPorudzbenice>
				{
					new StavkaPorudzbenice { Id = 0, Kolicina = 2, CenaStavke = 100, UkupnaCena = 200, Artikal = new Artikal { Id = 1 } },
					new StavkaPorudzbenice { Id = 0, Kolicina = 1, CenaStavke = 300, UkupnaCena = 300, Artikal = new Artikal { Id = 2 } }
				}
			};

			var mockBroker = new Mock<IBroker>();

			// Simulacija: Add dodeljuje ID porudžbenici i stavkama
			mockBroker.Setup(b => b.Add(It.IsAny<Porudzbenica>()))
					  .Callback<IEntity>(entity => (entity as Porudzbenica)?.setId(10));

			mockBroker.Setup(b => b.Add(It.IsAny<StavkaPorudzbenice>()))
					  .Callback<IEntity>(entity =>
					  {
						  var s = entity as StavkaPorudzbenice;
						  s.setId(new Random().Next(1, 100)); // simulira ID iz baze
					  });

			var so = new DodajPorudzbenicuSO(porudzbenica, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			// 1️⃣ Porudzbenica se dodaje jednom
			mockBroker.Verify(b => b.Add(It.Is<Porudzbenica>(p => p.Radnik.Id == 1 && p.Kupac.Id == 2)), Times.Once);

			// 2️⃣ Dodaje se onoliko stavki koliko ih ima
			mockBroker.Verify(b => b.Add(It.IsAny<StavkaPorudzbenice>()), Times.Exactly(2));

			// 3️⃣ Svaka stavka ima referencu na porudzbenicu
			Assert.All(porudzbenica.StavkePorudzbenica, sp =>
			{
				Assert.Equal(porudzbenica, sp.Porudzbenica);
			});

			// 4️⃣ Result je ispravno postavljen
			Assert.Equal(porudzbenica, so.Result);
			Assert.Equal(10, so.Result.Id); // simulirani ID iz Callback-a
		}
	}
}
