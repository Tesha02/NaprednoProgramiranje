using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja ažurira podatke o stručnoj spremi u bazi podataka.
	/// </summary>
	/// <remarks>
	/// Ova operacija nasleđuje <see cref="SystemOperationBase"/> i implementira konkretno ponašanje
	/// za ažuriranje entiteta <see cref="StrSprema"/>. 
	/// Tokom izvršavanja koristi metodu <c>Update</c> iz klase <see cref="DBBroker.Broker"/>
	/// kako bi se postojeći zapis u tabeli <c>StrSprema</c> ažurirao novim vrednostima.
	/// U slučaju greške, transakcioni šablon iz bazne klase obezbeđuje rollback.
	/// </remarks>
	internal class AzurirajStrSpremuSO : SystemOperationBase
	{
		/// <summary>
		/// Instanca stručne spreme koja se ažurira u bazi podataka.
		/// </summary>
		private readonly StrSprema ss;

		/// <summary>
		/// Inicijalizuje novu instancu operacije za ažuriranje stručne spreme.
		/// </summary>
		/// <param name="ss">Stručna sprema sa izmenjenim vrednostima.</param>
		public AzurirajStrSpremuSO(StrSprema ss)
		{
			this.ss = ss;
		}

		/// <summary>
		/// Izvršava konkretnu operaciju ažuriranja stručne spreme u bazi podataka.
		/// </summary>
		/// <remarks>
		/// Poziva <see cref="DBBroker.Broker.Update"/> metod i prosleđuje objekat <see cref="StrSprema"/>.
		/// Ako dođe do greške tokom ažuriranja, transakcija se automatski poništava.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			broker.Update(ss);
		}
	}
}
