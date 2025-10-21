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
	internal class DodajKupcaSO : SystemOperationBase
	{
		private readonly Kupac kupac;

		public Kupac Result { get; set; }

		public DodajKupcaSO(Kupac k)
		{
			kupac = k;
		}

		protected override void ExecuteConcreteOperation()
		{
			broker.Add(kupac);
			Result = kupac;
		}
	}
}
