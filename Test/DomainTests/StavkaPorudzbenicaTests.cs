using Xunit;
using Common.Domain;

namespace Test.DomainTests
{
	/// <summary>
	/// Testovi za domensku klasu StavkaPorudzbenice.
	/// </summary>
	public class StavkaPorudzbeniceTests
	{
		[Theory]
		[InlineData(2, 1000.50, 2001.00, 1, 5, "'2', '1000.5', '2001', '1', '5'")]
		[InlineData(10, 500, 5000, 3, 7, "'10', '500', '5000', '3', '7'")]
		[InlineData(1, 250.75, 250.75, 8, 9, "'1', '250.75', '250.75', '8', '9'")]
		public void Values_TrebaDaVratiIspravanSQLString(
			long kolicina,
			double cenaStavke,
			double ukupnaCena,
			long porudzbenicaId,
			long artikalId,
			string ocekivano)
		{
			// Arrange
			var stavka = new StavkaPorudzbenice
			{
				Kolicina = kolicina,
				CenaStavke = cenaStavke,
				UkupnaCena = ukupnaCena,
				Porudzbenica = new Porudzbenica { Id = porudzbenicaId },
				Artikal = new Artikal { Id = artikalId }
			};

			// Act
			string rezultat = stavka.Values;

			// Assert
			Assert.Equal(ocekivano, rezultat);
		}

		[Theory]
		[InlineData(1, "PorudzbenicaId=1")]
		[InlineData(99, "PorudzbenicaId=99")]
		[InlineData(555, "PorudzbenicaId=555")]
		public void WhereCondition_TrebaDaVratiIspravanUslov(long porudzbenicaId, string ocekivano)
		{
			var stavka = new StavkaPorudzbenice
			{
				Porudzbenica = new Porudzbenica { Id=porudzbenicaId }
			};

			Assert.Equal(ocekivano, stavka.WhereCondition);
		}

		[Fact]
		public void UpdateValues_TrebaDaVratiIspravanSQLString()
		{
			// Arrange
			var stavka = new StavkaPorudzbenice
			{
				Kolicina = 3,
				CenaStavke = 1200.5,
				UkupnaCena = 3601.5,
				Porudzbenica = new Porudzbenica { Id = 2 },
				Artikal = new Artikal { Id = 4, Naziv="aa", Cena= 1200.5 }
			};

			string ocekivano =
				"Kolicina = 3, CenaStavke = 1200.5, UkupnaCena = 3601.5, PorudzbenicaId = 2, ArtikalId = 4";

			// Act
			string rezultat = stavka.UpdateValues;

			// Assert
			Assert.Equal(ocekivano, rezultat);
		}

		[Fact]
		public void TableName_TrebaDaBudeStavkaPorudzbenice()
		{
			var stavka = new StavkaPorudzbenice();
			Assert.Equal("StavkaPorudzbenice", stavka.TableName);
		}

		[Fact]
		public void TableAlias_TrebaDaBudeSP()
		{
			var stavka = new StavkaPorudzbenice();
			Assert.Equal("sp", stavka.TableAlias);
		}

		[Fact]
		public void OutputId_TrebaDaBudeId()
		{
			var stavka = new StavkaPorudzbenice();
			Assert.Equal("Id", stavka.outputId);
		}

		[Fact]
		public void JoinTable_TrebaDaVratiJoinArtikal()
		{
			var stavka = new StavkaPorudzbenice();
			Assert.Contains("join artikal a on sp.ArtikalId=a.Id", stavka.JoinTable);
		}

		[Fact]
		public void SetId_TrebaDaPostaviIspravanId()
		{
			var stavka = new StavkaPorudzbenice();
			stavka.setId(123);
			Assert.Equal(123, stavka.Id);
		}
	}
}
