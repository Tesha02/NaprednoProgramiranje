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
	internal class ObrisiPorudzbenicuSO : SystemOperationBase
	{
		private readonly Porudzbenica p;

		public ObrisiPorudzbenicuSO(Porudzbenica p)
		{
			this.p = p;
		}

		protected override void ExecuteConcreteOperation()
		{
			broker.Delete(new StavkaPorudzbenice
			{
				Porudzbenica = p
			});

			broker.Delete(p);
		}
	}
}
