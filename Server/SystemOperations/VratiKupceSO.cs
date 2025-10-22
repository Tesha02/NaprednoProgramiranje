using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja vraća listu svih kupaca iz baze podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <see cref="DBBroker.Broker.GetAll"/> kako bi iz baze podataka
	/// preuzela sve zapise tipa <see cref="Kupac"/> i vratila ih kao listu objekata.  
	/// Dobijeni rezultati se kastuju iz <see cref="IEntity"/> u tip <see cref="Kupac"/>.
	/// 
	/// <para>
	/// Operacija se izvršava u okviru transakcije definisane u <see cref="SystemOperationBase"/>,  
	/// što obezbeđuje da se svaka interakcija sa bazom obavi sigurno — sa automatskim commit/rollback mehanizmom.
	/// </para>
	/// </remarks>
	internal class VratiKupceSO : SystemOperationBase
	{
		/// <summary>
		/// Rezultat operacije — lista svih kupaca iz baze podataka.
		/// </summary>
		public List<Kupac> Result { get; set; }

		/// <summary>
		/// Izvršava konkretnu operaciju vraćanja svih kupaca iz baze podataka.
		/// </summary>
		/// <remarks>
		/// 1. Poziva metodu <see cref="DBBroker.Broker.GetAll"/> sa novim objektom <see cref="Kupac"/>  
		/// kako bi preuzeo sve zapise iz tabele <c>Kupac</c>.  
		/// 2. Kastuje rezultat u tip <see cref="Kupac"/> i konvertuje ga u listu.  
		/// 3. Rezultat dodeljuje svojstvu <see cref="Result"/>.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetAll(new Kupac()).Cast<Kupac>().ToList();
		}
	}
}
