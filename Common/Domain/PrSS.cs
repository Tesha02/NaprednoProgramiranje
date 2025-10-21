using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
	public class PrSS : IEntity
	{
		public long RadnikId { get; set; }
		public long StrSpremaId { get; set; }
		public DateOnly DatumIzdavanja { get; set; }

		public Radnik Radnik { get; set; }
		public StrSprema StrSprema { get; set; }

		public string TableName => "PrSS";
		public string Values => $"'{RadnikId}', '{StrSpremaId}', '{DatumIzdavanja:yyyy-MM-dd}'";
		public string WhereCondition => "";
		public string CountWhereCondition => "";
		public string JoinTable => "";
		public string GetCondition => "";
		public string UpdateValues => "";
		public string TableAlias => "pr";
		public string outputId => "";

		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			List<IEntity> prSSi = new List<IEntity>();

			while (reader.Read())
			{
				PrSS prSS = new PrSS
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
						Lozinka = (string)reader["Lozinka"]
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

		public void setId(long id)
		{
			throw new NotImplementedException();
		}
	}
}
