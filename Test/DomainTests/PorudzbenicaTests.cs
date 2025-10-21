using Xunit;
using Common.Domain;
using System;
using Test.DomainTests;

namespace Test.DomainTests
{
	/// <summary>
	/// Testovi za domensku klasu Porudzbenica.
	/// </summary>
	public class PorudzbenicaTests
	{
		[Theory]
		[ClassData(typeof(PorudzbenicaTestData))]
		public void Values_TrebaDaVratiIspravanSQLString(Porudzbenica porudzbenica, string ocekivano)
		{
			// Act
			string rezultat = porudzbenica.Values;

			// Assert
			Assert.Equal(ocekivano, rezultat);
		}

		[Theory]
		[InlineData(5, "p.Id = 5")]
		[InlineData(123, "p.Id = 123")]
		public void WhereCondition_TrebaDaVratiIspravanUslov(long id, string ocekivano)
		{
			var p = new Porudzbenica { Id = id };
			Assert.Equal(ocekivano, p.WhereCondition);
		}

		[Fact]
		public void TableName_TrebaDaBudePorudzbenica()
		{
			var p = new Porudzbenica();
			Assert.Equal("Porudzbenica", p.TableName);
		}

		[Fact]
		public void TableAlias_TrebaDaBudeP()
		{
			var p = new Porudzbenica();
			Assert.Equal("p", p.TableAlias);
		}

		[Fact]
		public void OutputId_TrebaDaBudeId()
		{
			var p = new Porudzbenica();
			Assert.Equal("Id", p.outputId);
		}

		[Fact]
		public void JoinTable_TrebaDaSadrziSvePotrebneJoinove()
		{
			var p = new Porudzbenica();
			string join = p.JoinTable;

			Assert.Contains("INNER JOIN Radnik r ON p.RadnikId = r.Id", join);
			Assert.Contains("INNER JOIN Kupac k ON p.KupacId = k.Id", join);
			Assert.Contains("INNER JOIN Mesto m ON k.PostanskiBrojMesta = m.PostanskiBroj", join);
		}

		[Fact]
		public void UpdateValues_TrebaDaVratiIspravanSQLString()
		{
			var p = new Porudzbenica
			{
				DatumOd = new DateOnly(2025, 3, 1),
				DatumDo = new DateOnly(2025, 3, 2),
				UkupnaVr = 1234.56f,
				Radnik = new Radnik { Id = 9 },
				Kupac = new Kupac { Id = 15 }
			};

			string ocekivano = "DatumOd = '3/1/2025', DatumDo = '3/2/2025', UkupnaVr = 1234.56, RadnikId = 9, KupacId = 15";

			Assert.Equal(ocekivano, p.UpdateValues);
		}

		[Fact]
		public void SetId_TrebaDaPostaviId()
		{
			var p = new Porudzbenica();
			p.setId(999);
			Assert.Equal(999, p.Id);
		}
	}
}
