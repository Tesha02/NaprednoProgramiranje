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
	internal class VratiArtikalSO : SystemOperationBase
	{
		public Artikal Result { get; set; }

		private readonly Artikal a;

		public VratiArtikalSO(Artikal a)
		{
			this.a = a;
		}

		protected override void ExecuteConcreteOperation()
		{
			Result = (Artikal)broker.GetByCondition(a).FirstOrDefault();
		}
	}
}
