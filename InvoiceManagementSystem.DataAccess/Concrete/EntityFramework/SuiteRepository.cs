using InvoiceManagementSystem.Core.DataAccess.EntityFramework;
using InvoiceManagementSystem.DataAccess.Abstract;
using InvoiceManagementSystem.Entity.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManagementSystem.Entity.Entities.Dto;

namespace InvoiceManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class SuiteRepository : EfRepository<Suite, AppDbContext>, ISuiteRepository
    {
        public List<SuiteDto> GetAllSuitesWithUsers()
        {
            using (var context = new AppDbContext())
            {
                var suites = context.Suites.Include(x => x.User).Where(x => x.IsActive == true).Select(x => new SuiteDto
                {
                    Block = x.Block,
                    Floor = x.Floor,
                    Type = x.Type,
                    NumberOfSuite = x.NumberOfSuite,
                    Status = x.Status,
                    IsTenant = x.IsTenant,
                    OwnerId = x.User.Id,
                    SuiteOwner = $"{x.User.Firstname} {x.User.Lastname}",
                    IdentityNumber = x.User.IdentityNumber,
                    Email = x.User.Email,
                    Phone = x.User.Phone,
                    LicensePlate = x.User.LicensePlate
                });

                return suites.ToList();
            }
        }

        public SuiteDto GetSuiteWithUser(int suiteId)
        {
            using (var context = new AppDbContext())
            {
                var suite = context.Suites.Include(x => x.User).Where(x => x.Id == suiteId && x.IsActive == true).Select(x => new SuiteDto
                {
                    SuiteId = x.Id,
                    Block = x.Block,
                    Floor = x.Floor,
                    Type = x.Type,
                    NumberOfSuite = x.NumberOfSuite,
                    Status = x.Status,
                    ApartmentId = x.ApartmentId,
                    IsTenant = x.IsTenant,
                    OwnerId = x.User.Id,
                    SuiteOwner = $"{x.User.Firstname} {x.User.Lastname}",
                    IdentityNumber = x.User.IdentityNumber,
                    Email = x.User.Email,
                    Phone = x.User.Phone,
                    LicensePlate = x.User.LicensePlate
                }).FirstOrDefault();
                return suite;
            }
        }
    }
}
