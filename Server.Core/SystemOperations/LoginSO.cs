using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Core.SystemOperations
{
	public class LoginSO : SystemOperationBase
	{
		private readonly Radnik r;
		public Radnik Result { get; set; }

		// ✅ Konstruktor za produkciju
		public LoginSO(Radnik r)
		{
			this.r = r;
		}

		// ✅ Konstruktor za testiranje (mock broker)
		public LoginSO(Radnik r, IBroker broker) : base(broker)
		{
			this.r = r;
		}

		public override void ExecuteConcreteOperation()
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
