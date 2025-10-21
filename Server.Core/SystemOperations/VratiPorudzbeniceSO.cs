using Common.Domain;
using DBBroker;
using System.Collections.Generic;
using System.Linq;

namespace Server.Core.SystemOperations
{
	public class VratiPorudzbeniceSO : SystemOperationBase
	{
		public List<Porudzbenica> Result { get; private set; }

		// ✅ Konstruktor za produkciju
		public VratiPorudzbeniceSO() { }

		// ✅ Konstruktor za testiranje
		public VratiPorudzbeniceSO(IBroker broker) : base(broker) { }

		public override void ExecuteConcreteOperation()
		{
			Result = broker.GetAll(new Porudzbenica()).Cast<Porudzbenica>().ToList();
		}
	}
}
