using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	/// <summary>
	/// Sistem operacija koja ažurira podatke postojećeg kupca u bazi podataka.
	/// </summary>
	/// <remarks>
	/// Ova klasa nasleđuje <see cref="SystemOperationBase"/> i implementira konkretno ponašanje
	/// za ažuriranje entiteta <see cref="Kupac"/> pozivom metode <c>Update</c> iz klase <see cref="DBBroker.Broker"/>.
	/// Operacija se izvršava u okviru transakcije (otvaranje konekcije, commit ili rollback u slučaju greške).
	/// </remarks>
	internal class AzurirajKupcaSO : SystemOperationBase
	{
		/// <summary>
		/// Instanca kupca čiji se podaci ažuriraju u bazi podataka.
		/// </summary>
		private readonly Kupac kupac;

		/// <summary>
		/// Inicijalizuje novu instancu operacije za ažuriranje kupca.
		/// </summary>
		/// <param name="kupac">Kupac sa izmenjenim vrednostima koje treba sačuvati u bazi.</param>
		public AzurirajKupcaSO(Kupac kupac)
		{
			this.kupac = kupac;
		}

		/// <summary>
		/// Izvršava konkretnu operaciju ažuriranja kupca u bazi.
		/// </summary>
		/// <remarks>
		/// Poziva <see cref="DBBroker.Broker.Update"/> metod i prosleđuje instancu kupca.
		/// Ako dođe do izuzetka, transakcija se automatski poništava pomoću rollback mehanizma iz bazne klase.
		/// </remarks>
		protected override void ExecuteConcreteOperation()
		{
			broker.Update(kupac);
		}
	}
}
