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
	internal class AzurirajStrSpremuSO : SystemOperationBase
	{
		private StrSprema ss;

		public AzurirajStrSpremuSO(StrSprema ss)
		{
			this.ss = ss;
		}

		protected override void ExecuteConcreteOperation()
		{
			broker.Update(ss);
		}
	}
}
