using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR_Practice.Models;
using System.Data.SqlClient;
using System;
using System.Data;
using Dapper;
using System.Collections.Generic;

namespace MediatR_Practice.Handlers
{

    public class SetSalesOperator1Handler : INotificationHandler<SetSalesOperatorRequestModel>
    {
        public Task Handle(SetSalesOperatorRequestModel request, CancellationToken cancellationToken)
        {
            using (SqlConnection cn = new("Server = SQCDSIT.ECTEST.CTBCSEC.COM,1803; Initial Catalog = etrade; User Id = etrade; Password = sit; Connection Lifetime = 0; Connection Timeout = 15; pooling = true; Min Pool Size = 100; Max Pool Size = 5000; Enlist = false"))
            {
                string QueryString = string.Format(@"
                                                        UPDATE SALES SET OPERATOR = OPERATOR+'_NotificationHandle 1'
                                                        FROM dbo.SALES WITH (NOLOCK)
                                                        WHERE 1 = 1
                                                        AND SID = @in_SID
                                            ");

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@in_SID", request.SID, DbType.String, ParameterDirection.Input);

                cn.Execute(QueryString, parameters);
            }

            return Task.FromResult(Unit.Value);
        }

    }

}