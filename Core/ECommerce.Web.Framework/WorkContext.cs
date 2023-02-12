using ECommerce.Share.Abstractions;

namespace ECommerce.Web.Framework;

public class WorkContext : IWorkContext
{
    public int GetCurrentUserId()
    {
        return 5; //todo:impl
    }
}