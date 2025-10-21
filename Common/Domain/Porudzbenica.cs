using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
	public class Porudzbenica : IEntity
	{
		public long Id { get; set; }
		public DateOnly DatumOd { get; set; }
		public DateOnly DatumDo { get; set; }
		public float UkupnaVr { get; set; }
		public Radnik Radnik { get; set; }
		public Kupac Kupac { get; set; }
		public List<StavkaPorudzbenice> StavkePorudzbenica { get; set; }

		public string TableName => "Porudzbenica";
		public string Values =>
			$"'{DatumOd:yyyy-MM-dd}', '{DatumDo:yyyy-MM-dd}', '{UkupnaVr}', '{Radnik?.Id}', '{Kupac?.Id}'";
		public string WhereCondition => $"p.Id = {Id}";
		public string CountWhereCondition => "";
		public string JoinTable =>
			$"INNER JOIN Radnik r ON p.RadnikId = r.Id " +
			$"INNER JOIN Kupac k ON p.KupacId = k.Id " +
			$"INNER JOIN Mesto m ON k.PostanskiBrojMesta = m.PostanskiBroj";
		public string GetCondition => "";
		public string UpdateValues =>
			$"DatumOd = '{DatumOd}', " +
			$"DatumDo = '{DatumDo}', " +
			$"UkupnaVr = {UkupnaVr}, " +
			$"RadnikId = {Radnik?.Id}, " +
			$"KupacId = {Kupac?.Id}";
		public string TableAlias => "p";
		public string outputId => "Id";

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

					// SQL float → čitaj kao double pa kastuj u float
					UkupnaVr = (float)reader.GetDouble(3),

					Radnik = new Radnik
					{
						Id = reader.GetInt64(6),
						Ime = reader.GetString(7),
						Prezime = reader.GetString(8),
						Email = reader.GetString(9),
						Kontakt = reader.GetString(10),
						KorisnickoIme = reader.GetString(11),
						Lozinka = reader.GetString(12).Trim() // nchar(10) → ukloni praznine
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

		public void setId(long id)
		{
			Id = id;
		}
	}
}
