# Scaffolding-Entity Framework
Created a basic structured to a project in .Net with Entity Framework, Unit of Work, Repository Patter and Identity (AuthO).

To create a new CRUD for a Entity you must do:

## Step 1 
Create in `MBB.Abrigo.Core.Models` model your Entity

```
  public class Person
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }       
    }
```

## Step 2 
Create in `MBB.Abrigo.Core.DTO` DTO your Entity (DTO will be seen for a Client)

```
public class PersonDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
    }
```

## Step 3
You should add a table in DB, for this in `MBB.Abrigo.Infrastructure` in class `BaseContext.cs` insert the next line:
```
public DbSet<Person> Persons { get; set; }
```

## Step 4 
Create in `MBB.Abrigo.Infrastructure.IRepository` an interface for your repository, after this you should create in `MBB.Abrigo.Infrastructure.Repository` your repository.

## Step 5
In `MBB.Abrigo.Infrastructure` in class `UnitOfWork.cs` you should add a repository (Singleton Pattern) for example:
```
public PersonRepository PersonRepository
        {
            get
            {
                if (this.personRepository == null)
                {
                    this.personRepository = new PersonRepository(context);
                }
                return personRepository;
            }
        }
```

## Step 6
Create in `MBB.Abrigo.Infrastructure.IManager` an interface for the operations your controller will receive, after that implement this operations in `MBB.Abrigo.Infrastructure.Manager`

## Step 7
Create in `MBB.Abrigo.WebApi.Controller` the controller which will receive the requests of the client, the controller should make use of the manager. For example:
```
public class PersonController : ApiController
    {
        private PersonManager personManager = new PersonManager();

        // GET: api/Person
        public IEnumerable<PersonDTO> GetPersons()
        {
            return personManager.GetAll();
        }

}
```

## Contact
For any questions or suggestions, communicate with (estebancanela@gmail.com)


![Alt Text](https://media.giphy.com/media/3orifd7YPQLkSftPqw/giphy.gif)

