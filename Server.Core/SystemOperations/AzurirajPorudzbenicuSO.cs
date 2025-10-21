using Common.Domain;
using DBBroker;

namespace Server.Core.SystemOperations
{
	public class AzurirajPorudzbenicuSO : SystemOperationBase
	{
		private Porudzbenica p;

		// ✅ Konstruktor za produkciju (radi sa pravim Broker-om)
		public AzurirajPorudzbenicuSO(Porudzbenica p)
		{
			this.p = p;
		}

		// ✅ Konstruktor za testiranje (prima mock IBroker)
		public AzurirajPorudzbenicuSO(Porudzbenica p, IBroker broker) : base(broker)
		{
			this.p = p;
		}

		public override void ExecuteConcreteOperation()
		{
			broker.Update(p);
			broker.Delete(new StavkaPorudzbenice { Porudzbenica = p });
			foreach (var sp in p.StavkePorudzbenica)
			{
				sp.Porudzbenica = p;
				broker.Add(sp);
			}
		}
	}
}
