using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Common.Domain
{
	public class StavkaPorudzbenice : IEntity
	{
		public long Id { get; set; }
		public long Kolicina { get; set; }
		public double CenaStavke { get; set; }
		public double UkupnaCena { get; set; }

		[JsonIgnore]
		public Porudzbenica Porudzbenica { get; set; }
		public Artikal Artikal { get; set; }

		public string TableName => "StavkaPorudzbenice";
		public string Values =>
			$"'{Kolicina}', '{CenaStavke}', '{UkupnaCena}', '{Porudzbenica?.Id}', '{Artikal?.Id}'";
		public string WhereCondition => $"PorudzbenicaId = {Porudzbenica.Id}";
		public string CountWhereCondition => "";
		public string JoinTable => "JOIN Artikal a ON sp.ArtikalId = a.Id";
		public string GetCondition => "";
		public string UpdateValues =>
			$"Kolicina = {Kolicina}, " +
			$"CenaStavke = {CenaStavke}, " +
			$"UkupnaCena = {UkupnaCena}, " +
			$"PorudzbenicaId = {Porudzbenica.Id}, " +
			$"ArtikalId = {Artikal.Id}";
		public string TableAlias => "sp";
		public string outputId => "Id";

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

					Porudzbenica = new Porudzbenica
					{
						Id = reader.GetInt64(5)
					},

					Artikal = new Artikal
					{
						Id = reader.GetInt64(6),
						Naziv = reader.GetString(7),
						Cena = reader.GetDouble(8),
						Tip = Enum.Parse<Tip>(reader.GetString(9))
					}
				};

				list.Add(s);
			}

			return list;
		}

		public void setId(long id)
		{
			Id = id;
		}
	}
}
