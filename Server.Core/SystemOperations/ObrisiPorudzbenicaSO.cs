using Common.Domain;
using DBBroker;

namespace Server.Core.SystemOperations
{
	public class ObrisiPorudzbenicuSO : SystemOperationBase
	{
		private readonly Porudzbenica p;

		// ✅ Konstruktor za produkciju
		public ObrisiPorudzbenicuSO(Porudzbenica p)
		{
			this.p = p;
		}

		// ✅ Konstruktor za testiranje
		public ObrisiPorudzbenicuSO(Porudzbenica p, IBroker broker) : base(broker)
		{
			this.p = p;
		}

		public override void ExecuteConcreteOperation()
		{
			broker.Delete(new StavkaPorudzbenice { Porudzbenica = p });
			broker.Delete(p);
		}
	}
}
