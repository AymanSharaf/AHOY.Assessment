﻿namespace AHOY.Assessment.Core.Common
{
    public interface IQueryHandler<TQuery, TResult>
         where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
