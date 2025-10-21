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
	internal class VratiArtiklePoTipuSO : SystemOperationBase
	{
		public List<Artikal> Result { get; set; }

		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetByCondition(new Artikal())
						   .Cast<Artikal>()
						   .ToList();
		}
	}
}
