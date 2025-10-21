using Common.Domain;
using Xunit;


namespace Test.DomainTests
{
	public class KupacTests
	{
		[Fact]
		public void ToString_TrebaDaVratiImeIPrezime()
		{
			// Arrange
			var kupac = new Kupac { Ime = "Marko", Prezime = "Petrović" };

			// Act
			string rezultat = kupac.ToString();

			// Assert
			Assert.Equal("Marko Petrović", rezultat);
		}

		[Fact]
		public void Values_TrebaDaVratiIspravanSQLString()
		{
			// Arrange
			var kupac = new Kupac
			{
				Ime = "Ana",
				Prezime = "Jovanović",
				Email = "ana@mail.com",
				KontaktTelefon = "060123456",
				Mesto = new Mesto { PostanskiBroj = "11000", Naziv = "Beograd" }
			};

			// Act
			string values = kupac.Values;

			// Assert
			Assert.Equal("'Ana', 'Jovanović', 'ana@mail.com', '060123456', '11000'", values);
		}

		[Fact]
		public void UpdateValues_TrebaDaSadrziIspravanEmail()
		{
			var kupac = new Kupac
			{
				Ime = "Luka",
				Prezime = "Nikolić",
				Email = "luka@mail.com",
				KontaktTelefon = "065222333",
				Mesto = new Mesto { PostanskiBroj = "21000", Naziv = "Novi Sad" }
			};

			string update = kupac.UpdateValues;

			Assert.Contains("Email = 'luka@mail.com'", update);
		}

		[Fact]
		public void TableName_TrebaDaBudeKupac()
		{
			var kupac = new Kupac();
			Assert.Equal("Kupac", kupac.TableName);
		}

		[Fact]
		public void TableAlias_TrebaDaBudeK()
		{
			var kupac = new Kupac();
			Assert.Equal("k", kupac.TableAlias);
		}
	}
}

