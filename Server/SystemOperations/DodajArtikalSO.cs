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
	public class DodajArtikalSO : SystemOperationBase
	{
		private readonly Artikal artikal;

		public Artikal Result { get; set; }

		public DodajArtikalSO(Artikal a)
		{
			artikal = a;
		}

		protected override void ExecuteConcreteOperation()
		{
			broker.Add(artikal);
			Result = artikal;
		}
	}
}
