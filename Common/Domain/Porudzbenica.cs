using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Common.Domain
{
	/// <summary>
	/// Domenska klasa koja predstavlja porudžbenicu (period, kupac, radnik, ukupna vrednost).
	/// </summary>
	public class Porudzbenica : IEntity
	{
		/// <summary>Jedinstveni identifikator porudžbenice.</summary>
		public long Id { get; set; }

		/// <summary>Početni datum važenja porudžbenice.</summary>
		public DateOnly DatumOd { get; set; }

		/// <summary>Datum isteka važenja porudžbenice.</summary>
		public DateOnly DatumDo { get; set; }

		/// <summary>Ukupna vrednost porudžbenice.</summary>
		public float UkupnaVr { get; set; }

		/// <summary>Radnik odgovoran za porudžbenicu.</summary>
		public Radnik Radnik { get; set; }

		/// <summary>Kupac za kog je porudžbenica kreirana.</summary>
		public Kupac Kupac { get; set; }

		/// <summary>Stavke porudžbenice (artikli, količine).</summary>
		public List<StavkaPorudzbenice> StavkePorudzbenica { get; set; }

		/// <summary>Naziv tabele u bazi.</summary>
		public string TableName => "Porudzbenica";

		/// <summary>
		/// Vrednosti za INSERT (DatumOd, DatumDo, UkupnaVr, RadnikId, KupacId).
		/// </summary>
		public string Values => $"'{DatumOd:yyyy-MM-dd}', '{DatumDo:yyyy-MM-dd}', '{UkupnaVr}', '{Radnik?.Id}', '{Kupac?.Id}'";

		/// <summary>WHERE uslov po Id-u (sa aliasom tabele).</summary>
		public string WhereCondition => $"p.Id = {Id}";

		/// <summary>Prazan COUNT uslov.</summary>
		public string CountWhereCondition => "";

		/// <summary>JOIN-ovi ka tabelama Radnik, Kupac i Mesto (preko Kupca).</summary>
		public string JoinTable => $"INNER JOIN Radnik r ON p.RadnikId = r.Id INNER JOIN Kupac k ON p.KupacId = k.Id INNER JOIN Mesto m ON k.PostanskiBrojMesta = m.PostanskiBroj";

		/// <summary>Dodatni uslov (nije korišćen).</summary>
		public string GetCondition => "";

		/// <summary>
		/// Vrednosti za UPDATE (SET deo).
		/// </summary>
		public string UpdateValues => $"DatumOd = '{DatumOd}', DatumDo = '{DatumDo}', UkupnaVr = {UkupnaVr}, RadnikId = {Radnik?.Id}, KupacId = {Kupac?.Id}";

		/// <summary>Alias tabele u upitima.</summary>
		public string TableAlias => "p";

		/// <summary>Kolona sa identifikatorom prilikom inserta.</summary>
		public string outputId => $"Id";

		/// <summary>
		/// Mapira rezultate reader-a u listu <see cref="Porudzbenica"/> sa ugnježdenim <see cref="Radnik"/> i <see cref="Kupac"/>.
		/// </summary>
		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			var list = new List<IEntity>();
			while (reader.Read())
			{
				var p = new Porudzbenica
				{
					Id = reader.GetInt64(0),
					DatumOd = DateOnly.FromDateTime(reader.GetDateTime(1)),
					DatumDo = DateOnly.FromDateTime(reader.GetDateTime(2)),
					UkupnaVr = (float)reader.GetDouble(3),
					Radnik = new Radnik
					{
						Id = reader.GetInt64(6),
						Ime = reader.GetString(7),
						Prezime = reader.GetString(8),
						Email = reader.GetString(9),
						Kontakt = reader.GetString(10),
						KorisnickoIme = reader.GetString(11),
						Lozinka = reader.GetString(12).Trim()
					},
					Kupac = new Kupac
					{
						Id = reader.GetInt64(13),
						Ime = reader.GetString(14),
						Prezime = reader.GetString(15),
						Email = reader.GetString(16),
						KontaktTelefon = reader.GetString(17),
						Mesto = new Mesto
						{
							PostanskiBroj = reader.GetString(19),
							Naziv = reader.GetString(20)
						}
					},
					StavkePorudzbenica = new List<StavkaPorudzbenice>()
				};
				list.Add(p);
			}
			return list;
		}

		/// <summary>Postavlja vrednost identifikatora.</summary>
		public void setId(long id) => Id = id;
	}
}
