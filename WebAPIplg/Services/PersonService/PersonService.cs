using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using WebAPIplg.Data;
using WebAPIplg.DTO.Person;
using WebAPIplg.Models;

namespace WebAPIplg.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public PersonService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponce<List<PersonDTO>>> GetAllPeople()
        {
            var serviceResponce = new ServiceResponce<List<PersonDTO>>();
            try
            {
                var dbPeople = await _context.Person.ToListAsync();
                if (dbPeople == null)
                    throw new Exception($"Unable to retrieve people");

                serviceResponce.Value = dbPeople.Select(p => _mapper.Map<PersonDTO>(p)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = ex.Message;
            }
            return serviceResponce;
        }

        public async Task<ServiceResponce<PersonDTO>> GetPersonById(int id)
        {
            var serviceResponce = new ServiceResponce<PersonDTO>();
            try
            {
                var dbPerson = await _context.Person.FirstOrDefaultAsync(p => p.Id == id);
                if (dbPerson == null)
                    throw new Exception($"Person was not found");

                serviceResponce.Value = _mapper.Map<PersonDTO>(dbPerson);
                serviceResponce.Message = "Success";
            }
            catch (Exception ex)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = ex.Message;
            }
            return serviceResponce;
        }

        public async Task<ServiceResponce<AddPersonDTO>> AddPerson(AddPersonDTO personDto)
        {
            var serviceResponce = new ServiceResponce<AddPersonDTO>();
            try
            {
                var person = _mapper.Map<Person>(personDto);

                _context.Person.Add(person);
                await _context.SaveChangesAsync();

                serviceResponce.Value = personDto;
                serviceResponce.Message = "Person was added";
            }
            catch (Exception ex)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = ex.Message;
            }

            return serviceResponce;
        }

        public async Task<ServiceResponce<PersonDTO>> UpdatePerson(PersonDTO personDto)
        {
            var serviceResponce = new ServiceResponce<PersonDTO>();
            try
            {
                var dbPerson = await _context.Person.FirstOrDefaultAsync(p => p.Id == personDto.Id);
                if (dbPerson == null)
                    throw new Exception($"Unable to update. Person was not found");

                //Update all field with mapper
                _mapper.Map(personDto, dbPerson);
                await _context.SaveChangesAsync();

                serviceResponce.Value = personDto;
                serviceResponce.Message = "Person was updated";
            }
            catch (Exception ex)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = ex.Message;
            }

            return serviceResponce;
        }

        public async Task<ServiceResponce<PersonDTO>> DeletePerson(int id)
        {
            var serviceResponce = new ServiceResponce<PersonDTO>();

            try
            {
                var dbPerson = await _context.Person.FirstOrDefaultAsync(p => p.Id == id);
                if (dbPerson == null)
                    throw new Exception($"Unable to delete. Person was not found");

                _context.Person.Remove(dbPerson);
                await _context.SaveChangesAsync();

                serviceResponce.Value = _mapper.Map<PersonDTO>(dbPerson);
                serviceResponce.Message = "Person was deleted";
            }
            catch (Exception ex)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = ex.Message;
            }

            return serviceResponce;
        }
    }
}
