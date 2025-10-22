using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja vraća jednu stručnu spremu iz baze podataka na osnovu zadatog kriterijuma.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <see cref="DBBroker.Broker.GetByCondition"/> 
	/// za dohvat entiteta tipa <see cref="StrSprema"/> koji ispunjava uslove pretrage definisane u prosleđenom objektu.  
	/// 
	/// <para>
	/// Ukoliko postoji više rezultata, uzima se samo prvi pronađeni.  
	/// Ako ne postoji nijedan entitet koji ispunjava uslov, rezultat će biti <c>null</c>.
	/// </para>
	/// 
	/// Operacija se izvršava u okviru transakcije definisane u <see cref="SystemOperationBase"/>,
	/// što obezbeđuje sigurno otvaranje i zatvaranje konekcije, kao i rollback u slučaju greške.
	/// </remarks>
	internal class VratiStrSpremuSO : SystemOperationBase
	{
		/// <summary>
		/// Rezultat operacije — pronađena stručna sprema iz baze podataka.
		/// </summary>
		public StrSprema Result { get; private set; }

		/// <summary>
		/// Objekat koji sadrži kriterijume pretrage (npr. Id ili naziv stručne spreme).
		/// </summary>
		public StrSprema ss;

		/// <summary>
		/// Inicijalizuje novu instancu sistemske operacije za vraćanje stručne spreme.
		/// </summary>
		/// <param name="ss">Objekat <see cref="StrSprema"/> sa definisanim uslovom pretrage.</param>
		public VratiStrSpremuSO(StrSprema ss)
		{
			this.ss = ss;
		}

		/// <summary>
		/// Izvršava konkretnu operaciju vraćanja stručne spreme iz baze podataka.
		/// </summary>
		/// <remarks>
		/// Poziva metodu <see cref="DBBroker.Broker.GetByCondition"/> 
		/// i preuzima prvi rezultat koji odgovara zadatim kriterijumima pretrage.  
		/// Rezultat se čuva u svojstvu <see cref="Result"/>.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			Result = (StrSprema)broker.GetByCondition(ss).FirstOrDefault();
		}
	}
}
