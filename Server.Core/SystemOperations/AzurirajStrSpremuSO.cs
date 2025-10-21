using Common.Domain;
using DBBroker;

namespace Server.Core.SystemOperations
{
	public class AzurirajStrSpremuSO : SystemOperationBase
	{
		private StrSprema ss;

		// ✅ Konstruktor za produkciju
		public AzurirajStrSpremuSO(StrSprema ss)
		{
			this.ss = ss;
		}

		// ✅ Konstruktor za testiranje
		public AzurirajStrSpremuSO(StrSprema ss, IBroker broker) : base(broker)
		{
			this.ss = ss;
		}

		public override void ExecuteConcreteOperation()
		{
			broker.Update(ss);
		}
	}
}
