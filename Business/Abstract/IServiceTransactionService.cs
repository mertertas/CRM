
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IServiceTransactionService
    {
        IDataResult<List<ServiceTransaction>> GetAll();
        IDataResult<List<ServiceTransaction>> GetById(int serviceTransactionId);
        IResult Add(ServiceTransaction serviceTransaction);
        IResult Delete(ServiceTransaction serviceTransaction);
        IResult Update(ServiceTransaction serviceTransaction);
    }
}
