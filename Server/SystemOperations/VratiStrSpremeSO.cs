using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja vraća listu svih stručnih sprema iz baze podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <see cref="DBBroker.Broker.GetAll"/> 
	/// kako bi iz baze podataka preuzela sve entitete tipa <see cref="StrSprema"/>.  
	/// Dobijeni rezultati se kastuju iz generičkog tipa <see cref="IEntity"/> u <see cref="StrSprema"/> 
	/// i vraćaju kao lista svih stručnih sprema.  
	/// 
	/// <para>
	/// Operacija se izvršava u okviru transakcije definisane u <see cref="SystemOperationBase"/>,
	/// koja obezbeđuje sigurno otvaranje konekcije, commit/rollback mehanizam i automatsko zatvaranje baze nakon izvršenja.
	/// </para>
	/// </remarks>
	internal class VratiStrSpremeSO : SystemOperationBase
	{
		/// <summary>
		/// Rezultat operacije — lista svih stručnih sprema iz baze podataka.
		/// </summary>
		public List<StrSprema> Result { get; set; }

		/// <summary>
		/// Izvršava konkretnu operaciju vraćanja svih stručnih sprema iz baze podataka.
		/// </summary>
		/// <remarks>
		/// 1. Poziva <see cref="DBBroker.Broker.GetAll"/> sa novim objektom <see cref="StrSprema"/>  
		/// kako bi preuzeo sve zapise iz tabele <c>StrSprema</c>.  
		/// 2. Kastuje rezultate iz <see cref="IEntity"/> u <see cref="StrSprema"/>.  
		/// 3. Rezultat konvertuje u listu i dodeljuje svojstvu <see cref="Result"/>.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetAll(new StrSprema()).Cast<StrSprema>().ToList();
		}
	}
}
