using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja dodaje novi artikal u bazu podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija kreira novi zapis u tabeli <c>Artikal</c> korišćenjem metode <c>Add</c> iz klase <see cref="DBBroker.Broker"/>.
	/// Nakon uspešnog dodavanja, dodeljeni identifikator artikla čuva se u svojstvu <see cref="Result"/> radi dalje upotrebe.
	/// Operacija se izvršava u okviru transakcije definisane u <see cref="SystemOperationBase"/>, 
	/// što obezbeđuje da u slučaju greške dođe do rollback-a i očuvanja integriteta baze.
	/// </remarks>
	public class DodajArtikalSO : SystemOperationBase
	{
		/// <summary>
		/// Artikal koji se dodaje u bazu.
		/// </summary>
		private readonly Artikal artikal;

		/// <summary>
		/// Rezultat operacije — artikal koji je uspešno dodat u bazu (uključujući dodeljeni Id).
		/// </summary>
		public Artikal Result { get; set; }

		/// <summary>
		/// Inicijalizuje novu instancu operacije za dodavanje artikla.
		/// </summary>
		/// <param name="a">Instanca artikla koja treba da bude dodata u bazu.</param>
		public DodajArtikalSO(Artikal a)
		{
			artikal = a;
		}

		/// <summary>
		/// Izvršava konkretno dodavanje artikla u bazu podataka.
		/// </summary>
		/// <remarks>
		/// Poziva <see cref="DBBroker.Broker.Add"/> metodu i dodaje novi artikal u tabelu <c>Artikal</c>.  
		/// Nakon dodavanja, instanca sa dodeljenim Id-em dodeljuje se svojstvu <see cref="Result"/>.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			broker.Add(artikal);
			Result = artikal;
		}
	}
}
