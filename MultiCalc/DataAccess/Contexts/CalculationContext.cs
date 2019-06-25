using DataAccess.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace DataAccess.Contexts
{
    public class CalculationContext : DbContext, IPerson, ICalculate
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Calculation> Calculations { get; set; }

        public CalculationContext() : base("Data Source=WIN-TUSPCUMO3U6;Initial Catalog=TestCalc;Integrated Security=True")
        {
        }

        static CalculationContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CalculationContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Calculation>().HasRequired(x => x.Person).WithMany().WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
           // implementation IPerson 1)
        public Guid? GetPersonId(string personName)
        {
            var personId = Persons.FirstOrDefault(x => x.Name == personName)?.Id;
            if (personId == null)
            {
                var person = Persons.Add(new Person
                {
                    Name = personName
                });
                SaveChanges();
                personId = person.Id;
            }

            return personId;
        }


           // implementation IPerson 2)
        public List<Calculation> GetCalculationData(Guid personId)
        {
            var person = GetPersonData(personId);
            return person.Calculations ;
        }
        
        public Person GetPersonData(Guid personId)
        {
            return Persons.FirstOrDefault(x => x.Id == personId);
        }

        public void Calc(string personName, string a, string b, string operation, string result)
        {
            
            var personId = (Guid)GetPersonId(personName);
            Calc(personId, a, b, operation, result);
        }
        
        //Implementation ICalculate 
        public void Calc(Guid personId, string a, string b, string operation, string result)
        {
            var person = GetPersonData(personId);
            if (person != null)
            {
                var calculation = new Calculation
                {
                    Person = person,
                    NumberA = a,
                    NumberB = b,
                    Op = operation,
                    Result = result
                };
                if (person.Calculations != null)
                {
                    person.Calculations.Add(calculation);
                }
                else
                {
                    person.Calculations = new List<Calculation> { calculation };
                }
                SaveChanges();
            }
        }
    }
}