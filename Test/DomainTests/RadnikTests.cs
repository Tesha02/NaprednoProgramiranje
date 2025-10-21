using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DomainTests
{
	public class RadnikTests
	{
		public static IEnumerable<object[]> RadnikPodaci =>
			new List<object[]>
			{
				new object[] { new Radnik { Ime = "Marko", Prezime = "Petrović" }, "Marko Petrović" },
				new object[] { new Radnik { Ime = "Jelena", Prezime = "Jović" }, "Jelena Jović" },
				new object[] { new Radnik { Ime = "Stefan", Prezime = "Nikolić" }, "Stefan Nikolić" }
			};

		[Theory]
		[MemberData(nameof(RadnikPodaci))]
		public void ToString_TrebaDaVratiIspravnoImeIPrezime(Radnik radnik, string ocekivano)
		{
			// Act
			string rezultat = radnik.ToString();

			// Assert
			Assert.Equal(ocekivano, rezultat);
		}

		[Theory]
		[InlineData("Mika", "Mikić", "mika@mail.com", "063111222", "mika123", "lozinka",
					"'Mika', 'Mikić', 'mika@mail.com', '063111222', 'mika123', 'lozinka'")]
		[InlineData("Ana", "Anić", "ana@mail.com", "061555666", "ana123", "pass123",
					"'Ana', 'Anić', 'ana@mail.com', '061555666', 'ana123', 'pass123'")]
		public void Values_TrebaDaVratiIspravanSQLString(string ime, string prezime, string email, string kontakt, string korisnickoIme, string lozinka, string ocekivano)
		{
			var radnik = new Radnik
			{
				Ime = ime,
				Prezime = prezime,
				Email = email,
				Kontakt = kontakt,
				KorisnickoIme = korisnickoIme,
				Lozinka = lozinka
			};

			Assert.Equal(ocekivano, radnik.Values);
		}

		[Theory]
		[InlineData("pera123", "lozinka123")]
		[InlineData("mika321", "tajna")]
		public void WhereCondition_TrebaDaVratiIspravanUslov(string korisnickoIme, string lozinka)
		{
			var radnik = new Radnik { KorisnickoIme = korisnickoIme, Lozinka = lozinka };

			string ocekivano = $"KorisnickoIme = '{korisnickoIme}' AND Lozinka = '{lozinka}'";
			Assert.Equal(ocekivano, radnik.WhereCondition);
		}

		[Fact]
		public void TableName_TrebaDaBudeRadnik()
		{
			var radnik = new Radnik();
			Assert.Equal("Radnik", radnik.TableName);
		}

		[Fact]
		public void TableAlias_TrebaDaBudeR()
		{
			var radnik = new Radnik();
			Assert.Equal("r", radnik.TableAlias);
		}

		[Fact]
		public void OutputId_TrebaDaBudeId()
		{
			var radnik = new Radnik();
			Assert.Equal("Id", radnik.outputId);
		}

		[Fact]
		public void SetId_TrebaDaPostaviId()
		{
			var radnik = new Radnik();
			radnik.setId(77);
			Assert.Equal(77, radnik.Id);
		}
	}

}
