using Common.Domain;
using DBBroker;

namespace Server.Core.SystemOperations
{
	public class ObrisiMestoSO : SystemOperationBase
	{
		private readonly Mesto m;

		// ✅ Konstruktor za produkciju
		public ObrisiMestoSO(Mesto mesto)
		{
			m = mesto;
		}

		// ✅ Konstruktor za testiranje (mock broker)
		public ObrisiMestoSO(Mesto mesto, IBroker broker) : base(broker)
		{
			m = mesto;
		}

		public override void ExecuteConcreteOperation()
		{
			broker.Delete(m);
		}
	}
}
