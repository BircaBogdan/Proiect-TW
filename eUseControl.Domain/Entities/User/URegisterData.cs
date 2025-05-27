using System;
using eUseControl.Domain.Enums;

namespace eUseControl.Domain.Entities.User
{
     public class URegisterData
     {
          public string UserName { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }
          public DateTime RegisterDateTime { get; set; }
          public string RegisterIp { get; set; }
          public string Role { get; set; }
          public LevelAcces Level { get; set; }
     }
}