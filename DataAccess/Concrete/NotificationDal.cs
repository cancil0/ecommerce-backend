using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class NotificationDal : GenericDal<Notification>, INotificationDal
    {
        public NotificationDal(Context context) : base(context) { }
    }
}