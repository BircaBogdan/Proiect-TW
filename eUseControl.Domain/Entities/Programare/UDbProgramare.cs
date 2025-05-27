using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eUseControl.Domain.Enums;

namespace eUseControl.Domain.Entities.Programare
{
    public class UDbProgramare
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nume pacient")]
        [StringLength(50)]
        public string Nume { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Număr de telefon")]
        [Phone]
        public string Telefon { get; set; }

        [Required]
        [Display(Name = "Data programării")]
        [DataType(DataType.Date)]
        public DateTime DataProgramare { get; set; }

        [Required]
        [Display(Name = "Ora programării")]
        [DataType(DataType.Time)]
        public TimeSpan OraProgramare { get; set; }

        [Required]
        [Display(Name = "Specialitate")]
        [StringLength(50)]
        public string Specialitate { get; set; }

        [Display(Name = "Mesaj opțional")]
        [StringLength(500)]
        public string Mesaj { get; set; }
        [Required]
        [Display(Name = "Stare programare")]
        public StareProgramare Stare { get; set; } = StareProgramare.InAsteptare;
     }
}
