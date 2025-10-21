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
	internal class DodajStrSpremuSO : SystemOperationBase
	{
		private readonly StrSprema strSprema;

		public DodajStrSpremuSO(StrSprema ss)
		{
			strSprema = ss;
		}

		protected override void ExecuteConcreteOperation()
		{
			broker.Add(strSprema);
		}
	}
}
