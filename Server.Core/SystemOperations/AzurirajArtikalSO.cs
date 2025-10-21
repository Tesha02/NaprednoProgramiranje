using Common.Domain;
using DBBroker;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.SystemOperations
{
	public class AzurirajArtikalSO : SystemOperationBase
	{
		private Artikal a;

		public AzurirajArtikalSO(Artikal a) : base()
		{
			this.a = a;
		}
		public AzurirajArtikalSO(Artikal a, IBroker broker) : base(broker)
		{
			this.a = a;
		}

		public override void ExecuteConcreteOperation()
		{
			broker.Update(a);
		}
	}
}
