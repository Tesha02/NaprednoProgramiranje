using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
	public class Radnik : IEntity
	{
		public long Id { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Email { get; set; }
		public string Kontakt { get; set; }
		public string KorisnickoIme { get; set; }
		public string Lozinka { get; set; }
		public List<PrSS> PrSSi { get; set; }

		public string TableName => "Radnik";
		public string Values => $"'{Ime}', '{Prezime}', '{Email}', '{Kontakt}', '{KorisnickoIme}', '{Lozinka}'";
		public string WhereCondition => $"KorisnickoIme = '{KorisnickoIme}' AND Lozinka = '{Lozinka}'";
		public string CountWhereCondition => "";
		public string JoinTable => "";
		public string GetCondition => "";
		public string UpdateValues => "";
		public string TableAlias => "r";
		public string outputId => "Id";

		public override string? ToString()
		{
			return $"{Ime} {Prezime}";
		}

		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			List<IEntity> radnici = new List<IEntity>();

			while (reader.Read())
			{
				Radnik radnik = new Radnik
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

		public void setId(long id)
		{
			this.Id = id;
		}
	}
}
