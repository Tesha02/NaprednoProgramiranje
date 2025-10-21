using Common.Domain;
using DBBroker;
using System.Linq;

namespace Server.Core.SystemOperations
{
	public class VratiArtikalSO : SystemOperationBase
	{
		public Artikal Result { get; set; }
		private readonly Artikal a;

		// ✅ Konstruktor za produkciju
		public VratiArtikalSO(Artikal a)
		{
			this.a = a;
		}

		// ✅ Konstruktor za testiranje
		public VratiArtikalSO(Artikal a, IBroker broker) : base(broker)
		{
			this.a = a;
		}

		public override void ExecuteConcreteOperation()
		{
			Result = (Artikal)broker.GetByCondition(a).FirstOrDefault();
		}
	}
}
