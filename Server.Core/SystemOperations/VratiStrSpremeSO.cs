using Common.Domain;
using DBBroker;
using System.Collections.Generic;
using System.Linq;

namespace Server.Core.SystemOperations
{
	public class VratiStrSpremeSO : SystemOperationBase
	{
		public List<StrSprema> Result { get; private set; }

		// ✅ Konstruktor za produkciju
		public VratiStrSpremeSO() { }

		// ✅ Konstruktor za testiranje
		public VratiStrSpremeSO(IBroker broker) : base(broker) { }

		public override void ExecuteConcreteOperation()
		{
			Result = broker.GetAll(new StrSprema()).Cast<StrSprema>().ToList();
		}
	}
}
