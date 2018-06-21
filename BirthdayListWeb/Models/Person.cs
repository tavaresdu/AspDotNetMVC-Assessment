using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BirthdayListWeb.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Sobrenome")]
        public string Surname { get; set; }

        [Required]
        [DisplayName("Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthdate { get; set; }
    }
}