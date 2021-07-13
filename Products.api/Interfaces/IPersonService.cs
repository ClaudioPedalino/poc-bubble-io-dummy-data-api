using Products.api.Models;
using Products.api.Models.Queries;
using System;

namespace Products.api.Interfaces
{
    public interface IPersonService
    {
        DataResult<PersonDto> GetAll(GetPersonQuery request);

        PersonDto GetById(Guid personId);

        Result Create(PersonDto request);

        Result Delete(Guid personId);
    }
}