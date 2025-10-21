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
	internal class AzurirajPorudzbenicuSO : SystemOperationBase
	{
		private Porudzbenica p;

		public AzurirajPorudzbenicuSO(Porudzbenica p)
		{
			this.p = p;
		}

		protected override void ExecuteConcreteOperation()
		{
			broker.Update(p);

			broker.Delete(new StavkaPorudzbenice
			{
				Porudzbenica = p
			});

			foreach (StavkaPorudzbenice sp in p.StavkePorudzbenica)
			{
				sp.Porudzbenica = p;
				broker.Add(sp);
			}
		}
	}
}
