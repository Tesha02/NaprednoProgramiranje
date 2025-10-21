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
	internal class VratiArtikleSO : SystemOperationBase
	{
		public BindingList<Artikal> Result { get; set; }

		protected override void ExecuteConcreteOperation()
		{
			var list = broker.GetAll(new Artikal()); // ovo je List<IEntity>
			Result = new BindingList<Artikal>(list.Cast<Artikal>().ToList());
		}
	}
}
