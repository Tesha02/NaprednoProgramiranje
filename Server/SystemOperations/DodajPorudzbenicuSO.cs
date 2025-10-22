using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja dodaje novu porudžbenicu i sve njene stavke u bazu podataka.
	/// </summary>
	/// <remarks>
	/// Operacija se izvršava u okviru transakcije definisane u klasi <see cref="SystemOperationBase"/>.  
	/// Tok izvršavanja:
	/// <list type="number">
	/// <item><description>Kreira se novi zapis u tabeli <c>Porudzbenica</c> pomoću metode <see cref="DBBroker.Broker.Add"/>.</description></item>
	/// <item><description>Za svaku stavku iz kolekcije <see cref="Porudzbenica.StavkePorudzbenica"/> postavlja se referenca na novu porudžbenicu i dodaje se u tabelu <c>StavkaPorudzbenice</c>.</description></item>
	/// <item><description>Rezultat uspešne operacije čuva se u svojstvu <see cref="Result"/>.</description></item>
	/// </list>
	/// U slučaju greške, rollback mehanizam iz bazne klase automatski vraća transakciju i obezbeđuje konzistentnost podataka.
	/// </remarks>
	internal class DodajPorudzbenicuSO : SystemOperationBase
	{
		/// <summary>
		/// Porudžbenica koja se dodaje u bazu podataka.
		/// </summary>
		private readonly Porudzbenica porudzbenica;

		/// <summary>
		/// Rezultat operacije — porudžbenica koja je uspešno dodata u bazu (uključujući generisani Id).
		/// </summary>
		public Porudzbenica Result { get; set; }

		/// <summary>
		/// Inicijalizuje novu instancu sistemske operacije za dodavanje porudžbenice.
		/// </summary>
		/// <param name="p">Instanca porudžbenice sa svim pripadajućim stavkama koje treba sačuvati u bazi.</param>
		public DodajPorudzbenicuSO(Porudzbenica p)
		{
			porudzbenica = p;
		}

		/// <summary>
		/// Izvršava konkretno dodavanje porudžbenice i svih njenih stavki u bazu podataka.
		/// </summary>
		/// <remarks>
		/// <para>
		/// 1. Poziva <see cref="DBBroker.Broker.Add"/> za dodavanje glavnog entiteta <see cref="Porudzbenica"/>.  
		/// 2. Iterira kroz sve stavke iz <see cref="Porudzbenica.StavkePorudzbenica"/>, postavlja im referencu na porudžbenicu i dodaje ih u bazu.  
		/// 3. Nakon uspešnog dodavanja, rezultat se čuva u svojstvu <see cref="Result"/>.
		/// </para>
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			broker.Add(porudzbenica);

			foreach (StavkaPorudzbenice sp in porudzbenica.StavkePorudzbenica)
			{
				sp.Porudzbenica = porudzbenica;
				broker.Add(sp);
			}

			Result = porudzbenica;
		}
	}
}
