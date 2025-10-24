using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja dodaje novo mesto u bazu podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <c>Add</c> iz klase <see cref="DBBroker.Broker"/> za kreiranje novog zapisa
	/// u tabeli <c>Mesto</c>. 
	/// Operacija se izvršava u okviru transakcije definisane u baznoj klasi <see cref="SystemOperationBase"/>,
	/// čime se obezbeđuje kontrola nad otvaranjem, potvrđivanjem i poništavanjem transakcije (rollback u slučaju greške).
	/// </remarks>
	public class DodajMestoSO : SystemOperationBase
	{
		/// <summary>
		/// Instanca mesta koje se dodaje u bazu podataka.
		/// </summary>
		private readonly Mesto mesto;

		/// <summary>
		/// Rezultat operacije — mesto koje je uspešno dodato u bazu (uključujući dodeljeni Id).
		/// </summary>
	

		/// <summary>
		/// Inicijalizuje novu instancu operacije za dodavanje mesta.
		/// </summary>
		/// <param name="m">Mesto koje treba da bude dodato u bazu.</param>
		public DodajMestoSO(Mesto m)
		{
			mesto = m;
		}

		/// <summary>
		/// Izvršava konkretno dodavanje mesta u bazu podataka.
		/// </summary>
		/// <remarks>
		/// Poziva metodu <see cref="DBBroker.Broker.Add"/> i dodaje novi zapis u tabelu <c>Mesto</c>.  
		/// Ako dođe do izuzetka, rollback mehanizam iz <see cref="SystemOperationBase"/> automatski poništava transakciju.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			broker.Add(mesto);
			
		}
	}
}
