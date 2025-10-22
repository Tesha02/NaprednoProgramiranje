using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja dodaje novog kupca u bazu podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <c>Add</c> iz klase <see cref="DBBroker.Broker"/> za kreiranje novog zapisa u tabeli <c>Kupac</c>.  
	/// Nakon uspešnog izvršavanja, dodeljeni identifikator (Id) i ostali podaci o kupcu čuvaju se u svojstvu <see cref="Result"/>.
	/// Operacija se izvršava u okviru transakcije definisane u baznoj klasi <see cref="SystemOperationBase"/>, 
	/// čime se obezbeđuje rollback u slučaju greške.
	/// </remarks>
	internal class DodajKupcaSO : SystemOperationBase
	{
		/// <summary>
		/// Instanca kupca koja se dodaje u bazu podataka.
		/// </summary>
		private readonly Kupac kupac;

		/// <summary>
		/// Rezultat operacije — kupac koji je uspešno dodat u bazu (uključujući dodeljeni Id).
		/// </summary>
		public Kupac Result { get; set; }

		/// <summary>
		/// Inicijalizuje novu instancu sistemske operacije za dodavanje kupca.
		/// </summary>
		/// <param name="k">Kupac koji treba da bude dodat u bazu.</param>
		public DodajKupcaSO(Kupac k)
		{
			kupac = k;
		}

		/// <summary>
		/// Izvršava konkretnu operaciju dodavanja kupca u bazu podataka.
		/// </summary>
		/// <remarks>
		/// Poziva <see cref="DBBroker.Broker.Add"/> metodu i dodaje kupca u tabelu <c>Kupac</c>.  
		/// Nakon dodavanja, rezultat operacije se dodeljuje svojstvu <see cref="Result"/>.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			broker.Add(kupac);
			Result = kupac;
		}
	}
}
