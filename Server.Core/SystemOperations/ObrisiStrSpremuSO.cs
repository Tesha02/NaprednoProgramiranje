using Common.Domain;
using DBBroker;

namespace Server.Core.SystemOperations
{
	public class ObrisiStrSpremuSO : SystemOperationBase
	{
		private readonly StrSprema ss;

		// ✅ Konstruktor za produkciju
		public ObrisiStrSpremuSO(StrSprema strSprema)
		{
			ss = strSprema;
		}

		// ✅ Konstruktor za testiranje
		public ObrisiStrSpremuSO(StrSprema strSprema, IBroker broker) : base(broker)
		{
			ss = strSprema;
		}

		public override void ExecuteConcreteOperation()
		{
			broker.Delete(ss);
		}
	}
}
