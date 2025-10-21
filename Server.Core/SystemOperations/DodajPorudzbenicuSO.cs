using Common.Domain;
using DBBroker;

namespace Server.Core.SystemOperations
{
	public class DodajPorudzbenicuSO : SystemOperationBase
	{
		public Porudzbenica Result { get; set; }
		private readonly Porudzbenica porudzbenica;

		// ✅ Konstruktor za produkciju
		public DodajPorudzbenicuSO(Porudzbenica p)
		{
			porudzbenica = p;
		}

		// ✅ Konstruktor za testiranje (mock broker)
		public DodajPorudzbenicuSO(Porudzbenica p, IBroker broker) : base(broker)
		{
			porudzbenica = p;
		}

		public override void ExecuteConcreteOperation()
		{
			broker.Add(porudzbenica);

			foreach (var sp in porudzbenica.StavkePorudzbenica)
			{
				sp.Porudzbenica = porudzbenica;
				broker.Add(sp);
			}

			Result = porudzbenica;
		}
	}
}
