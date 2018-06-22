using BirthdayListWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BirthdayListWeb.DAO
{
    public class PersonDAO
    {
        private IDbConnection dbConnection; 

        public PersonDAO()
        {
            dbConnection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=BirthdayListDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public void Add(Person person)
        {
            dbConnection.Open();
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "INSERT INTO Person(Name, Surname, Birthdate) VALUES (@Name, @Surname, @Birthdate)";
            dbCommand.Parameters.Add(new SqlParameter("Name", person.Name.Trim()));
            dbCommand.Parameters.Add(new SqlParameter("Surname", person.Surname.Trim()));
            dbCommand.Parameters.Add(new SqlParameter("Birthdate", person.Birthdate));
            dbCommand.ExecuteNonQuery();
        }

        public Person FindById(int id)
        {
            dbConnection.Open();
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "SELECT * FROM Person WHERE Id = @Id";
            dbCommand.Parameters.Add(new SqlParameter("Id", id));
            IDataReader dataReader = dbCommand.ExecuteReader();

            Person person;
            if (dataReader.Read())
            {
                person = new Person
                {
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Name = Convert.ToString(dataReader["Name"]),
                    Surname = Convert.ToString(dataReader["Surname"]),
                    Birthdate = Convert.ToDateTime(dataReader["Birthdate"])
                };
            }
            else
            {
                person = null;
            }

            dbConnection.Close();
            return person;
        }

        public List<Person> FindByNameAndSurname(string search)
        {
            dbConnection.Open();
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "SELECT * FROM Person WHERE CONCAT(Name, ' ', Surname) LIKE @search";
            dbCommand.Parameters.Add(new SqlParameter("search", "%"+search+"%"));
            IDataReader dataReader = dbCommand.ExecuteReader();

            List<Person> people = new List<Person>();
            while (dataReader.Read())
            {
                people.Add(new Person
                {
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Name = Convert.ToString(dataReader["Name"]),
                    Surname = Convert.ToString(dataReader["Surname"]),
                    Birthdate = Convert.ToDateTime(dataReader["Birthdate"])
                });
            }
            dbConnection.Close();
            return people;
        }

        public List<Person> FindBirthdayToday()
        {
            dbConnection.Open();
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "SELECT * FROM Person WHERE MONTH(Birthdate) = MONTH(GETDATE()) AND DAY(Birthdate) = DAY(GETDATE())";
            IDataReader dataReader = dbCommand.ExecuteReader();

            List<Person> people = new List<Person>();
            while (dataReader.Read())
            {
                people.Add(new Person
                {
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Name = Convert.ToString(dataReader["Name"]),
                    Surname = Convert.ToString(dataReader["Surname"]),
                    Birthdate = Convert.ToDateTime(dataReader["Birthdate"])
                });
            }
            dbConnection.Close();
            return people;
        }

        public List<Person> GetAll()
        {
            dbConnection.Open();
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "SELECT * FROM Person";
            IDataReader dataReader = dbCommand.ExecuteReader();

            List<Person> people = new List<Person>();
            while (dataReader.Read())
            {
                people.Add(new Person
                {
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Name = Convert.ToString(dataReader["Name"]),
                    Surname = Convert.ToString(dataReader["Surname"]),
                    Birthdate = Convert.ToDateTime(dataReader["Birthdate"])
                });
            }
            dbConnection.Close();
            return people;
        }

        public void Update(Person person)
        {
            dbConnection.Open();
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "UPDATE Person SET Name = @Name, Surname = @Surname, Birthdate = @Birthdate WHERE Id = @Id";
            dbCommand.Parameters.Add(new SqlParameter("Id", person.Id));
            dbCommand.Parameters.Add(new SqlParameter("Name", person.Name.Trim()));
            dbCommand.Parameters.Add(new SqlParameter("Surname", person.Surname.Trim()));
            dbCommand.Parameters.Add(new SqlParameter("Birthdate", person.Birthdate));
            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        public void Remove(int id)
        {
            dbConnection.Open();
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "DELETE FROM Person WHERE Id = @Id";
            dbCommand.Parameters.Add(new SqlParameter("Id",id));
            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }
    }
}