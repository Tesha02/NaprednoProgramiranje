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
	internal class ObrisiMestoSO : SystemOperationBase
	{
		private readonly Mesto m;

		public ObrisiMestoSO(Mesto mesto)
		{
			m = mesto;
		}

		protected override void ExecuteConcreteOperation()
		{
			broker.Delete(m);
		}
	}
}
