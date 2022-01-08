﻿using WebMotors.Shared.Queries;

namespace WebMotors.Domain.WebMotorsContext.Commands.Output
{
    public class QueryResult : IQueryResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public QueryResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

    }
}
