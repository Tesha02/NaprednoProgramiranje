using Common.Domain;
using DBBroker;
using Moq;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.SOTests
{
	public class LoginSOTests
	{
		[Fact]
		public void ExecuteConcreteOperation_Should_Return_Radnik_When_Exists()
		{
			// Arrange
			var inputRadnik = new Radnik
			{
				KorisnickoIme = "admin",
				Lozinka = "1234"
			};

			var expectedRadnik = new Radnik
			{
				Id = 1,
				Ime = "Petar",
				Prezime = "Petrović",
				KorisnickoIme = "admin",
				Lozinka = "1234",
				Email = "petar@example.com",
				Kontakt = "064111222"
			};

			var mockBroker = new Mock<IBroker>();

			// simuliramo da broker vraća listu sa jednim korisnikom
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<Radnik>()))
				.Returns(new List<IEntity> { expectedRadnik });

			var so = new LoginSO(inputRadnik, mockBroker.Object);

			// Act
			so.ExecuteConcreteOperation();

			// Assert
			mockBroker.Verify(b => b.GetByCondition(inputRadnik), Times.Once);
			Assert.NotNull(so.Result);
			Assert.Equal("Petar", so.Result.Ime);
			Assert.Equal("Petrović", so.Result.Prezime);
			Assert.Equal("admin", so.Result.KorisnickoIme);
		}

		[Fact]
		public void ExecuteConcreteOperation_Should_Throw_Exception_When_Radnik_Not_Found()
		{
			// Arrange
			var inputRadnik = new Radnik
			{
				KorisnickoIme = "pogresan",
				Lozinka = "9999"
			};

			var mockBroker = new Mock<IBroker>();

			// simuliramo da broker ne vraća nijednog korisnika
			mockBroker
				.Setup(b => b.GetByCondition(It.IsAny<Radnik>()))
				.Returns(new List<IEntity>());

			var so = new LoginSO(inputRadnik, mockBroker.Object);

			// Act & Assert
			var ex = Assert.Throws<Exception>(() => so.ExecuteConcreteOperation());
			Assert.Equal("Ne postoji zaposleni sa unetim kredencijalima.", ex.Message);

			mockBroker.Verify(b => b.GetByCondition(inputRadnik), Times.Once);
		}
	}
}
