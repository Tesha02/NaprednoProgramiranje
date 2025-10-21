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
	internal class VratiKupcaSO : SystemOperationBase
	{
		public Kupac Result { get; private set; }

		private readonly Kupac k;

		public VratiKupcaSO(Kupac k)
		{
			this.k = k;
		}

		protected override void ExecuteConcreteOperation()
		{
			Result = (Kupac)broker.GetByCondition(k).FirstOrDefault();
		}
	}
}
