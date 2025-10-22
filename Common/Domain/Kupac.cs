using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
	/// <summary>
	/// Domenska klasa koja predstavlja kupca sa kontakt podacima i mestom.
	/// </summary>
	public class Kupac : IEntity
	{
		/// <summary>Jedinstveni identifikator kupca.</summary>
		public long Id { get; set; }

		/// <summary>Ime kupca.</summary>
		public string Ime { get; set; }

		/// <summary>Prezime kupca.</summary>
		public string Prezime { get; set; }

		/// <summary>Email adresa kupca.</summary>
		public string Email { get; set; }

		/// <summary>Kontakt telefon kupca.</summary>
		public string KontaktTelefon { get; set; }

		/// <summary>Mesto prebivališta kupca.</summary>
		public Mesto Mesto { get; set; }

		/// <summary>Naziv tabele u bazi.</summary>
		public string TableName => "Kupac";

		/// <summary>Alias tabele u upitima.</summary>
		public string TableAlias => "k";

		/// <summary>
		/// Vrednosti za INSERT (Ime, Prezime, Email, Kontakt, Poštanski broj mesta).
		/// </summary>
		public string Values => $"'{Ime}', '{Prezime}', '{Email}', '{KontaktTelefon}', '{Mesto?.PostanskiBroj}'";

		/// <summary>WHERE uslov po Id-u.</summary>
		public string WhereCondition => $"Id = {Id}";

		/// <summary>COUNT uslov (opciono, ovde prazan).</summary>
		public string CountWhereCondition => "";

		/// <summary>
		/// JOIN na tabelu <c>Mesto</c> po poštanskom broju.
		/// </summary>
		public string JoinTable => $"JOIN Mesto m ON (k.PostanskiBrojMesta = m.PostanskiBroj)";

		/// <summary>Dodatni uslov za SELECT (ovde prazan).</summary>
		public string GetCondition => "";

		/// <summary>
		/// Vrednosti za UPDATE (SET deo).
		/// </summary>
		public string UpdateValues => $"Ime = '{Ime}', Prezime = '{Prezime}', Email = '{Email}', KontaktTelefon = '{KontaktTelefon}', PostanskiBrojMesta = '{Mesto?.PostanskiBroj}'";

		/// <summary>Kolona sa identifikatorom prilikom inserta.</summary>
		public string outputId => "Id";

		/// <summary>Vraća "Ime Prezime".</summary>
		public override string? ToString() => Ime + " " + Prezime;

		/// <summary>
		/// Mapira rezultate data reader-a u listu entiteta <see cref="Kupac"/> sa pridruženim <see cref="Mesto"/>.
		/// </summary>
		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			var kupci = new List<IEntity>();
			while (reader.Read())
			{
				var kupac = new Kupac
				{
					Id = (long)reader["Id"],
					Ime = (string)reader["Ime"],
					Prezime = (string)reader["Prezime"],
					Email = (string)reader["Email"],
					KontaktTelefon = (string)reader["KontaktTelefon"],
					Mesto = new Mesto
					{
						PostanskiBroj = (string)reader["PostanskiBroj"],
						Naziv = (string)reader["Naziv"]
					}
				};
				kupci.Add(kupac);
			}
			return kupci;
		}

		/// <summary>Postavlja vrednost identifikatora.</summary>
		public void setId(long id) => Id = id;
	}
}
