using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja vraća listu artikala iz baze podataka na osnovu tipa artikla.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <see cref="DBBroker.Broker.GetByCondition"/> 
	/// kako bi iz baze preuzela sve zapise tipa <see cref="Artikal"/> koji zadovoljavaju određeni kriterijum tipa.
	/// 
	/// <para>
	/// Tip artikla obično je određen kroz svojstvo <see cref="Artikal.Tip"/> u prosleđenom objektu.  
	/// Međutim, u ovoj implementaciji, objekat <see cref="Artikal"/> se koristi kao parametar za opšti upit 
	/// koji vraća sve artikle (moguće je dodatno proširiti da koristi konkretan filter po tipu).
	/// </para>
	/// 
	/// Operacija se izvršava u okviru transakcije definisane u baznoj klasi <see cref="SystemOperationBase"/>,
	/// čime se obezbeđuje rollback u slučaju greške i konzistentno zatvaranje konekcije.
	/// </remarks>
	internal class VratiArtiklePoTipuSO : SystemOperationBase
	{
		/// <summary>
		/// Lista artikala koji su vraćeni iz baze podataka.
		/// </summary>
		public List<Artikal> Result { get; set; }

		/// <summary>
		/// Izvršava konkretnu operaciju vraćanja artikala na osnovu tipa.
		/// </summary>
		/// <remarks>
		/// Poziva metodu <see cref="DBBroker.Broker.GetByCondition"/> sa novim objektom <see cref="Artikal"/>  
		/// i kastuje rezultat u listu tipa <see cref="Artikal"/>.  
		/// U aktuelnoj implementaciji vraća sve artikle, ali se lako može proširiti tako da filtrira po tipu.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetByCondition(new Artikal()).Cast<Artikal>().ToList();
		}
	}
}
