using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.SOTests
{
	public class AzurirajPorudzbenicuSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Call_Update_Delete_And_Add_For_Porudzbenica()
		{
			// Arrange
			var porudzbenica = new Porudzbenica
			{
				Id = 10,
				DatumOd = new DateOnly(2025, 10, 15),
				DatumDo = new DateOnly(2025, 10, 20),
				UkupnaVr = 1500.0f,
				Radnik = new Radnik { Id = 1 },
				Kupac = new Kupac { Id = 2 },
				StavkePorudzbenica = new List<StavkaPorudzbenice>
				{
					new StavkaPorudzbenice
					{
						Id = 1,
						Kolicina = 2,
						CenaStavke = 200,
						UkupnaCena = 400,
						Artikal = new Artikal { Id = 1 }
					},
					new StavkaPorudzbenice
					{
						Id = 2,
						Kolicina = 3,
						CenaStavke = 300,
						UkupnaCena = 900,
						Artikal = new Artikal { Id = 2 }
					}
				}
			};

			var mockBroker = new Mock<IBroker>();

			// Postavljamo mock da "upije" sve pozive
			mockBroker.Setup(b => b.Update(It.IsAny<Porudzbenica>()));
			mockBroker.Setup(b => b.Delete(It.IsAny<StavkaPorudzbenice>()));
			mockBroker.Setup(b => b.Add(It.IsAny<StavkaPorudzbenice>()));

			// ✅ Koristimo konstruktor koji prima IBroker
			var so = new AzurirajPorudzbenicuSO(porudzbenica, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			// 1️⃣ Proveri da je Update pozvan jednom sa istom porudžbenicom
			mockBroker.Verify(b => b.Update(It.Is<Porudzbenica>(p => p.Id == 10)), Times.Once);

			// 2️⃣ Proveri da je Delete pozvan jednom za porudžbenicu
			mockBroker.Verify(b => b.Delete(It.Is<StavkaPorudzbenice>(sp => sp.Porudzbenica == porudzbenica)), Times.Once);

			// 3️⃣ Proveri da je Add pozvan tačno dva puta (za svaku stavku)
			mockBroker.Verify(b => b.Add(It.IsAny<StavkaPorudzbenice>()), Times.Exactly(2));

			// 4️⃣ Proveri da je svaka stavka povezana sa svojom porudžbenicom
			Assert.All(porudzbenica.StavkePorudzbenica, sp =>
			{
				Assert.Equal(porudzbenica, sp.Porudzbenica);
			});
		}
	}
}
