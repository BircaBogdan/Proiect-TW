using System;

namespace eUseControl.Domain.Entities.User
{
     public class URegisterData
     {
          public string UserName { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }
          public DateTime RegisterDateTime { get; set; }
          public string RegisterIp { get; set; }
     }
}