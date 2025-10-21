using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Core.SystemOperations
{
	public class VratiPorudzbenicuSO : SystemOperationBase
	{
		public Porudzbenica Result { get; private set; }
		private readonly Porudzbenica p;

		// ✅ Konstruktor za produkciju
		public VratiPorudzbenicuSO(Porudzbenica p)
		{
			this.p = p;
		}

		// ✅ Konstruktor za testiranje
		public VratiPorudzbenicuSO(Porudzbenica p, IBroker broker) : base(broker)
		{
			this.p = p;
		}

		public override void ExecuteConcreteOperation()
		{
			var porudzbenica = (Porudzbenica)broker.GetByCondition(p).FirstOrDefault();

			if (porudzbenica == null)
				throw new Exception("Porudžbenica nije pronađena.");

			var dummy = new StavkaPorudzbenice { Porudzbenica = porudzbenica };
			List<IEntity> stavke = broker.GetByCondition(dummy);

			porudzbenica.StavkePorudzbenica = stavke.Cast<StavkaPorudzbenice>().ToList();

			Result = porudzbenica;
		}
	}
}
