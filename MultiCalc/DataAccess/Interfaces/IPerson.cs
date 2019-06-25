using System;
using System.Collections.Generic;
using DataAccess.Models.Entity;

namespace DataAccess.Contexts
{
    public interface IPerson
    {
        List<Calculation> GetCalculationData(Guid personId);
        Guid? GetPersonId(string personName);
    }
}