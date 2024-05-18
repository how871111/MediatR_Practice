using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR_Practice.Models;
using MediatR_Practice.Controllers;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace MediatR_Practice.Handlers
{
    public class QuerySalesHandler : IRequestHandler<QuerySalesRequestModel, QuerySalesResponseModel>
    {
        public Task<QuerySalesResponseModel> Handle(QuerySalesRequestModel request, CancellationToken cancellationToken)
        {

            using (SqlConnection cn = new("Server = SQCDSIT.ECTEST.CTBCSEC.COM,1803; Initial Catalog = etrade; User Id = etrade; Password = sit; Connection Lifetime = 0; Connection Timeout = 15; pooling = true; Min Pool Size = 100; Max Pool Size = 5000; Enlist = false"))
            {
                string QueryString = string.Format(@"
                                                        SELECT
	                                                        *
                                                        FROM dbo.SALES WITH (NOLOCK)
                                                        WHERE 1 = 1
                                                        AND SID = @in_SID
                                            ");

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@in_SID", request.SID, DbType.String, ParameterDirection.Input);
                QuerySalesResponseModel querySalesResponseModel = cn.Query<QuerySalesResponseModel>(QueryString, parameters).FirstOrDefault();

                return  Task.FromResult(querySalesResponseModel);
            }
        }
    }

}