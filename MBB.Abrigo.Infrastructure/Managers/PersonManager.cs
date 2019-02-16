
using MBB.Abrigo.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBB.Abrigo.Infrastructure.IManagers;
using MBB.Abrigo.Infrastructure.IRepository;
using MBB.Abrigo.Core.DTO;
using MBB.Abrigo.Core.Models;

namespace MBB.Abrigo.Infrastructure.Managers
{
    public class PersonManager : IGenericManager<PersonDTO>
    {
        private UnitOfWork uOfW = new UnitOfWork();

        private IEnumerable<PersonDTO> convertObjectsToDTO (IEnumerable<Person> collectionPersons)
        {
            List<PersonDTO> aux = new List<PersonDTO>();
            foreach (Person item in collectionPersons)
            {
                PersonDTO auxDTO = new PersonDTO()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age
                };

                aux.Add(auxDTO);
            }

            return aux;
        }

        public string Add(PersonDTO p)
        {
            if(p != null)
            {
                var paramsNull = checkParamsToPerson(p);
                if (paramsNull != "0")
                {
                    return paramsNull;
                }

                Person insertPerson = new Person()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Age = p.Age
                };
                uOfW.PersonRepository.Add(insertPerson);
                uOfW.Save();
                return "Person has benn created";
            }
            else
            {
                return "Error created Person";
            }
        }

        private string checkParamsToPerson(PersonDTO p)
        {
            if (p.FirstName == null)
            {
                return "FirstName is null";
            }

            if (p.LastName == null)
            {
                return "LastName is null";
            }

            if (p.Age <= 0 )
            {
                return "Age <= 0";
            }

            return "0";
        }

        public string Edit(PersonDTO p)
        {

            if(p != null)
            {
                var paramsNull = checkParamsToPerson(p);
                if (paramsNull != "0")
                {
                    return paramsNull;
                }

                Person insertPerson = new Person()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Age = p.Age
                };
                uOfW.PersonRepository.Edit(insertPerson);
                uOfW.Save();
                return "Person has benn modified";
            }
            else
            {
                return "Person is null";
            }
        }

        public PersonDTO FindById(string Id)
        {
            Person auxPerson = uOfW.PersonRepository.FindById(Id);
            return new PersonDTO()
            {
                Id = auxPerson.Id,
                FirstName = auxPerson.FirstName,
                LastName = auxPerson.LastName,
                Age = auxPerson.Age
            };
        }

        public IEnumerable<PersonDTO> GetAll()
        {
            IEnumerable<Person> aux = uOfW.PersonRepository.GetAll();
            return convertObjectsToDTO(aux);

        }

        public string Remove(string Id)
        {
            Person personToRemove = uOfW.PersonRepository.FindById(Id);
            if(personToRemove != null)
            {
                uOfW.PersonRepository.Remove(Id);
                uOfW.Save();
                return "Person has been removed";
            }
            else
            {
                return "Person no exists";
            }
        }
    }
}
