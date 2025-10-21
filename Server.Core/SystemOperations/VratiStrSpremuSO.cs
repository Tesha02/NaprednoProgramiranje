using Common.Domain;
using DBBroker;
using System.Linq;

namespace Server.Core.SystemOperations
{
	public class VratiStrSpremuSO : SystemOperationBase
	{
		public StrSprema Result { get; private set; }
		private readonly StrSprema ss;

		// ✅ Konstruktor za produkciju
		public VratiStrSpremuSO(StrSprema ss)
		{
			this.ss = ss;
		}

		// ✅ Konstruktor za testiranje
		public VratiStrSpremuSO(StrSprema ss, IBroker broker) : base(broker)
		{
			this.ss = ss;
		}

		public override void ExecuteConcreteOperation()
		{
			Result = (StrSprema)broker.GetByCondition(ss).FirstOrDefault();
		}
	}
}
