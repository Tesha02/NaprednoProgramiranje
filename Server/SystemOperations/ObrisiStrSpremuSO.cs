using Common.Domain;
using DBBroker;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	internal class ObrisiStrSpremuSO : SystemOperationBase
	{
		private readonly StrSprema ss;

		public ObrisiStrSpremuSO(StrSprema strSprema)
		{
			ss = strSprema;
		}

		protected override void ExecuteConcreteOperation()
		{
			broker.Delete(ss);
		}
	}
}
