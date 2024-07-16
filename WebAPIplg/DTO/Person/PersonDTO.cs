﻿using WebAPIplg.Models;

namespace WebAPIplg.DTO.Person
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
    }
}
