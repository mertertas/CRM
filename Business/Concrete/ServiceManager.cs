using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class ServiceManager : ISrvService
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

       // [ValidationAspect(typeof(ServiceValidator))]
        //[CacheRemoveAspect("ISrvService.Get")]
        //[TransactionScopeAspect]
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        public IResult Add(Service service)
        {
            _serviceDal.Add(service);
            return new SuccessResult(Messages.ServiceAdded);
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ISrvService.Get")]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Delete(Service service)
        {
            _serviceDal.Delete(service);
            return new SuccessResult(Messages.ServiceDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Service>> GetAll()
        {
            return new SuccessDataResult<List<Service>>(_serviceDal.GetAll());
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Service>> GetById(int serviceId)
        {
            return new SuccessDataResult<List<Service>>(_serviceDal.GetAll(p => p.Id == serviceId));
        }

        [ValidationAspect(typeof(ServiceValidator))]
        [CacheRemoveAspect("ISrvService.Get")]
        [TransactionScopeAspect]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Update(Service service)
        {
            _serviceDal.Update(service);
            return new SuccessResult(Messages.ServiceUptaded);
        }
    }
}
