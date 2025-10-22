using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja briše porudžbenicu i sve njene stavke iz baze podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija obezbeđuje konzistentno brisanje složenog entiteta <see cref="Porudzbenica"/>, 
	/// zajedno sa svim pripadajućim stavkama (<see cref="StavkaPorudzbenice"/>), kako bi se izbeglo
	/// narušavanje referencijalnog integriteta baze podataka.  
	/// Izvršava se u okviru transakcije definisane u baznoj klasi <see cref="SystemOperationBase"/>,
	/// čime se obezbeđuje rollback u slučaju greške.
	/// </remarks>
	internal class ObrisiPorudzbenicuSO : SystemOperationBase
	{
		/// <summary>
		/// Porudžbenica koja se briše iz baze podataka.
		/// </summary>
		private readonly Porudzbenica p;

		/// <summary>
		/// Inicijalizuje novu instancu sistemske operacije za brisanje porudžbenice.
		/// </summary>
		/// <param name="p">Porudžbenica koja treba da bude obrisana iz baze podataka.</param>
		public ObrisiPorudzbenicuSO(Porudzbenica p)
		{
			this.p = p;
		}

		/// <summary>
		/// Izvršava konkretnu operaciju brisanja porudžbenice i njenih stavki iz baze podataka.
		/// </summary>
		/// <remarks>
		/// Tok izvršavanja:
		/// <list type="number">
		/// <item><description>Prvo se brišu sve stavke iz tabele <c>StavkaPorudzbenice</c> koje pripadaju datoj porudžbenici.</description></item>
		/// <item><description>Nakon toga se briše sama porudžbenica iz tabele <c>Porudzbenica</c>.</description></item>
		/// </list>
		/// Ovaj redosled obezbeđuje ispravno održavanje stranih ključeva i integriteta podataka.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			broker.Delete(new StavkaPorudzbenice
			{
				Porudzbenica = p
			});

			broker.Delete(p);
		}
	}
}
