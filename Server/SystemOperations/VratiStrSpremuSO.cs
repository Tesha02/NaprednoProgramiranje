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
	internal class VratiStrSpremuSO : SystemOperationBase
	{
		public StrSprema Result { get; private set; }

		private readonly StrSprema ss;

		public VratiStrSpremuSO(StrSprema ss)
		{
			this.ss = ss;
		}

		protected override void ExecuteConcreteOperation()
		{
			Result = (StrSprema)broker.GetByCondition(ss).FirstOrDefault();
		}
	}
}
