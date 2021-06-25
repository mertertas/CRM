
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProjectService
    {
        IDataResult<List<Project>> GetAll();
        IDataResult<List<Project>> GetById(int projectId);
        IResult Add(Project project);
        IResult Delete(Project project);
        IResult Update(Project project);
    }
}
