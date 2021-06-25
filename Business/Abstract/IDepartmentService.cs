
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        IDataResult<List<Department>> GetAll();
        IDataResult<List<Department>> GetById(int departmentId);
        IResult Add(Department department);
        IResult Delete(Department department);
        IResult Update(Department department);
    }
}
