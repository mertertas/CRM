
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISrvService
    {
        IDataResult<List<Service>> GetAll();
        IDataResult<List<Service>> GetById(int serviceId);
        IResult Add(Service service);
        IResult Delete(Service service);
        IResult Update(Service service);
    }
}
