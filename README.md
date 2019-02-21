# Scaffolding-Entity Framework
Created a basic structured to a project in .Net with Entity Framework, Unit of Work, Repository Patter and Identity with JWT Access Token.

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

## Step 8 - Security
Install by console  `PM> Install-Package System.IdentityModel.Tokens.Jwt` after that create.


### Step 8.1
Add in `MBB.Abrigo.WebApi.Models.AccountViewModels.cs` a class for login model, for example:
```
public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
```

### Step 8.2 
Add in `MBB.Abrigo.WebApi.Controllers.AccountController.cs` a controller for login, for example:
```
public async Task<IHttpActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await UserManager.FindByEmailAsync(model.Username);
            
            if (user != null)
            {
                if (UserManager.CheckPassword(user, model.Password))
                {
                    var token = TokenGenerator.GenerateTokenJwt(model.Username);
                    return Ok(token);
                }
                else
                {
                   return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();

            }
        }
```
### Step 8.3
Add in `MBB.Abrigo.WebApi.Controllers.PersonController.cs` the authorization for the requests, for example:
```
// GET: api/Person
        [Authorize]
        public IEnumerable<PersonDTO> GetPersons()
        {
            return personManager.GetAll();
        }
```
### Step 8.4
Create a class for the token generation in `MBB.Abrigo.WebApi.Security`. See more in that directory.

### Step 8.5
Add in `MBB.Abrigo.WebApi.App_Start.WebApiConfig.cs` the next line of code:
```
public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración de rutas y servicios de API
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler()); //THIS LINE TO ADD

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
```

### Step 8.6
Add in `MBB.Abrigo.WebApi.WebApi.cs` the next line of code:
```
 <appSettings>
    <add key="JWT_SECRET_KEY"     value="clave-secreta-api"/>
    <add key="JWT_AUDIENCE_TOKEN" value="http://localhost:49220"/>
    <add key="JWT_ISSUER_TOKEN"   value="http://localhost:49220"/>
    <add key="JWT_EXPIRE_MINUTES" value="30"/>   
  </appSettings>
 ```

###### Remember to use JWT with the Bearer Token in the postman or another web debugger.
 
 
## Contact
For any questions or suggestions, communicate with (estebancanela@gmail.com)


![Alt Text](https://media.giphy.com/media/3orifd7YPQLkSftPqw/giphy.gif)

