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
	public class DodajMestoSO : SystemOperationBase
	{
		private readonly Mesto mesto;

		public DodajMestoSO(Mesto m)
		{
			mesto = m;
		}

		protected override void ExecuteConcreteOperation()
		{
			broker.Add(mesto);
		}
	}
}
