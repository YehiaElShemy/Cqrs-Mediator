﻿using Cqrs_Mediator.Application.Contract.ProductContract;

namespace DomainLayer.Contract
{
    public interface IAsyncUnitOfWork:IDisposable
    {
        //add anthor of reference property
        public IRepositoryProduct _product { get; set; }
        public IRepositoryCategory _Category { get; set; }
        Task<int> SaveChangeAsync();
    }
}
