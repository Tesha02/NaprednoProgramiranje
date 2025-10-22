using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja vraća jedan artikal iz baze podataka na osnovu zadatog uslova.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <see cref="DBBroker.Broker.GetByCondition"/> kako bi iz baze
	/// dohvatila entitet tipa <see cref="Artikal"/> koji zadovoljava uslove definisane u prosleđenom objektu <see cref="Artikal"/>.  
	/// Ukoliko postoji više rezultata, uzima se samo prvi pronađeni.  
	/// Operacija se izvršava u okviru transakcije obezbeđene od strane <see cref="SystemOperationBase"/>.
	/// </remarks>
	internal class VratiArtikalSO : SystemOperationBase
	{
		/// <summary>
		/// Rezultat operacije — instanca artikla koji je pronađen u bazi.
		/// </summary>
		public Artikal Result { get; set; }

		/// <summary>
		/// Artikal koji sadrži kriterijume pretrage (npr. Id, naziv, tip).
		/// </summary>
		public Artikal a;

		/// <summary>
		/// Inicijalizuje novu instancu sistemske operacije za vraćanje artikla iz baze.
		/// </summary>
		/// <param name="a">Artikal sa definisanim uslovima pretrage (npr. Id ili naziv).</param>
		public VratiArtikalSO(Artikal a)
		{
			this.a = a;
		}

		/// <summary>
		/// Izvršava konkretnu operaciju vraćanja artikla iz baze podataka.
		/// </summary>
		/// <remarks>
		/// Poziva metodu <see cref="DBBroker.Broker.GetByCondition"/> i preuzima prvi artikal
		/// koji odgovara uslovima pretrage definisanim u objektu <see cref="Artikal"/>.  
		/// Rezultat se čuva u svojstvu <see cref="Result"/>.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			Result = (Artikal)broker.GetByCondition(a).FirstOrDefault();
		}
	}
}
