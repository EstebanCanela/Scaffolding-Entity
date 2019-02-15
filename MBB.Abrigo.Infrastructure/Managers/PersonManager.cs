
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

        public void Add(PersonDTO p)
        {
            throw new NotImplementedException();
        }

        public void Edit(PersonDTO p)
        {
            throw new NotImplementedException();
        }

        public PersonDTO FindById(int Id)
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

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
