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
	public class LoginSO : SystemOperationBase
	{
		private readonly Radnik r;

		public Radnik Result { get; set; }

		public LoginSO(Radnik r)
		{
			this.r = r;
		}

		protected override void ExecuteConcreteOperation()
		{
			List<IEntity> lista = broker.GetByCondition(r);
			Result = lista.Cast<Radnik>().FirstOrDefault();

			if (Result == null)
			{
				throw new Exception("Ne postoji zaposleni sa unetim kredencijalima.");
			}
		}
	}
}
