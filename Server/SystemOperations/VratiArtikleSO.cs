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
	/// Sistem operacija koja vraća sve artikle iz baze podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <see cref="DBBroker.Broker.GetAll"/> za preuzimanje svih entiteta tipa <see cref="Artikal"/> iz baze podataka.  
	/// Dobijeni rezultati se kastuju u listu artikala i čuvaju u instanci <see cref="BindingList{T}"/>,
	/// što omogućava jednostavno povezivanje sa grafičkim interfejsom (npr. <c>DataGridView</c> kontrolama u WinForms aplikaciji).
	/// 
	/// <para>
	/// Operacija se izvršava u okviru transakcije definisane u <see cref="SystemOperationBase"/>,  
	/// koja obezbeđuje kontrolu konekcije, commit/rollback i zatvaranje baze u slučaju greške.
	/// </para>
	/// </remarks>
	internal class VratiArtikleSO : SystemOperationBase
	{
		/// <summary>
		/// Rezultat operacije — kolekcija svih artikala iz baze podataka.
		/// </summary>
		/// <remarks>
		/// Tip <see cref="BindingList{Artikal}"/> omogućava automatsko osvežavanje podataka u korisničkom interfejsu
		/// kada se lista menja (npr. dodavanje, ažuriranje, brisanje redova).
		/// </remarks>
		public BindingList<Artikal> Result { get; set; }

		/// <summary>
		/// Izvršava konkretnu operaciju vraćanja svih artikala iz baze podataka.
		/// </summary>
		/// <remarks>
		/// 1. Poziva <see cref="DBBroker.Broker.GetAll"/> sa novim objektom <see cref="Artikal"/>  
		/// kako bi preuzeo sve zapise iz tabele <c>Artikal</c>.  
		/// 2. Rezultate kastuje iz <see cref="IEntity"/> u <see cref="Artikal"/>.  
		/// 3. Kreira <see cref="BindingList{Artikal}"/> koja se prosleđuje GUI sloju.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			var list = broker.GetAll(new Artikal()); // vraća List<IEntity>
			Result = new BindingList<Artikal>(list.Cast<Artikal>().ToList());
		}
	}
}
