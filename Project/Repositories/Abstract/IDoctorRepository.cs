using System;
using System.Collections.Generic;
using Project.Model;

namespace Project.Repositories.Abstract
{
    public interface IDoctorRepository : IRepository<Doctor, long>
    {
        Doctor GetByEmail(string email);
        List<Doctor> GetBySpecialization(string specialization);
    }
}
