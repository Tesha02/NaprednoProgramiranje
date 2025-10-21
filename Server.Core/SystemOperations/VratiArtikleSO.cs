using Common.Domain;
using DBBroker;
using System.ComponentModel;
using System.Linq;

namespace Server.Core.SystemOperations
{
	public class VratiArtikleSO : SystemOperationBase
	{
		public BindingList<Artikal> Result { get; set; }

		// ✅ Konstruktor za produkciju
		public VratiArtikleSO() { }

		// ✅ Konstruktor za testiranje
		public VratiArtikleSO(IBroker broker) : base(broker) { }

		public override void ExecuteConcreteOperation()
		{
			var list = broker.GetAll(new Artikal());
			Result = new BindingList<Artikal>(list.Cast<Artikal>().ToList());
		}
	}
}
