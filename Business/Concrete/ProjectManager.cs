using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }
          
        [ValidationAspect(typeof(ProjectValidator))]
        [TransactionScopeAspect]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Add(Project project)
        {

            //var context = new ValidationContext<Project>(project);
            //ProjectValidator productValidator = new ProjectValidator();
            //var result = productValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            _projectDal.Add(project);
            return new SuccessResult(Messages.ProjectAdded);
        }

        [TransactionScopeAspect]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Delete(Project project)
        {
            _projectDal.Delete(project);
            return new SuccessResult(Messages.ProjectDeleted);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Project>> GetAll()
        {
            return new SuccessDataResult<List<Project>>(_projectDal.GetAll());
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Project>> GetById(int projectId) => new SuccessDataResult<List<Project>>(_projectDal.GetAll(p => p.Id == projectId));

        [ValidationAspect(typeof(ProjectValidator))]
        [TransactionScopeAspect]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Update(Project project)
        {
            _projectDal.Update(project);
            return new SuccessResult(Messages.ProjectUptaded);
        }
    }
}
