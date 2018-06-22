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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        public int DaysToBirthday()
        {
            DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime nextBirthday = new DateTime(now.Year, Birthdate.Month, Birthdate.Day);
            if (now.CompareTo(nextBirthday) > 0)
            {
                nextBirthday = new DateTime(now.Year + 1, Birthdate.Month, Birthdate.Day);
            }
            return Convert.ToInt32((nextBirthday - now).TotalDays);
        }
    }
}