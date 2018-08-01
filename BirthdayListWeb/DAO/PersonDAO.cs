using BirthdayListWeb.Models;
using BirthdayManagerWeb.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace BirthdayListWeb.DAO
{
    public class PersonDAO
    {
        public void Add(Person person)
        {
            using (var context = new BirthdayListContext())
            {
                context.People.Add(person);
                context.SaveChanges();
            }
        }

        public List<Person> List()
        {
            using (var context = new BirthdayListContext())
            {
                return context.People.ToList();
            }
        }

        public Person FindById(int id)
        {
            using (var context = new BirthdayListContext())
            {
                return context.People.Where(p => p.Id == id).FirstOrDefault();
            }
        }

        public List<Person> FindByNameAndSurname(string search)
        {
            using (var context = new BirthdayListContext())
            {
                return context.People.Where(p => (p.Name + p.Surname).Contains(search)).ToList();
            }
        }

        public List<Person> FindBirthdayToday()
        {
            using (var context = new BirthdayListContext())
            {
                DateTime now = DateTime.Now;
                return context.People.Where(
                    p => p.Birthdate.Day == now.Day && p.Birthdate.Month == now.Month
                ).ToList();
            }
        }

        public void Update(Person person)
        {
            using (var context = new BirthdayListContext())
            {
                context.Entry(person).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var context = new BirthdayListContext())
            {
                var person = new Person { Id = id };
                context.Entry(person).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}