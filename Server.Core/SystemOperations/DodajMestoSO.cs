using Common.Domain;
using DBBroker;

namespace Server.Core.SystemOperations
{
	public class DodajMestoSO : SystemOperationBase
	{
		private readonly Mesto mesto;

		// ✅ Konstruktor za produkciju
		public DodajMestoSO(Mesto m)
		{
			mesto = m;
		}

		// ✅ Konstruktor za testiranje (mock broker)
		public DodajMestoSO(Mesto m, IBroker broker) : base(broker)
		{
			mesto = m;
		}

		public override void ExecuteConcreteOperation()
		{
			broker.Add(mesto);
		}
	}
}
