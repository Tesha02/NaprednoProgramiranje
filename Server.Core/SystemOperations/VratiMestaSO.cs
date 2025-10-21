using Common.Domain;
using DBBroker;
using System.Collections.Generic;
using System.Linq;

namespace Server.Core.SystemOperations
{
	public class VratiMestaSO : SystemOperationBase
	{
		public List<Mesto> Result { get; private set; }

		// ✅ Konstruktor za produkciju
		public VratiMestaSO() { }

		// ✅ Konstruktor za testiranje
		public VratiMestaSO(IBroker broker) : base(broker) { }

		public override void ExecuteConcreteOperation()
		{
			Result = broker.GetAll(new Mesto()).Cast<Mesto>().ToList();
		}
	}
}
