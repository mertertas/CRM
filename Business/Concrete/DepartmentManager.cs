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
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        [ValidationAspect(typeof(DepartmentValidator))]
        [CacheRemoveAspect("IDepartmentService.Get")]
        [TransactionScopeAspect]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Add(Department department)
        {
            _departmentDal.Add(department);
            return new SuccessResult(Messages.DepartmentAdded);
        } 
   
        [CacheRemoveAspect("IDepartmentService.Get")]
        [TransactionScopeAspect]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Delete(Department department)
        {
            _departmentDal.Delete(department);
            return new SuccessResult(Messages.DepartmentDeleted);
        }
        
        [CacheAspect]
        [PerformanceAspect(5)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Department>> GetAll()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetAll());
        }
        
        [CacheAspect]
        [PerformanceAspect(5)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Department>> GetById(int departmentId)
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetAll(p => p.Id == departmentId));
        }

        [ValidationAspect(typeof(DepartmentValidator))]
        [CacheRemoveAspect("IDepartmentService.Get")]
        [TransactionScopeAspect]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Update(Department department)
        {
            _departmentDal.Update(department);
            return new SuccessResult(Messages.DepartmentUptaded);
        }
    }
}
