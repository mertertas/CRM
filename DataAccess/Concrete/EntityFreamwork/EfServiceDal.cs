using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfServiceDal : EntityFrameworkRepositoryBase<Service, CRMContext>,IServiceDal
    {
    }
}
