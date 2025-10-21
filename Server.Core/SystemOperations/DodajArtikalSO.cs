using Common.Domain;
using DBBroker;

namespace Server.Core.SystemOperations
{
	public class DodajArtikalSO : SystemOperationBase
	{
		private readonly Artikal artikal;
		public Artikal Result { get; set; }

		// ✅ Konstruktor za produkciju
		public DodajArtikalSO(Artikal a)
		{
			artikal = a;
		}

		// ✅ Konstruktor za testiranje
		public DodajArtikalSO(Artikal a, IBroker broker) : base(broker)
		{
			artikal = a;
		}

		public override void ExecuteConcreteOperation()
		{
			broker.Add(artikal);
			Result = artikal;
		}
	}
}
