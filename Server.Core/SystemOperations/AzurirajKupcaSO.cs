using Common.Domain;
using DBBroker;

namespace Server.Core.SystemOperations
{
	public class AzurirajKupcaSO : SystemOperationBase
	{
		private readonly Kupac kupac;

		// ✅ Konstruktor za produkcioni kod
		public AzurirajKupcaSO(Kupac kupac)
		{
			this.kupac = kupac;
		}

		// ✅ Konstruktor za testiranje (prima mockovani broker)
		public AzurirajKupcaSO(Kupac kupac, IBroker broker) : base(broker)
		{
			this.kupac = kupac;
		}

		public override void ExecuteConcreteOperation()
		{
			broker.Update(kupac);
		}
	}
}
