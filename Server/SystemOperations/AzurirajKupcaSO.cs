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
	internal class AzurirajKupcaSO : SystemOperationBase
	{
		private Kupac kupac;

		public AzurirajKupcaSO(Kupac kupac)
		{
			this.kupac = kupac;
		}

		protected override void ExecuteConcreteOperation()
		{
			broker.Update(kupac);
		}
	}
}
