using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
	public class Mesto : IEntity
	{
		public long Id { get; set; }
		public string Naziv { get; set; }
		public string PostanskiBroj { get; set; }

		public string TableName => "Mesto";
		public string Values => $"'{Naziv}', '{PostanskiBroj}'";
		public string UpdateValues => $"Naziv = '{Naziv}', PostanskiBroj = '{PostanskiBroj}'";
		public string WhereCondition => $"Id = {Id}";
		public string CountWhereCondition => $"Naziv = '{Naziv}'";
		public string JoinTable => "";
		public string GetCondition => $"PostanskiBroj = '{PostanskiBroj}'";
		public string TableAlias => "m";
		public string outputId => "Id";

		public override string? ToString()
		{
			return $"{Naziv} ({PostanskiBroj})";
		}

		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			List<IEntity> mesta = new List<IEntity>();

			while (reader.Read())
			{
				Mesto mesto = new Mesto
				{
					Id = (long)reader["Id"],
					Naziv = (string)reader["Naziv"],
					PostanskiBroj = (string)reader["PostanskiBroj"]
				};

				mesta.Add(mesto);
			}

			return mesta;
		}

		public void setId(long id)
		{
			this.Id = id;
		}
	}
}
