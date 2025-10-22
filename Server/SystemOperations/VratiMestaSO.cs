using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja vraća listu svih mesta iz baze podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <see cref="DBBroker.Broker.GetAll"/> 
	/// kako bi preuzela sve entitete tipa <see cref="Mesto"/> iz baze podataka.
	/// 
	/// <para>
	/// Dobijeni rezultati se kastuju iz tipa <see cref="IEntity"/> u <see cref="Mesto"/> i konvertuju u listu.  
	/// Operacija se izvršava u okviru transakcije definisane u <see cref="SystemOperationBase"/>, 
	/// što obezbeđuje pravilno otvaranje i zatvaranje konekcije, kao i rollback u slučaju greške.
	/// </para>
	/// </remarks>
	public class VratiMestaSO : SystemOperationBase
	{
		/// <summary>
		/// Rezultat operacije — lista svih mesta preuzetih iz baze podataka.
		/// </summary>
		public List<Mesto> Result { get; set; }

		/// <summary>
		/// Izvršava konkretnu operaciju vraćanja svih mesta iz baze podataka.
		/// </summary>
		/// <remarks>
		/// 1. Poziva metodu <see cref="DBBroker.Broker.GetAll"/> sa novim objektom <see cref="Mesto"/>  
		/// kako bi preuzeo sve zapise iz tabele <c>Mesto</c>.  
		/// 2. Kastuje rezultate iz <see cref="IEntity"/> u tip <see cref="Mesto"/>.  
		/// 3. Rezultate konvertuje u listu i dodeljuje svojstvu <see cref="Result"/>.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetAll(new Mesto()).Cast<Mesto>().ToList();
		}
	}
}
