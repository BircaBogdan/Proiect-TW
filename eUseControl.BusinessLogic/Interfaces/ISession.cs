using System.Web;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface ISession
     {
          ULoginResp UserLogin(ULoginData data);
     }
}
