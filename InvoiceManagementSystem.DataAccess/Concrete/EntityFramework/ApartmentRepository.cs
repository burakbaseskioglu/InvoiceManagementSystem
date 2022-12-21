using InvoiceManagementSystem.Core.DataAccess.EntityFramework;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class ApartmentRepository : EfRepository<Apartment, AppDbContext>, IApartmentRepository
    {
        public ApartmentDto GetApartmentWithManagement(int apartmentId)
        {
            throw new NotImplementedException();
        }
    }
}
