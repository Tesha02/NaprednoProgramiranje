using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public interface IEntity
    {
        string TableName { get; }
        string Values { get; }
		string TableAlias { get; }
		string WhereCondition { get; }
        string CountWhereCondition { get; }
		string JoinTable { get; }
		string GetCondition { get; }
		string UpdateValues { get; }
		string outputId { get; }
		void setId(long id);


		List<IEntity> GetReaderList(SqlDataReader reader);

    }
}
