using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Domain
{
	/// <summary>
	/// Domenska klasa koja predstavlja jednu stavku porudžbenice (artikl, količina i cene).
	/// </summary>
	public class StavkaPorudzbenice : IEntity
	{
		/// <summary>Identifikator stavke.</summary>
		public long Id { get; set; }

		/// <summary>Količina izabranog artikla.</summary>
		public long Kolicina { get; set; }

		/// <summary>Cena jedne stavke (po artiklu).</summary>
		public double CenaStavke { get; set; }

		/// <summary>Ukupna cena za stavku (količina * cena).</summary>
		public double UkupnaCena { get; set; }

		/// <summary>Porudžbenica kojoj stavka pripada.</summary>
		[JsonIgnore]
		public Porudzbenica Porudzbenica { get; set; }

		/// <summary>Povezani artikal.</summary>
		public Artikal Artikal { get; set; }

		/// <summary>Naziv tabele u bazi.</summary>
		public string TableName => "StavkaPorudzbenice";

		/// <summary>
		/// Vrednosti za INSERT (Kolicina, CenaStavke, UkupnaCena, PorudzbenicaId, ArtikalId).
		/// </summary>
		public string Values => $"'{Kolicina}', '{CenaStavke}', '{UkupnaCena}', '{Porudzbenica?.Id}', '{Artikal?.Id}'";

		/// <summary>WHERE uslov po Id-u porudžbenice (sve stavke jedne porudžbenice).</summary>
		public string WhereCondition => $"PorudzbenicaId={Porudzbenica.Id}";

		/// <summary>Prazan COUNT uslov.</summary>
		public string CountWhereCondition => "";

		/// <summary>JOIN na tabelu Artikal (po ArtikalId).</summary>
		public string JoinTable => $"join artikal a on sp.ArtikalId=a.Id";

		/// <summary>Dodatni uslov (nije korišćen).</summary>
		public string GetCondition => "";

		/// <summary>
		/// Vrednosti za UPDATE (SET deo).
		/// </summary>
		public string UpdateValues => $"Kolicina = {Kolicina}, CenaStavke = {CenaStavke}, UkupnaCena = {UkupnaCena}, PorudzbenicaId = {Porudzbenica.Id}, ArtikalId = {Artikal.Id}";

		/// <summary>Alias tabele u upitima.</summary>
		public string TableAlias => "sp";

		/// <summary>Kolona sa identifikatorom prilikom inserta.</summary>
		public string outputId => "Id";

		/// <summary>
		/// Mapira rezultate reader-a u listu <see cref="StavkaPorudzbenice"/> sa ugnježdenim <see cref="Artikal"/> i minimalnim <see cref="Porudzbenica"/>.
		/// </summary>
		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			var list = new List<IEntity>();
			while (reader.Read())
			{
				var s = new StavkaPorudzbenice
				{
					Id = reader.GetInt64(0),
					Kolicina = reader.GetInt64(1),
					CenaStavke = reader.GetDouble(2),
					UkupnaCena = reader.GetDouble(3),
					Artikal = new Artikal
					{
						Id = reader.GetInt64(6),
						Naziv = reader.GetString(7),
						Cena = reader.GetDouble(8),
						Tip = Enum.Parse<Tip>(reader.GetString(9))
					},
					Porudzbenica = new Porudzbenica
					{
						Id = reader.GetInt64(5)
					}
				};
				list.Add(s);
			}
			return list;
		}

		/// <summary>Postavlja vrednost identifikatora.</summary>
		public void setId(long id) => Id = id;
	}
}
