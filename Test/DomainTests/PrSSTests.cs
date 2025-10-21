using Xunit;
using Common.Domain;
using System;

namespace Test.DomainTests
{
	/// <summary>
	/// Testovi za domensku klasu PrSS.
	/// </summary>
	public class PrSSTests
	{
		[Theory]
		[InlineData(1, 2, "2024-05-01", "'1', '2', '2024-05-01'")]
		[InlineData(10, 15, "2025-01-10", "'10', '15', '2025-01-10'")]
		[InlineData(99, 100, "2023-12-31", "'99', '100', '2023-12-31'")]
		public void Values_TrebaDaVratiIspravanSQLString(long radnikId, long strSpremaId, string datum, string ocekivano)
		{
			var prss = new PrSS
			{
				RadnikId = radnikId,
				StrSpremaId = strSpremaId,
				DatumIzdavanja = DateOnly.Parse(datum)
			};

			Assert.Equal(ocekivano, prss.Values);
		}

		[Fact]
		public void TableName_TrebaDaBudePrSS()
		{
			var prss = new PrSS();
			Assert.Equal("PrSS", prss.TableName);
		}

		[Fact]
		public void TableAlias_TrebaDaBudePR()
		{
			var prss = new PrSS();
			Assert.Equal("pr", prss.TableAlias);
		}

		[Fact]
		public void OutputId_TrebaDaBudePrazanString()
		{
			var prss = new PrSS();
			Assert.Equal(string.Empty, prss.outputId);
		}

		[Fact]
		public void WhereCondition_TrebaDaBudePrazanString()
		{
			var prss = new PrSS();
			Assert.Equal(string.Empty, prss.WhereCondition);
		}

		[Fact]
		public void JoinTable_TrebaDaBudePrazanString()
		{
			var prss = new PrSS();
			Assert.Equal(string.Empty, prss.JoinTable);
		}

		[Fact]
		public void UpdateValues_TrebaDaBudePrazanString()
		{
			var prss = new PrSS();
			Assert.Equal(string.Empty, prss.UpdateValues);
		}

		[Fact]
		public void SetId_TrebaDaBaciNotImplementedException()
		{
			var prss = new PrSS();
			Assert.Throws<NotImplementedException>(() => prss.setId(10));
		}
	}
}
