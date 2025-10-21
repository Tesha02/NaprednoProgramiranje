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
	public class AzurirajArtikalSO : SystemOperationBase
	{
		private Artikal a;

		public AzurirajArtikalSO(Artikal a)
		{
			this.a = a;
		}

		protected override void ExecuteConcreteOperation()
		{
			broker.Update(a);
		}
	}
}
