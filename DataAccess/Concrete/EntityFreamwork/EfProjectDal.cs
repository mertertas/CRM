using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfProjectDal : EntityFrameworkRepositoryBase<Project, CRMContext>,IProjectDal
    {
    }
}
