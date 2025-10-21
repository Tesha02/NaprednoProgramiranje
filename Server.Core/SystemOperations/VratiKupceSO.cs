using Common.Domain;
using DBBroker;
using System.Collections.Generic;
using System.Linq;

namespace Server.Core.SystemOperations
{
	public class VratiKupceSO : SystemOperationBase
	{
		public List<Kupac> Result { get; private set; }

		// ✅ Konstruktor za produkciju
		public VratiKupceSO() { }

		// ✅ Konstruktor za testiranje
		public VratiKupceSO(IBroker broker) : base(broker) { }

		public override void ExecuteConcreteOperation()
		{
			Result = broker.GetAll(new Kupac()).Cast<Kupac>().ToList();
		}
	}
}
