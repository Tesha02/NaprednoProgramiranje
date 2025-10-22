using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja briše određenu stručnu spremu iz baze podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <see cref="DBBroker.Broker.Delete"/> kako bi obrisala zapis 
	/// koji odgovara prosleđenom objektu tipa <see cref="StrSprema"/> iz baze podataka.  
	/// Operacija se izvršava u okviru transakcije definisane u <see cref="SystemOperationBase"/>, 
	/// što obezbeđuje rollback u slučaju greške i očuvanje integriteta baze.
	/// </remarks>
	internal class ObrisiStrSpremuSO : SystemOperationBase
	{
		/// <summary>
		/// Instanca stručne spreme koja se briše iz baze podataka.
		/// </summary>
		private readonly StrSprema ss;

		/// <summary>
		/// Inicijalizuje novu instancu sistemske operacije za brisanje stručne spreme.
		/// </summary>
		/// <param name="strSprema">Objekat stručne spreme koji treba da bude obrisan iz baze.</param>
		public ObrisiStrSpremuSO(StrSprema strSprema)
		{
			ss = strSprema;
		}

		/// <summary>
		/// Izvršava konkretnu operaciju brisanja stručne spreme iz baze podataka.
		/// </summary>
		/// <remarks>
		/// Poziva metodu <see cref="DBBroker.Broker.Delete"/> i uklanja odgovarajući zapis iz tabele <c>StrSprema</c>.  
		/// U slučaju greške, rollback mehanizam iz <see cref="SystemOperationBase"/> poništava transakciju.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			broker.Delete(ss);
		}
	}
}
