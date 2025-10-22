using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja vraća listu svih porudžbenica iz baze podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <see cref="DBBroker.Broker.GetAll"/> za preuzimanje svih zapisa
	/// iz tabele <c>Porudzbenica</c>, uključujući i povezane entitete kao što su:
	/// <list type="bullet">
	/// <item><description><see cref="Radnik"/> – zaposleni koji je kreirao porudžbenicu,</description></item>
	/// <item><description><see cref="Kupac"/> – kupac za kojeg je porudžbenica kreirana,</description></item>
	/// <item><description><see cref="Mesto"/> – mesto prebivališta kupca.</description></item>
	/// </list>
	/// 
	/// <para>
	/// Zahvaljujući definisanom <see cref="Porudzbenica.JoinTable"/> svojstvu u domenskoj klasi,
	/// broker automatski izvršava potrebne SQL JOIN operacije kako bi se dobili svi relevantni podaci.
	/// </para>
	/// 
	/// Operacija se izvršava u okviru transakcije definisane u <see cref="SystemOperationBase"/>,
	/// što obezbeđuje rollback u slučaju greške i automatsko zatvaranje konekcije.
	/// </remarks>
	internal class VratiPorudzbeniceSO : SystemOperationBase
	{
		/// <summary>
		/// Rezultat operacije — lista svih porudžbenica iz baze podataka.
		/// </summary>
		public List<Porudzbenica> Result { get; set; }

		/// <summary>
		/// Izvršava konkretnu operaciju vraćanja svih porudžbenica iz baze podataka.
		/// </summary>
		/// <remarks>
		/// 1. Poziva <see cref="DBBroker.Broker.GetAll"/> sa novim objektom <see cref="Porudzbenica"/>  
		/// kako bi preuzeo sve zapise iz baze (uključujući relacije definisane JOIN-om).  
		/// 2. Kastuje rezultate iz <see cref="IEntity"/> u <see cref="Porudzbenica"/>.  
		/// 3. Rezultat konvertuje u listu i dodeljuje svojstvu <see cref="Result"/>.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetAll(new Porudzbenica()).Cast<Porudzbenica>().ToList();
		}
	}
}
