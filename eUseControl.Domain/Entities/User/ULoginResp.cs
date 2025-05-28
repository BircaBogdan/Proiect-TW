using System;

namespace eUseControl.Domain.Entities.User
{
    public class ULoginResp
    {
        public bool Status { get; set; }
        public string StatusMsg { get; set; }
        public string Telefon { get; set; }

        // ✅ Adăugăm proprietatea Email
        public string Email { get; set; }
    }
}
