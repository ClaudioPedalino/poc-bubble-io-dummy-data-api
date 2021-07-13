using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Products.api.Data;
using Products.api.Entities;
using Products.api.Interfaces;
using Products.api.Models;
using Products.api.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Products.api.Services
{
    public class PersonService : IPersonService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PersonService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DataResult<PersonDto> GetAll(GetPersonQuery request)
        {
            var result = _context.Persons.AsNoTracking();
            var total = result.Count();

            // filter here

            var paginatedResult = result
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            var response = _mapper.Map<List<PersonDto>>(paginatedResult);

            return DataResult<PersonDto>.Success(
                data: response,
                totalCount: total,
                pageSize: request.PageSize,
                totalPages: (total / request.PageSize) + 1
                );
        }

        public PersonDto GetById(Guid personId)
        {
            var result = _context.Persons.FirstOrDefault(x => x.PersonId == personId);

            return _mapper.Map<PersonDto>(result);
        }

        public Result Create(PersonDto request)
        {
            var entity = _mapper.Map<Person>(request);

            _context.Add(entity);
            _context.SaveChanges();
            return Result.Success($"Create {entity.FirstName} {entity.LastName}");
        }

        public Result Delete(Guid personId)
        {
            var entity = _context.Persons.FirstOrDefault(x => x.PersonId == personId);
            if (entity == null)
                return Result.NotFound($"No person found with id: {personId}");

            _context.Remove(entity);
            _context.SaveChanges();
            return Result.Success($"Delete person {entity.FirstName} {entity.LastName}");
        }
    }
}