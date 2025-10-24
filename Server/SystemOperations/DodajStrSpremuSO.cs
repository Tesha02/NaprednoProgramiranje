using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja dodaje novu stručnu spremu u bazu podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija nasleđuje <see cref="SystemOperationBase"/> i implementira konkretno ponašanje
	/// za dodavanje entiteta <see cref="StrSprema"/> u tabelu <c>StrSprema</c> korišćenjem metode <see cref="DBBroker.Broker.Add"/>.
	/// Tokom izvršavanja, operacija se sprovodi u okviru transakcije koju obezbeđuje bazna klasa — 
	/// što garantuje rollback u slučaju greške i očuvanje konzistentnosti baze podataka.
	/// </remarks>
	internal class DodajStrSpremuSO : SystemOperationBase
	{
		/// <summary>
		/// Instanca stručne spreme koja se dodaje u bazu podataka.
		/// </summary>
		private readonly StrSprema strSprema;

		/// <summary>
		/// Rezultat operacije — strucna sprema koja je uspešno dodata u bazu (uključujući dodeljeni Id).
		/// </summary>
		public StrSprema Result;

		/// <summary>
		/// Inicijalizuje novu instancu operacije za dodavanje stručne spreme.
		/// </summary>
		/// <param name="ss">Objekat tipa <see cref="StrSprema"/> koji treba da bude dodat u bazu.</param>
		public DodajStrSpremuSO(StrSprema ss)
		{
			strSprema = ss;
		}

		/// <summary>
		/// Izvršava konkretno dodavanje stručne spreme u bazu podataka.
		/// </summary>
		/// <remarks>
		/// Poziva metodu <see cref="DBBroker.Broker.Add"/> i dodaje novi zapis u tabelu <c>StrSprema</c>.  
		/// Ako dođe do greške, rollback mehanizam iz <see cref="SystemOperationBase"/> automatski poništava transakciju.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			broker.Add(strSprema);
			Result = strSprema;
		}
	}
}
