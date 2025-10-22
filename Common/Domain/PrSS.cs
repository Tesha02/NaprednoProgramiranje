using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Common.Domain
{
	/// <summary>
	/// Povezni entitet koji opisuje potvrdu stručne spreme radnika (Radnik–StrSprema) sa datumom izdavanja.
	/// </summary>
	public class PrSS : IEntity
	{
		/// <summary>Identifikator radnika.</summary>
		public long RadnikId { get; set; }

		/// <summary>Identifikator stručne spreme.</summary>
		public long StrSpremaId { get; set; }

		/// <summary>Datum izdavanja potvrde.</summary>
		public DateOnly DatumIzdavanja { get; set; }

		/// <summary>Navigaciona referenca na radnika.</summary>
		public Radnik Radnik { get; set; }

		/// <summary>Navigaciona referenca na stručnu spremu.</summary>
		public StrSprema StrSprema { get; set; }

		/// <summary>Naziv tabele u bazi.</summary>
		public string TableName => "PrSS";

		/// <summary>Vrednosti za INSERT (RadnikId, StrSpremaId, DatumIzdavanja).</summary>
		public string Values => $"'{RadnikId}', '{StrSpremaId}', '{DatumIzdavanja:yyyy-MM-dd}'";

		/// <summary>WHERE uslov (nije definisan u ovoj implementaciji).</summary>
		public string WhereCondition => "";

		/// <summary>Prazan COUNT uslov.</summary>
		public string CountWhereCondition => "";

		/// <summary>Nema JOIN-ova u ovoj klasi (mapiranje se radi u GetReaderList po potrebi).</summary>
		public string JoinTable => "";

		/// <summary>Dodatni uslov (nije korišćen).</summary>
		public string GetCondition => "";

		/// <summary>Nema UPDATE vrednosti u ovoj implementaciji.</summary>
		public string UpdateValues => "";

		/// <summary>Alias tabele.</summary>
		public string TableAlias => "pr";

		/// <summary>PrSS nema jedinstveni numerički izlazni identifikator (kompozitni ključ).</summary>
		public string outputId => "";

		/// <summary>
		/// Mapira rezultate data reader-a u listu entiteta <see cref="PrSS"/> sa ugnježdenim <see cref="Radnik"/> i <see cref="StrSprema"/>.
		/// </summary>
		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			var prSSi = new List<IEntity>();
			while (reader.Read())
			{
				var prSS = new PrSS
				{
					RadnikId = (long)reader["radnikId"],
					StrSpremaId = (long)reader["strSpremaId"],
					DatumIzdavanja = DateOnly.FromDateTime((DateTime)reader["datumIzdavanja"]),
					Radnik = new Radnik
					{
						Id = (long)reader["Id"],
						Ime = (string)reader["Ime"],
						Prezime = (string)reader["Prezime"],
						Email = (string)reader["Email"],
						Kontakt = (string)reader["Kontakt"],
						KorisnickoIme = (string)reader["KorisnickoIme"],
						Lozinka = (string)reader["Lozinka"],
					},
					StrSprema = new StrSprema
					{
						Id = (long)reader["strSpremaId"],
						Naziv = (string)reader["strSpremaNaziv"],
						Opis = (string)reader["strSpremaOpis"]
					}
				};
				prSSi.Add(prSS);
			}
			return prSSi;
		}

		/// <summary>
		/// Nije implementirano jer entitet koristi kompozitni ključ (RadnikId+StrSpremaId).
		/// </summary>
		public void setId(long id) => throw new NotImplementedException();
	}
}
