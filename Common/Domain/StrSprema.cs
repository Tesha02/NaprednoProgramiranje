using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
	public class StrSprema : IEntity
	{
		public long Id { get; set; }
		public string Naziv { get; set; }
		public string Opis { get; set; }
		public List<PrSS> PrSSi { get; set; }

		public string TableName => "StrSprema";
		public string Values => $"'{Naziv}', '{Opis}'";
		public string WhereCondition => $"Id = {Id}";
		public string CountWhereCondition => "";
		public string JoinTable => "";
		public string GetCondition => "";
		public string UpdateValues => $"Naziv = '{Naziv}', Opis = '{Opis}'";
		public string TableAlias => "ss";
		public string outputId => "Id";

		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			List<IEntity> strSpreme = new List<IEntity>();

			while (reader.Read())
			{
				StrSprema strSprema = new StrSprema
				{
					Id = (long)reader["Id"],
					Naziv = (string)reader["Naziv"],
					Opis = (string)reader["Opis"]
				};

				strSpreme.Add(strSprema);
			}

			return strSpreme;
		}

		public void setId(long id)
		{
			Id = id;
		}
	}
}
