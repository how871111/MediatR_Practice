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
    public class CreateSalesHandler : IRequestHandler<CreateSalesRequestModel, Unit>
    {

        public Task<Unit> Handle(CreateSalesRequestModel request, CancellationToken cancellationToken)
        {

            using (SqlConnection cn = new("Server = SQCDSIT.ECTEST.CTBCSEC.COM,1803; Initial Catalog = etrade; User Id = etrade; Password = sit; Connection Lifetime = 0; Connection Timeout = 15; pooling = true; Min Pool Size = 100; Max Pool Size = 5000; Enlist = false"))
            {
                string QueryString = string.Format(@"
                                                        INSERT INTO dbo.SALES (EXCHID, BID, SID, NAME)
                                                            VALUES (@in_EXCHID, @in_BID, @in_SID, @in_NAME)
                                            ");

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@in_EXCHID", request.EXCHID, DbType.String, ParameterDirection.Input);
                parameters.Add("@in_BID", request.BID, DbType.String, ParameterDirection.Input);
                parameters.Add("@in_SID", request.SID, DbType.String, ParameterDirection.Input);
                parameters.Add("@in_NAME", request.NAME, DbType.String, ParameterDirection.Input);
                cn.Execute(QueryString, parameters);
            }

            return Task.FromResult(Unit.Value);
        }
    }

}