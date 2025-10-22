using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja ažurira postojeći artikal u bazi podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi šablon izvršavanja definisan u <see cref="SystemOperationBase"/>.
	/// Nakon otvaranja konekcije i započinjanja transakcije, poziva se metoda <c>Update</c> iz brokera
	/// kako bi se postojeći zapis u tabeli <c>Artikal</c> ažurirao novim vrednostima.
	/// </remarks>
	public class AzurirajArtikalSO : SystemOperationBase
	{
		/// <summary>
		/// Instanca artikla čije podatke treba ažurirati u bazi.
		/// </summary>
		private readonly Artikal a;

		/// <summary>
		/// Inicijalizuje novu instancu operacije za ažuriranje artikla.
		/// </summary>
		/// <param name="a">Artikal koji sadrži ažurirane vrednosti polja.</param>
		public AzurirajArtikalSO(Artikal a)
		{
			this.a = a;
		}

		/// <summary>
		/// Izvršava konkretnu operaciju ažuriranja artikla u bazi.
		/// </summary>
		/// <remarks>
		/// Poziva metodu <see cref="DBBroker.Broker.Update"/> i prosleđuje instancu artikla.
		/// Ako dođe do greške, šablon metode iz baze klase automatski obavlja rollback transakcije.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			broker.Update(a);
		}
	}
}
