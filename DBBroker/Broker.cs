using Common.Domain;
using Microsoft.Data.SqlClient;
using System.Transactions;

namespace DBBroker
{
	public class Broker
	{
		private DbConnection connection;
		public Broker()
		{
			connection = new DbConnection();
		}

		public void Rollback()
		{
			connection.Rollback();
		}

		public void Commit()
		{
			connection.Commit();
		}

		public void BeginTransaction()
		{
			connection.BeginTransaction();
		}

		public void CloseConnection()
		{
			connection.CloseConnection();
		}

		public void OpenConnection()
		{
			connection.OpenConnection();
		}

		public void Add(IEntity obj)
		{
			SqlCommand cmd = connection.CreateCommand();
			cmd.CommandText = $"insert into {obj.TableName} output inserted.{obj.outputId} values({obj.Values})";
			long id = Convert.ToInt64(cmd.ExecuteScalar());
			obj.setId(id);
			cmd.Dispose();
		}

		//ovu videti da se izbaci
		//public long AddWithId(IEntity obj)
		//{
		//	SqlCommand cmd = connection.CreateCommand();
		//	cmd.CommandText = $"insert into {obj.TableName} output inserted.id values({obj.Values})";
		//	long id = (long)cmd.ExecuteScalar();
		//	cmd.Dispose();
		//	return id;
		//}

		public void Update(IEntity obj)
		{
			SqlCommand cmd = connection.CreateCommand();
			cmd.CommandText = $"update {obj.TableAlias} set {obj.UpdateValues} from {obj.TableName} {obj.TableAlias} where {obj.WhereCondition}";
			cmd.ExecuteNonQuery();
			cmd.Dispose();
		}

		public void Delete(IEntity obj)
		{
			SqlCommand cmd = connection.CreateCommand();
			cmd.CommandText = $"delete {obj.TableAlias} from {obj.TableName} {obj.TableAlias} where {obj.WhereCondition}";
			cmd.ExecuteNonQuery();
			cmd.Dispose();
		}

		public List<IEntity> GetAll(IEntity entity)
		{
			SqlCommand command = connection.CreateCommand();
			command.CommandText = $"select * from {entity.TableName} {entity.TableAlias} {entity.JoinTable}";
			using SqlDataReader reader = command.ExecuteReader();
			List<IEntity> list = entity.GetReaderList(reader);
			command.Dispose();
			return list;
		}

		public List<IEntity> GetByCondition(IEntity entity)
		{
			SqlCommand command = connection.CreateCommand();
			command.CommandText = $"SELECT * FROM {entity.TableName} {entity.TableAlias} {entity.JoinTable} WHERE {entity.WhereCondition}";
			using SqlDataReader reader = command.ExecuteReader();
			List<IEntity> list = entity.GetReaderList(reader);
			command.Dispose();
			return list;
		}

		//videti da se i ovo izbaci
		//public int CountByCondition(IEntity entity)
		//{
		//	SqlCommand command = connection.CreateCommand();
		//	command.CommandText = $"SELECT COUNT(*) FROM {entity.TableName} WHERE {entity.CountWhereCondition}";
		//	int broj = (int)command.ExecuteScalar();
		//	command.Dispose();

		//	return broj;
		//}

		//public List<IEntity> SearchByCondtion(IEntity entity)
		//{
		//	SqlCommand command = connection.CreateCommand();
		//	command.CommandText = $"SELECT * FROM {entity.TableName} WHERE {entity.GetCondition}";
		//	using SqlDataReader reader = command.ExecuteReader();
		//	List<IEntity> list = entity.GetReaderList(reader);
		//	command.Dispose();
		//	return list;
		//}

	}
}
