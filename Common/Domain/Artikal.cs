using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
	public class Artikal : IEntity
	{
		public long Id { get; set; }
		public string Naziv { get; set; }
		public double Cena { get; set; }
		public Tip Tip { get; set; }

		public string TableName => "Artikal";
		public string Values => $"'{Naziv}', {Cena}, '{Tip}'";
		public string UpdateValues => $"Naziv = '{Naziv}', Cena = {Cena}, Tip = '{Tip}'";
		public string WhereCondition => $"Id = {Id}";
		public string CountWhereCondition => $"Naziv = '{Naziv}'";
		public string JoinTable => "";
		public string GetCondition => $"Tip = '{Tip.ToString()}'";
		public string TableAlias => "a";
		public string outputId => "Id";

		public override string? ToString()
		{
			return Naziv;
		}

		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			List<IEntity> artikli = new List<IEntity>();

			while (reader.Read())
			{
				Artikal artikal = new Artikal
				{
					Id = (long)reader["Id"],
					Naziv = (string)reader["Naziv"],
					Cena = (double)reader["Cena"],
					Tip = (Tip)Enum.Parse(typeof(Tip), (string)reader["Tip"])
				};

				artikli.Add(artikal);
			}

			return artikli;
		}

		public void setId(long id)
		{
			this.Id = id;
		}
	}
}
