using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja ažurira postojeću porudžbenicu i njene stavke u bazi podataka.
	/// </summary>
	/// <remarks>
	/// Operacija se sastoji iz više koraka:
	/// <list type="number">
	/// <item><description>Ažurira osnovne podatke porudžbenice (datum, radnik, kupac, ukupna vrednost).</description></item>
	/// <item><description>Briše sve postojeće stavke koje su prethodno bile povezane sa porudžbenicom.</description></item>
	/// <item><description>Ponovo dodaje sve stavke koje su trenutno prisutne u listi <see cref="Porudzbenica.StavkePorudzbenica"/>.</description></item>
	/// </list>
	/// Ova implementacija obezbeđuje potpunu sinhronizaciju stavki porudžbenice sa trenutnim stanjem objekta u aplikaciji.
	/// Transakcioni šablon metode iz <see cref="SystemOperationBase"/> garantuje da će se u slučaju greške
	/// izvršiti rollback i baza ostati konzistentna.
	/// </remarks>
	internal class AzurirajPorudzbenicuSO : SystemOperationBase
	{
		/// <summary>
		/// Instanca porudžbenice koja se ažurira u bazi podataka.
		/// </summary>
		private readonly Porudzbenica p;

		/// <summary>
		/// Inicijalizuje novu instancu sistemske operacije za ažuriranje porudžbenice.
		/// </summary>
		/// <param name="p">Porudžbenica sa izmenjenim podacima i listom stavki.</param>
		public AzurirajPorudzbenicuSO(Porudzbenica p)
		{
			this.p = p;
		}

		/// <summary>
		/// Izvršava konkretno ažuriranje porudžbenice i njenih stavki u bazi.
		/// </summary>
		/// <remarks>
		/// Metoda najpre ažurira osnovne podatke porudžbenice pomoću <see cref="DBBroker.Broker.Update"/>.
		/// Zatim briše sve postojeće stavke povezane sa tom porudžbenicom pozivom <see cref="DBBroker.Broker.Delete"/>.
		/// Nakon toga dodaje sve stavke iz liste <see cref="Porudzbenica.StavkePorudzbenica"/> koristeći <see cref="DBBroker.Broker.Add"/>.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			broker.Update(p);
			broker.Delete(new StavkaPorudzbenice { Porudzbenica = p });

			foreach (StavkaPorudzbenice sp in p.StavkePorudzbenica)
			{
				sp.Porudzbenica = p;
				broker.Add(sp);
			}
		}
	}
}
