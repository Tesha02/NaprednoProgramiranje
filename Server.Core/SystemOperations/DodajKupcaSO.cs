using Common.Domain;
using DBBroker;

namespace Server.Core.SystemOperations
{
	public class DodajKupcaSO : SystemOperationBase
	{
		private readonly Kupac kupac;
		public Kupac Result { get; set; }

		// ✅ Konstruktor za produkciju
		public DodajKupcaSO(Kupac k)
		{
			kupac = k;
		}

		// ✅ Konstruktor za testiranje
		public DodajKupcaSO(Kupac k, IBroker broker) : base(broker)
		{
			kupac = k;
		}

		public override void ExecuteConcreteOperation()
		{
			broker.Add(kupac);
			Result = kupac;
		}
	}
}
