using eUseControl.Domain.Entities.User;
using System.Web;

public interface ISession
{
     ULoginResp UserLogin(ULoginData data);
     URegisterResp UserRegister(URegisterData data);
     HttpCookie GenCookie(string username);
     UserMinimal GetUserByCookie(string apiCookieValue);
}