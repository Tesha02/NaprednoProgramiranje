using Common.Domain;
using Xunit;

namespace Test.DomainTests
{
	/// <summary>
	/// Testovi za domensku klasu Artikal.
	/// </summary>
	public class ArtikalTests
	{
		[Fact]
		public void ToString_TrebaDaVratiNazivArtikla()
		{
			// Arrange
			var artikal = new Artikal { Naziv = "Tastatura" };

			// Act
			string rezultat = artikal.ToString();

			// Assert
			Assert.Equal("Tastatura", rezultat);
		}

		[Fact]
		public void Values_TrebaDaVratiIspravanSQLString()
		{
			// Arrange
			var artikal = new Artikal
			{
				Naziv = "Volan golf 6",
				Cena = 24999.99,
				Tip = Tip.VOLAN
			};

			// Act
			string values = artikal.Values;

			// Assert
			Assert.Equal("'Volan golf 6', 24999.99, 'VOLAN'", values);
		}

		[Fact]
		public void UpdateValues_TrebaDaVratiIspravanSQLString()
		{
			// Arrange
			var artikal = new Artikal
			{
				Naziv = "Clio",
				Cena = 1999.50,
				Tip = Tip.KAROSERIJA
			};

			// Act
			string updateValues = artikal.UpdateValues;

			// Assert
			Assert.Equal("Naziv = 'Clio', Cena = 1999.5, Tip = 'KAROSERIJA'", updateValues);
		}

		[Fact]
		public void WhereCondition_TrebaDaVratiIspravanIdUslov()
		{
			var artikal = new Artikal { Id = 10 };
			Assert.Equal("Id = 10", artikal.WhereCondition);
		}

		[Fact]
		public void CountWhereCondition_TrebaDaVratiIspravanNaziv()
		{
			var artikal = new Artikal { Naziv = "Štampač" };
			Assert.Equal("Naziv = 'Štampač'", artikal.CountWhereCondition);
		}

		[Fact]
		public void GetCondition_TrebaDaVratiIspravanTip()
		{
			var artikal = new Artikal { Tip = Tip.TOCKOVI };
			Assert.Equal("Tip = 'TOCKOVI'", artikal.GetCondition);
		}

		[Fact]
		public void TableName_TrebaDaBudeArtikal()
		{
			var artikal = new Artikal();
			Assert.Equal("Artikal", artikal.TableName);
		}

		[Fact]
		public void TableAlias_TrebaDaBudeA()
		{
			var artikal = new Artikal();
			Assert.Equal("a", artikal.TableAlias);
		}

		[Fact]
		public void OutputId_TrebaDaBudeId()
		{
			var artikal = new Artikal();
			Assert.Equal("Id", artikal.outputId);
		}

		[Fact]
		public void SetId_TrebaDaPostaviId()
		{
			var artikal = new Artikal();
			artikal.setId(123);

			Assert.Equal(123, artikal.Id);
		}
	}
}
