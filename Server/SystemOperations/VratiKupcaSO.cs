using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja vraća jednog kupca iz baze podataka na osnovu zadatog uslova.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <see cref="DBBroker.Broker.GetByCondition"/> kako bi iz baze dohvatila
	/// entitet tipa <see cref="Kupac"/> koji ispunjava kriterijume zadate kroz prosleđeni objekat <see cref="Kupac"/>.  
	/// Ukoliko postoji više rezultata, uzima se samo prvi pronađeni.  
	/// Operacija se izvršava u okviru transakcije obezbeđene od strane klase <see cref="SystemOperationBase"/>,
	/// što osigurava pravilno rukovanje konekcijom i rollback u slučaju greške.
	/// </remarks>
	internal class VratiKupcaSO : SystemOperationBase
	{
		/// <summary>
		/// Rezultat operacije — kupac koji je pronađen u bazi podataka.
		/// </summary>
		public Kupac Result { get; private set; }

		/// <summary>
		/// Kupac koji sadrži uslove pretrage (npr. Id, email ili ime).
		/// </summary>
		public Kupac k;

		/// <summary>
		/// Inicijalizuje novu instancu sistemske operacije za vraćanje kupca.
		/// </summary>
		/// <param name="k">Kupac sa definisanim kriterijumima pretrage (npr. Id ili email).</param>
		public VratiKupcaSO(Kupac k)
		{
			this.k = k;
		}

		/// <summary>
		/// Izvršava konkretnu operaciju vraćanja kupca iz baze podataka.
		/// </summary>
		/// <remarks>
		/// Poziva <see cref="DBBroker.Broker.GetByCondition"/> metodu i preuzima prvi rezultat
		/// koji odgovara zadatom uslovu iz objekta <see cref="Kupac"/>.  
		/// Rezultat se čuva u svojstvu <see cref="Result"/>.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			Result = (Kupac)broker.GetByCondition(k).FirstOrDefault();
		}
	}
}
