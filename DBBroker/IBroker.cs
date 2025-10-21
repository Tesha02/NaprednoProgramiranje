using Common.Domain;
using System.Collections.Generic;

namespace DBBroker
{
	public interface IBroker
	{
		void OpenConnection();
		void CloseConnection();
		void BeginTransaction();
		void Commit();
		void Rollback();
		void Add(IEntity entity);
		void Update(IEntity entity);
		void Delete(IEntity entity);
		List<IEntity> GetAll(IEntity entity);
		List<IEntity> GetByCondition(IEntity entity);
	}
}