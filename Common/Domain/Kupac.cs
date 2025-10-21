
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Common.Domain 
{ public class Kupac : IEntity 
	{ public long Id { get; set; } 
		public string Ime { get; set; } 
		public string Prezime { get; set; } 
		public string Email { get; set; } 
		public string KontaktTelefon { get; set; } 
		public Mesto Mesto { get; set; } 
		public string TableName => "Kupac"; 
		public string TableAlias => "k"; 
		public string Values => $"'{Ime}', '{Prezime}', '{Email}', '{KontaktTelefon}', '{Mesto?.PostanskiBroj}'"; 
		public string WhereCondition => $"Id = {Id}"; 
		public string CountWhereCondition => ""; 
		public string JoinTable => $"JOIN Mesto m ON (k.PostanskiBrojMesta = m.PostanskiBroj)"; 
		public string GetCondition => ""; 
		public string UpdateValues => $"Ime = '{Ime}', Prezime = '{Prezime}', Email = '{Email}', KontaktTelefon = '{KontaktTelefon}', PostanskiBrojMesta = '{Mesto?.PostanskiBroj}'"; public string outputId => "Id"; 
		public override string? ToString() { 
			return Ime + " " + Prezime; 
		} 
		public List<IEntity> GetReaderList(SqlDataReader reader) { List<IEntity> kupci = new List<IEntity>();
			while (reader.Read()) { 
				Kupac kupac = new Kupac { 
					Id = (long)reader["Id"], 
					Ime = (string)reader["Ime"], 
					Prezime = (string)reader["Prezime"], 
					Email = (string)reader["Email"], 
					KontaktTelefon = (string)reader["KontaktTelefon"], 
					Mesto = new Mesto { 
						PostanskiBroj = (string)reader["PostanskiBroj"], 
						Naziv = (string)reader["Naziv"] } }; 
				kupci.Add(kupac); 
			} return kupci; } 
		public void setId(long id) { 
			Id = id; 
		} 
	} 
}