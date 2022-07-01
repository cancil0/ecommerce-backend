using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class AddressDal : GenericDal<Address>, IAddressDal
    {
        public AddressDal(Context context) : base(context) {}
    }
}
