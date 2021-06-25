using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ServiceTransactionManager : IServiceTransactionService
    {
        IServiceTransactionDal _serviceTransactionDal;

        public ServiceTransactionManager(IServiceTransactionDal serviceTransactionDal)
        {
            _serviceTransactionDal = serviceTransactionDal;
        }

        [ValidationAspect(typeof(ServiceTransactionValidator))]
        [CacheRemoveAspect("IServiceTransactionService.Get")]
        [TransactionScopeAspect]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Add(ServiceTransaction serviceTransaction)
        {
            _serviceTransactionDal.Add(serviceTransaction);
            return new SuccessResult(Messages.ServiceTransactionAdded);
        }

        [ValidationAspect(typeof(ServiceTransactionValidator))]
        [CacheRemoveAspect("IServiceTransactionService.Get")]
        [TransactionScopeAspect]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Delete(ServiceTransaction serviceTransaction)
        {
            _serviceTransactionDal.Delete(serviceTransaction);
            return new SuccessResult(Messages.ServiceTransactionDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<ServiceTransaction>> GetAll()
        {
            return new  SuccessDataResult<List<ServiceTransaction>>(_serviceTransactionDal.GetAll());
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<ServiceTransaction>> GetById(int serviceTransactionId)
        {
            return new SuccessDataResult<List<ServiceTransaction>>(_serviceTransactionDal.GetAll(p=>p.Id==serviceTransactionId));
        }

        [ValidationAspect(typeof(ServiceTransactionValidator))]
        [CacheRemoveAspect("IServiceTransactionService.Get")]
        [TransactionScopeAspect]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Update(ServiceTransaction serviceTransaction)
        {
            _serviceTransactionDal.Update(serviceTransaction);
            return new SuccessResult(Messages.ServiceTransactionUptaded);
        }
    }
}
