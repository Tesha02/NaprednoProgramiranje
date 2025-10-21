using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Server.Core.SystemOperations
{
	public abstract class SystemOperationBase
	{
		protected IBroker broker;
		public SystemOperationBase()
		{
			broker = new Broker();
		}
		protected SystemOperationBase(IBroker customBroker)
		{
			broker = customBroker;
		}

		public void ExecuteTemplate()
		{
			try
			{
				broker.OpenConnection();
				broker.BeginTransaction();
				ExecuteConcreteOperation();
				broker.Commit();
			}

			catch (Exception ex)
			{
				broker.Rollback();
				throw;
			}
			finally
			{
				broker.CloseConnection();
			}
		}

		public abstract void ExecuteConcreteOperation();

	}

}