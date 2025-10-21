using Common.Domain;
using DBBroker;
using System.Linq;

namespace Server.Core.SystemOperations
{
	public class VratiKupcaSO : SystemOperationBase
	{
		public Kupac Result { get; private set; }
		private readonly Kupac k;

		// ✅ Konstruktor za produkciju
		public VratiKupcaSO(Kupac k)
		{
			this.k = k;
		}

		// ✅ Konstruktor za testiranje
		public VratiKupcaSO(Kupac k, IBroker broker) : base(broker)
		{
			this.k = k;
		}

		public override void ExecuteConcreteOperation()
		{
			Result = (Kupac)broker.GetByCondition(k).FirstOrDefault();
		}
	}
}
