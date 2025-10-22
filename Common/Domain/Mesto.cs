using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
	/// <summary>
	/// Domenska klasa koja predstavlja mesto (opština/grad) sa poštanskim brojem.
	/// </summary>
	public class Mesto : IEntity
	{
		/// <summary>Poštanski broj mesta (primarni ključ).</summary>
		public string PostanskiBroj { get; set; }

		/// <summary>Naziv mesta.</summary>
		public string Naziv { get; set; }

		/// <summary>Naziv tabele u bazi.</summary>
		public string TableName => "Mesto";

		/// <summary>
		/// Vrednosti za INSERT (PostanskiBroj, Naziv).
		/// </summary>
		public string Values => $"'{PostanskiBroj}', '{Naziv}'";

		/// <summary>WHERE uslov po poštanskom broju.</summary>
		public string WhereCondition => $"PostanskiBroj = '{PostanskiBroj}'";

		/// <summary>Nema posebnog COUNT uslova.</summary>
		public string CountWhereCondition => "";

		/// <summary>Nema JOIN-ova za Mesto.</summary>
		public string JoinTable => "";

		/// <summary>Nema dodatnog uslova (filtera) za SELECT.</summary>
		public string GetCondition => "";

		/// <summary>Nema UPDATE vrednosti (entitet se retko menja u ovoj implementaciji).</summary>
		public string UpdateValues => "";

		/// <summary>Alias tabele u upitima.</summary>
		public string TableAlias => "m";

		/// <summary>Kolona koja se vraća kao identifikator pri insertu.</summary>
		public string outputId => "PostanskiBroj";

		/// <summary>
		/// Mapira rezultate data reader-a u listu entiteta <see cref="Mesto"/>.
		/// </summary>
		/// <param name="reader">Reader sa kolonama: PostanskiBroj, Naziv.</param>
		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			var mesta = new List<IEntity>();
			while (reader.Read())
			{
				var m = new Mesto
				{
					PostanskiBroj = (string)reader["PostanskiBroj"],
					Naziv = (string)reader["Naziv"]
				};
				mesta.Add(m);
			}
			return mesta;
		}

		/// <summary>Ne koristi se jer je primarni ključ string (poštanski broj).</summary>
		public void setId(long id) { }

		/// <summary>Vraća naziv mesta.</summary>
		public override string? ToString() => Naziv;
	}
}
