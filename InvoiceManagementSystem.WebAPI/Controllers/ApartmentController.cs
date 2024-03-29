﻿using InvoiceManagementSystem.Business.Abstract;
using InvoiceManagementSystem.Core.Constant;
using InvoiceManagementSystem.Core.Utilities.Attribute;
using InvoiceManagementSystem.Entity.Entities.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AuthorizeRoles(RoleName.Management)]
    public class ApartmentController : Controller
    {
        private readonly IApartmentBusiness _apartmentBusiness;

        public ApartmentController(IApartmentBusiness apartmentBusiness)
        {
            _apartmentBusiness = apartmentBusiness;
        }

        [HttpGet("SearchApartmentByName")]
        public IActionResult Search(string apartmentName)
        {
            return Ok(_apartmentBusiness.SearchByName(apartmentName));
        }

        [HttpGet("GetApartments")]
        public IActionResult GetApartments()
        {
            return Ok(_apartmentBusiness.GetAll());
        }

        [HttpGet("GetApartmentById")]
        public IActionResult GetApartmentById(int apartmentId)
        {
            return Ok(_apartmentBusiness.GetApartmentById(apartmentId));
        }

        [HttpPost("AddApartment")]
        public IActionResult AddApartment(ApartmentDto apartment)
        {
            return Ok(_apartmentBusiness.Insert(apartment));
        }

        [HttpPut("UpdateApartment")]
        public IActionResult UpdateApartment(ApartmentDto apartment)
        {
            return Ok(_apartmentBusiness.Update(apartment));
        }

        [HttpDelete("DeleteApartment")]
        public IActionResult DeleteApartment(int apartmentId)
        {
            return Ok(_apartmentBusiness.Delete(apartmentId));
        }

        //[HttpPost("CreateSuites")]
        //public IActionResult CreateSuites(CreateSuiteDto suiteDto) 
        //{
        //    return Ok(_apartmentBusiness.CreateSuites(suiteDto));
        //} 
    }
}
