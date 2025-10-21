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
	internal class DodajPorudzbenicuSO : SystemOperationBase
	{
		public Porudzbenica Result { get; set; }

		private readonly Porudzbenica porudzbenica;

		public DodajPorudzbenicuSO(Porudzbenica p)
		{
			porudzbenica = p;
		}

		protected override void ExecuteConcreteOperation()
		{
			broker.Add(porudzbenica);

			foreach (StavkaPorudzbenice sp in porudzbenica.StavkePorudzbenica)
			{
				sp.Porudzbenica = porudzbenica;
				broker.Add(sp);
			}

			Result = porudzbenica;
		}
	}
}
