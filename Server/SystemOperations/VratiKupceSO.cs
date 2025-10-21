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
	internal class VratiKupceSO : SystemOperationBase
	{
		public List<Kupac> Result { get; set; }

		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetAll(new Kupac())
						   .Cast<Kupac>()
						   .ToList();
		}
	}
}
