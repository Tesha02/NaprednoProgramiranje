using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja vrši prijavu (logovanje) radnika na sistem.
	/// </summary>
	/// <remarks>
	/// Ova operacija proverava da li u bazi postoji radnik sa unetim korisničkim imenom i lozinkom.  
	/// Koristi metodu <see cref="DBBroker.Broker.GetByCondition"/> kako bi iz baze dohvatila sve entitete 
	/// koji zadovoljavaju uslove definisane u <see cref="Radnik.WhereCondition"/>.
	/// Ako korisnik postoji, rezultat operacije se čuva u svojstvu <see cref="Result"/>.  
	/// Ukoliko ne postoji nijedan radnik sa unetim kredencijalima, baca se izuzetak sa odgovarajućom porukom.
	/// </remarks>
	public class LoginSO : SystemOperationBase
	{
		/// <summary>
		/// Radnik čiji se kredencijali proveravaju prilikom prijave.
		/// </summary>
		private readonly Radnik r;

		/// <summary>
		/// Rezultat operacije — instanca radnika koji je uspešno prijavljen na sistem.
		/// </summary>
		public Radnik Result { get; set; }

		/// <summary>
		/// Inicijalizuje novu instancu sistemske operacije za prijavu radnika.
		/// </summary>
		/// <param name="r">Objekat tipa <see cref="Radnik"/> koji sadrži korisničko ime i lozinku za proveru.</param>
		public LoginSO(Radnik r)
		{
			this.r = r;
		}

		/// <summary>
		/// Izvršava konkretnu operaciju prijave radnika na sistem.
		/// </summary>
		/// <remarks>
		/// 1. Poziva <see cref="DBBroker.Broker.GetByCondition"/> kako bi preuzeo sve radnike koji ispunjavaju uslov.  
		/// 2. Rezultat se kastuje u listu radnika i preuzima se prvi odgovarajući zapis.  
		/// 3. Ako korisnik nije pronađen, baca se izuzetak sa porukom <c>"Ne postoji zaposleni sa unetim kredencijalima."</c>.
		/// </remarks>
		/// <exception cref="Exception">
		/// Bacanje izuzetka u slučaju da ne postoji korisnik sa unetim kredencijalima.
		/// </exception>
		protected override void ExecuteConcreteOperation()
		{
			List<IEntity> lista = broker.GetByCondition(r);

			Result = lista.Cast<Radnik>().FirstOrDefault();

			if (Result == null)
			{
				throw new Exception("Ne postoji zaposleni sa unetim kredencijalima.");
			}
		}
	}
}
