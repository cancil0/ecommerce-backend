using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class MediaDal : GenericDal<Media>, IMediaDal
    {
        public MediaDal(Context context) : base(context) { }
    }
}