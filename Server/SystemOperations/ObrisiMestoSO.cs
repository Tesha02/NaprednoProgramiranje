using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja briše određeno mesto iz baze podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija koristi metodu <see cref="DBBroker.Broker.Delete"/> kako bi iz baze uklonila zapis
	/// koji odgovara prosleđenom objektu tipa <see cref="Mesto"/>.  
	/// Izvršava se u okviru transakcije definisane u klasi <see cref="SystemOperationBase"/>,
	/// što omogućava automatski rollback u slučaju greške i očuvanje integriteta baze podataka.
	/// </remarks>
	internal class ObrisiMestoSO : SystemOperationBase
	{
		/// <summary>
		/// Instanca mesta koje se briše iz baze podataka.
		/// </summary>
		private readonly Mesto m;

		/// <summary>
		/// Inicijalizuje novu instancu operacije za brisanje mesta.
		/// </summary>
		/// <param name="mesto">Mesto koje treba da bude obrisano iz baze.</param>
		public ObrisiMestoSO(Mesto mesto)
		{
			m = mesto;
		}

		/// <summary>
		/// Izvršava konkretnu operaciju brisanja mesta iz baze podataka.
		/// </summary>
		/// <remarks>
		/// Poziva <see cref="DBBroker.Broker.Delete"/> metod i briše zapis iz tabele <c>Mesto</c> koji odgovara
		/// prosleđenom objektu <see cref="Mesto"/>.  
		/// Ako dođe do izuzetka, rollback mehanizam iz <see cref="SystemOperationBase"/> automatski poništava transakciju.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			broker.Delete(m);
		}
	}
}
