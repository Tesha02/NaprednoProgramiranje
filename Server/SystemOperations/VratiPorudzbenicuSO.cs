using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja vraća jednu porudžbenicu iz baze podataka, zajedno sa svim njenim stavkama.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <see cref="DBBroker.Broker.GetByCondition"/> za dohvat konkretne
	/// porudžbenice na osnovu prosleđenog kriterijuma (npr. Id porudžbenice).  
	/// Nakon što pronađe glavnu porudžbenicu, operacija dodatno preuzima sve njene povezane stavke
	/// tipa <see cref="StavkaPorudzbenice"/> i formira kompletan agregatni objekat.
	/// 
	/// <para>
	/// Ovim pristupom se omogućava da složeni entitet (porudžbenica + stavke) bude kompletno
	/// rekonstruisan iz baze podataka, što olakšava prikaz i dalju obradu u aplikaciji.
	/// </para>
	/// 
	/// Operacija se izvršava u okviru transakcije definisane u <see cref="SystemOperationBase"/>,
	/// čime se obezbeđuje kontrola pristupa bazi i rollback u slučaju greške.
	/// </remarks>
	internal class VratiPorudzbenicuSO : SystemOperationBase
	{
		/// <summary>
		/// Rezultat operacije — porudžbenica sa svim pripadajućim stavkama.
		/// </summary>
		public Porudzbenica Result { get; private set; }

		/// <summary>
		/// Porudžbenica koja sadrži kriterijume pretrage (npr. Id).
		/// </summary>
		public Porudzbenica p;

		/// <summary>
		/// Inicijalizuje novu instancu sistemske operacije za vraćanje konkretne porudžbenice.
		/// </summary>
		/// <param name="p">Objekat tipa <see cref="Porudzbenica"/> sa definisanim uslovom pretrage.</param>
		public VratiPorudzbenicuSO(Porudzbenica p)
		{
			this.p = p;
		}

		/// <summary>
		/// Izvršava konkretnu operaciju vraćanja porudžbenice i njenih stavki iz baze podataka.
		/// </summary>
		/// <remarks>
		/// Tok izvršavanja:
		/// <list type="number">
		/// <item><description>Preuzima porudžbenicu iz baze pomoću <see cref="DBBroker.Broker.GetByCondition"/>.</description></item>
		/// <item><description>Ukoliko porudžbenica ne postoji, baca izuzetak sa porukom <c>"Porudžbenica nije pronađena."</c>.</description></item>
		/// <item><description>Kreira „dummy“ stavku porudžbenice sa istim Id-jem kako bi se dohvatila lista njenih stavki.</description></item>
		/// <item><description>Povezuje pronađene stavke sa glavnim objektom porudžbenice i vraća kompletan agregat u <see cref="Result"/>.</description></item>
		/// </list>
		/// </remarks>
		/// <exception cref="Exception">
		/// Baca izuzetak ako porudžbenica sa zadatim uslovom nije pronađena u bazi.
		/// </exception>
		protected override void ExecuteConcreteOperation()
		{
			// 1. Pronađi glavnu porudžbenicu
			p = (Porudzbenica)broker.GetByCondition(p).FirstOrDefault();

			if (p == null)
				throw new Exception("Porudžbenica nije pronađena.");

			// 2. Dohvati sve stavke koje pripadaju porudžbenici
			StavkaPorudzbenice dummy = new StavkaPorudzbenice
			{
				Porudzbenica = p
			};

			List<IEntity> stavke = broker.GetByCondition(dummy);

			// 3. Poveži stavke sa glavnim objektom
			p.StavkePorudzbenica = stavke.Cast<StavkaPorudzbenice>().ToList();

			// 4. Vrati kompletan agregat
			Result = p;
		}
	}
}
