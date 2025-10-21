using Xunit;
using Common.Domain;

namespace Test.DomainTests
{
	/// <summary>
	/// Testovi za domensku klasu StrSprema.
	/// </summary>
	public class StrSpremaTests
	{
		[Theory]
		[InlineData("SSS", "Srednja stručna sprema", "'SSS', 'Srednja stručna sprema'")]
		[InlineData("VSS", "Visoka stručna sprema", "'VSS', 'Visoka stručna sprema'")]
		[InlineData("OSS", "Osnovna škola", "'OSS', 'Osnovna škola'")]
		public void Values_TrebaDaVratiIspravanSQLString(string naziv, string opis, string ocekivano)
		{
			// Arrange
			var ss = new StrSprema { Naziv = naziv, Opis = opis };

			// Act
			string rezultat = ss.Values;

			// Assert
			Assert.Equal(ocekivano, rezultat);
		}

		[Theory]
		[InlineData(1, "Id = 1")]
		[InlineData(5, "Id = 5")]
		[InlineData(999, "Id = 999")]
		public void WhereCondition_TrebaDaVratiIspravanUslov(long id, string ocekivano)
		{
			var ss = new StrSprema { Id = id };
			Assert.Equal(ocekivano, ss.WhereCondition);
		}

		[Theory]
		[InlineData("VKV", "Viši kvalifikovani radnik", "Naziv = 'VKV', Opis = 'Viši kvalifikovani radnik'")]
		[InlineData("PKV", "Polukvalifikovani radnik", "Naziv = 'PKV', Opis = 'Polukvalifikovani radnik'")]
		public void UpdateValues_TrebaDaVratiIspravanSQLString(string naziv, string opis, string ocekivano)
		{
			var ss = new StrSprema { Naziv = naziv, Opis = opis };
			Assert.Equal(ocekivano, ss.UpdateValues);
		}

		[Fact]
		public void TableName_TrebaDaBudeStrSprema()
		{
			var ss = new StrSprema();
			Assert.Equal("StrSprema", ss.TableName);
		}

		[Fact]
		public void TableAlias_TrebaDaBudeSS()
		{
			var ss = new StrSprema();
			Assert.Equal("ss", ss.TableAlias);
		}

		[Fact]
		public void OutputId_TrebaDaBudeId()
		{
			var ss = new StrSprema();
			Assert.Equal("Id", ss.outputId);
		}

		[Fact]
		public void JoinTable_TrebaDaBudePrazanString()
		{
			var ss = new StrSprema();
			Assert.Equal(string.Empty, ss.JoinTable);
		}

		[Fact]
		public void SetId_TrebaDaPostaviVrednostId()
		{
			var ss = new StrSprema();
			ss.setId(42);
			Assert.Equal(42, ss.Id);
		}
	}
}
