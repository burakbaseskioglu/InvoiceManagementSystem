using InvoiceManagementSystem.Core.DataAccess.EntityFramework;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.DataAccess.Abstract
{
    public interface IApartmentRepository:IRepository<Apartment>
    {
        ApartmentDto GetApartmentWithManagement(int apartmentId);
    }
}
