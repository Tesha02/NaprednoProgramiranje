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
		public string Naziv { get; set; }
		public string PostanskiBroj { get; set; }

		public string TableName => "Mesto";
		public string Values => $"'{PostanskiBroj}', '{Naziv}'";
		public string UpdateValues => "";
		public string WhereCondition => $"PostanskiBroj = '{PostanskiBroj}'";
		public string CountWhereCondition => $"Naziv = '{Naziv}'";
		public string JoinTable => "";
		public string GetCondition => "";
		public string TableAlias => "m";
		public string outputId => "PostanskiBroj";

		public override string? ToString()
		{
			return $"{Naziv}";
		}

		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			List<IEntity> mesta = new List<IEntity>();

			while (reader.Read())
			{
				Mesto mesto = new Mesto
				{
					
					Naziv = (string)reader["Naziv"],
					PostanskiBroj = (string)reader["PostanskiBroj"]
				};

				mesta.Add(mesto);
			}

			return mesta;
		}

		public void setId(long id)
		{
			
		}
	}
}
