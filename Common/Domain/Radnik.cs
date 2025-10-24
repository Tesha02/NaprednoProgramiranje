using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
	/// <summary>
	/// Domenska klasa koja predstavlja radnika (korisnika sistema) sa pristupnim podacima.
	/// </summary>
	public class Radnik : IEntity
	{
		private string ime;
		private string prezime;
		private string email;
		private string kontakt;
		private string korisnickoIme;
		private string lozinka;
		/// <summary>Jedinstveni identifikator radnika.</summary>
		public long Id { get; set; }

		/// <summary>Ime radnika.</summary>
		public string Ime { get; set; }

		/// <summary>Prezime radnika.</summary>
		public string Prezime { get; set; }

		/// <summary>Email radnika.</summary>
		public string Email { get; set; }

		/// <summary>Kontakt telefon radnika.</summary>
		public string Kontakt { get; set; }

		/// <summary>Korisničko ime za prijavu.</summary>
		public string KorisnickoIme
		{
			get => korisnickoIme;
			set
			{
				Validator.ValidateStrings(value, "Korisnicko ime radnika");
				korisnickoIme = value;
			}
		}

		/// <summary>Lozinka za prijavu (plain u ovoj implementaciji).</summary>
		public string Lozinka
		{
			get => lozinka;
			set
			{
				Validator.ValidateStrings(value, "Lozinka radnika");
				lozinka = value;
			}
		}

		/// <summary>Lista povezanih potvrda stručne spreme.</summary>
		public List<PrSS> PrSSi { get; set; }

		/// <summary>Naziv tabele u bazi.</summary>
		public string TableName => "Radnik";

		/// <summary>
		/// Vrednosti za INSERT (Ime, Prezime, Email, Kontakt, Korisničko ime, Lozinka).
		/// </summary>
		public string Values => $"'{Ime}', '{Prezime}', '{Email}', '{Kontakt}', '{KorisnickoIme}', '{Lozinka}'";

		/// <summary>WHERE uslov za autentikaciju (korisničko ime + lozinka).</summary>
		public string WhereCondition => $"KorisnickoIme = '{KorisnickoIme}' AND Lozinka = '{Lozinka}'";

		/// <summary>Prazan COUNT uslov (nije korišćen).</summary>
		public string CountWhereCondition => "";

		/// <summary>Nema JOIN-ova u ovoj klasi.</summary>
		public string JoinTable => "";

		/// <summary>Dodatni uslov (nije korišćen).</summary>
		public string GetCondition => "";

		/// <summary>Nema UPDATE vrednosti u ovoj implementaciji.</summary>
		public string UpdateValues => "";

		/// <summary>Alias tabele.</summary>
		public string TableAlias => "r";

		/// <summary>Kolona sa identifikatorom prilikom inserta.</summary>
		public string outputId => "Id";

		/// <summary>Vraća "Ime Prezime".</summary>
		public override string? ToString() => Ime + " " + Prezime;

		/// <summary>
		/// Mapira rezultate data reader-a u listu entiteta <see cref="Radnik"/>.
		/// </summary>
		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			var radnici = new List<IEntity>();
			while (reader.Read())
			{
				var radnik = new Radnik
				{
					Id = (long)reader["Id"],
					Ime = (string)reader["Ime"],
					Prezime = (string)reader["Prezime"],
					Email = (string)reader["Email"],
					Kontakt = (string)reader["Kontakt"],
					KorisnickoIme = (string)reader["KorisnickoIme"],
					Lozinka = (string)reader["Lozinka"]
				};
				radnici.Add(radnik);
			}
			return radnici;
		}

		/// <summary>Postavlja vrednost identifikatora.</summary>
		public void setId(long id) => Id = id;
	}
}
