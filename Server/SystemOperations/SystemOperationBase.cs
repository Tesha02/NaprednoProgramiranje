using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Apstraktna bazna klasa za sve sistemske operacije u aplikaciji.
	/// </summary>
	/// <remarks>
	/// Ova klasa implementira **Template Method** dizajn šablon, koji definiše
	/// opšti tok izvršavanja svake sistemske operacije.  
	/// Konkretnu logiku (specifičnu za svaku operaciju) implementiraju izvedene klase
	/// kroz metod <see cref="ExecuteConcreteOperation"/>.
	/// 
	/// <para>
	/// Tok izvršavanja svake operacije uključuje:
	/// <list type="number">
	/// <item><description>Otvaranje konekcije ka bazi podataka.</description></item>
	/// <item><description>Pokretanje transakcije.</description></item>
	/// <item><description>Pozivanje konkretne implementacije operacije.</description></item>
	/// <item><description>Commit transakcije ako je operacija uspešna.</description></item>
	/// <item><description>Rollback u slučaju greške.</description></item>
	/// <item><description>Zatvaranje konekcije bez obzira na ishod.</description></item>
	/// </list>
	/// </para>
	/// 
	/// Ovakav pristup omogućava dosledno rukovanje transakcijama i greškama
	/// u svim sistemskim operacijama.
	/// </remarks>
	public abstract class SystemOperationBase
	{
		/// <summary>
		/// Instanca brokera koji omogućava komunikaciju sa bazom podataka.
		/// </summary>
		protected Broker broker;

		/// <summary>
		/// Inicijalizuje novu instancu sistemske operacije i kreira internu instancu brokera.
		/// </summary>
		public SystemOperationBase()
		{
			broker = new Broker();
		}

		/// <summary>
		/// Šablon metoda za izvršavanje sistemske operacije.
		/// </summary>
		/// <remarks>
		/// Obezbeđuje kontrolisano izvršavanje operacije kroz sledeće korake:
		/// <list type="number">
		/// <item><description>Otvara konekciju ka bazi pomoću <see cref="Broker.OpenConnection"/>.</description></item>
		/// <item><description>Pokreće transakciju pomoću <see cref="Broker.BeginTransaction"/>.</description></item>
		/// <item><description>Poziva metodu <see cref="ExecuteConcreteOperation"/> koja sadrži konkretan kod operacije.</description></item>
		/// <item><description>U slučaju uspeha, potvrđuje transakciju pozivom <see cref="Broker.Commit"/>.</description></item>
		/// <item><description>U slučaju greške, vrši <see cref="Broker.Rollback"/> i prosleđuje izuzetak dalje.</description></item>
		/// <item><description>Na kraju, zatvara konekciju pozivom <see cref="Broker.CloseConnection"/> bez obzira na ishod.</description></item>
		/// </list>
		/// </remarks>
		/// <exception cref="Exception">
		/// Baca izuzetak koji se dogodio tokom izvršavanja konkretne operacije.
		/// </exception>
		public void ExecuteTemplate()
		{
			try
			{
				broker.OpenConnection();
				broker.BeginTransaction();

				ExecuteConcreteOperation();

				broker.Commit();
			}
			catch (Exception ex)
			{
				broker.Rollback();
				throw;
			}
			finally
			{
				broker.CloseConnection();
			}
		}

		/// <summary>
		/// Apstraktna metoda koju implementiraju konkretne sistemske operacije.
		/// </summary>
		/// <remarks>
		/// Sadrži specifičnu logiku za svaku pojedinačnu operaciju (npr. dodavanje, brisanje, ažuriranje, vraćanje podataka).
		/// </remarks>
		protected abstract void ExecuteConcreteOperation();
	}
}
