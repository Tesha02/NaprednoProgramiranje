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
	internal class VratiPorudzbenicuSO : SystemOperationBase
	{
		public Porudzbenica Result { get; private set; }

		private readonly Porudzbenica p;

		public VratiPorudzbenicuSO(Porudzbenica p)
		{
			this.p = p;
		}

		protected override void ExecuteConcreteOperation()
		{
			var porudzbenica = (Porudzbenica)broker.GetByCondition(p).FirstOrDefault();

			if (porudzbenica == null)
				throw new Exception("Porudžbenica nije pronađena.");

			// 2. Vrati sve stavke koje pripadaju toj porudžbenici
			StavkaPorudzbenice dummy = new StavkaPorudzbenice
			{
				Porudzbenica = porudzbenica
			};

			List<IEntity> stavke = broker.GetByCondition(dummy);
			porudzbenica.StavkePorudzbenica = stavke.Cast<StavkaPorudzbenice>().ToList();

			// 3. Vrati kompletan agregat
			Result = porudzbenica;
		}
	}
}
