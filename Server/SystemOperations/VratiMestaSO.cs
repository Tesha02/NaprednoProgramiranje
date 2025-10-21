using Common.Domain;
using DBBroker;
using Server.Core.SystemOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
	public class VratiMestaSO : SystemOperationBase
	{
		public List<Mesto> Result { get; set; }

		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetAll(new Mesto())
						   .Cast<Mesto>()
						   .ToList();
		}
	}
}
