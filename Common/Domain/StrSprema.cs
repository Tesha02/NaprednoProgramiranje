using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
	/// <summary>
	/// Domenska klasa koja predstavlja nivo stručne spreme (npr. VSS, SSS...).
	/// </summary>
	public class StrSprema : IEntity
	{
		/// <summary>
		/// Zbog logicke kontrolore izdvajamo naziv u privatne promenljive
		/// </summary>
		private string naziv;
		/// <summary>Jedinstveni identifikator stručne spreme.</summary>
		public long Id { get; set; }

		/// <summary>Oznaka ili naziv (npr. "VSS").</summary>
		public string Naziv
		{
			get => naziv;
			set
			{
				if (value == null) return;
				Validator.ValidateStrings(value, "Naziv strucne spreme");
				naziv = value;
			}
		}

		/// <summary>Opis stručne spreme (opciono detaljnije).</summary>
		public string Opis { get; set; }

		/// <summary>Veze ka entitetima potvrde stručne spreme radnika.</summary>
		public List<PrSS> PrSSi { get; set; }

		/// <summary>Naziv tabele u bazi.</summary>
		public string TableName => "StrSprema";

		/// <summary>Vrednosti za INSERT (Naziv, Opis).</summary>
		public string Values => $"'{Naziv}', '{Opis}'";

		/// <summary>WHERE uslov po Id-u.</summary>
		public string WhereCondition => $"Id = {Id}";

		/// <summary>Prazan COUNT uslov.</summary>
		public string CountWhereCondition => "";

		/// <summary>Nema JOIN-ova u ovoj klasi.</summary>
		public string JoinTable => "";

		/// <summary>Dodatni uslov (nije korišćen).</summary>
		public string GetCondition => "";

		/// <summary>Vrednosti za UPDATE (Naziv, Opis).</summary>
		public string UpdateValues => $"Naziv = '{Naziv}', Opis = '{Opis}'";

		/// <summary>Alias tabele.</summary>
		public string TableAlias => "ss";

		/// <summary>Kolona sa identifikatorom prilikom inserta.</summary>
		public string outputId => "Id";

		/// <summary>
		/// Mapira rezultate data reader-a u listu entiteta <see cref="StrSprema"/>.
		/// </summary>
		public List<IEntity> GetReaderList(SqlDataReader reader)
		{
			var strSpreme = new List<IEntity>();
			while (reader.Read())
			{
				var strSprema = new StrSprema
				{
					Id = (long)reader["Id"],
					Naziv = (string)reader["Naziv"],
					Opis = (string)reader["Opis"]
				};
				strSpreme.Add(strSprema);
			}
			return strSpreme;
		}

		/// <summary>Postavlja vrednost identifikatora.</summary>
		public void setId(long id) => Id = id;
	}
}
