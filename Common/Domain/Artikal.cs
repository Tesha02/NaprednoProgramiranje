using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Common.Domain
{
	/// <summary>
	/// Domenska klasa koja predstavlja artikal (proizvod) u sistemu.
	/// </summary>
	public class Artikal : IEntity
	{
		/// <summary>Jedinstveni identifikator artikla.</summary>
		public long Id { get; set; }

		/// <summary>Naziv artikla (npr. "Volan golf 6").</summary>
		public string Naziv { get; set; }

		/// <summary>Cena artikla u dinarima.</summary>
		public double Cena { get; set; }

		/// <summary>Tip artikla (npr. Volan, Karoserija...).</summary>
		public Tip Tip { get; set; }

		/// <summary>Naziv tabele u bazi.</summary>
		public string TableName => "Artikal";

		/// <summary>
		/// Vrednosti za INSERT komandu.
		/// </summary>
		/// <example>
		/// "'Volan Golf 6', 25000, 'Volan'"
		/// </example>
		public string Values => $"'{Naziv}', {Cena}, '{Tip}'";

		/// <summary>
		/// Vrednosti za UPDATE komandu (SET deo).
		/// </summary>
		/// <example>
		/// "Naziv = 'Volan golf 6', Cena = 25000, Tip = 'Volan'"
		/// </example>
		public string UpdateValues => $"Naziv = '{Naziv}', Cena = {Cena}, Tip = '{Tip}'";

		/// <summary>WHERE uslov po Id-u.</summary>
		public string WhereCondition => $"Id = {Id}";

		/// <summary>WHERE uslov za COUNT (prebrojavanje po nazivu).</summary>
		public string CountWhereCondition => $"Naziv = '{Naziv}'";

		/// <summary>Nema JOIN-ova za Artikal.</summary>
		public string JoinTable => "";

		/// <summary>Opcioni dodatni uslov (filter) – ovde po tipu artikla.</summary>
		public string GetCondition => $"Tip = '{Tip.ToString()}'";

		/// <summary>Alias tabele u upitima.</summary>
		public string TableAlias => "a";

		/// <summary>Naziv kolone koja nosi novi Id pri insertu.</summary>
		public string outputId => "Id";

		/// <summary>
		/// Vra?a nazive artikla (?ita?ljiv prikaz).
		/// </summary>
		public override string? ToString() => Naziv;

		/// <summary>
		/// Mapira rezultate data reader-a u listu entiteta <see cref="Artikal"/>.
		/// </summary>
		/// <param name="reader">Otvoreni <see cref="SqlDataReader"/> sa kolonama: Id, Naziv, Cena, Tip.</param>
		/// <returns>Lista artikala kao <see cref="IEntity"/>.</returns>
		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			var artikli = new List<IEntity>();
			while (reader.Read())
			{
				var artikal = new Artikal
				{
					Id = (long)reader["Id"],
					Naziv = (string)reader["Naziv"],
					Cena = (double)reader["Cena"],
					Tip = (Tip)Enum.Parse(typeof(Tip), (string)reader["Tip"])
				};
				artikli.Add(artikal);
			}
			return artikli;
		}

		/// <summary>Postavlja vrednost identifikatora.</summary>
		public void setId(long id) => Id = id;
	}
}
