using Common.Domain;
using DBBroker;

namespace Server.Core.SystemOperations
{
	public class DodajStrSpremuSO : SystemOperationBase
	{
		private readonly StrSprema strSprema;

		// ✅ Konstruktor za produkciju
		public DodajStrSpremuSO(StrSprema ss)
		{
			strSprema = ss;
		}

		// ✅ Konstruktor za testiranje (mock broker)
		public DodajStrSpremuSO(StrSprema ss, IBroker broker) : base(broker)
		{
			strSprema = ss;
		}

		public override void ExecuteConcreteOperation()
		{
			broker.Add(strSprema);
		}
	}
}
