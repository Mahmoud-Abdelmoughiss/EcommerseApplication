﻿using EcommerseApplication.Models;
using EcommerseApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        Ishipper shipper;
        private readonly string NotFoundMSG = "Data Not Found";
        private readonly string BadRequistMSG = "Invalid Input Data";
        private readonly string SuccessMSG = "Data Found Successfuly";
        public ShipperController(Ishipper _shipper)
        {
            this.shipper = _shipper;
        }
        [HttpGet]
        public IActionResult getAllShippers()
        {
            List<Shipper> shippers;
            try { shippers = shipper.getAll(); }
            catch
            {
                return Ok(new { Success = false, Message = NotFoundMSG, Data = "notFound" });
            }
            
            return Ok(new { Success = true, Message = SuccessMSG, Data = shippers });
           
        }
        [HttpGet("{id:int}")]
        public IActionResult getShipperById(int id)
        {
            Shipper shipp;
            try
            {
                shipp = shipper.getByID(id);

            }
            catch
            {
                return NotFound(new { Success = false, Message = NotFoundMSG, Data = "notFound" });
            }
            return Ok(new { Success = true, Message = SuccessMSG, Data = shipp });
        }
        [HttpGet("{Name:alpha}")]
        public IActionResult getByName(string Name)
        {
            return Ok(shipper.getByName(Name));
        }
        [HttpPost]
        public IActionResult AddNewShipper(Shipper sh)
        {
            if (ModelState.IsValid)
            {
                try { shipper.insert(sh); 
                }
                catch
                {
                    return BadRequest(new { Success = false, Message = BadRequistMSG, Data = "dontSaved" });
                }

            }
            else
            {
                return BadRequest(new { Success = false, Message = BadRequistMSG, Data = "dontSaved" });
            }
            
            return Ok(new { Success = true, Message = SuccessMSG, Data = "saved" });
        }
        [HttpPut("{id:int}")]
        public IActionResult upDateShipper(int id ,Shipper sh)
        {
            try
            {
                shipper.update(id, sh);
            }
            catch
            {
                return BadRequest(new { Success = false, Message = BadRequistMSG, Data = "dontSaved" });
            }

            return Ok(new { Success = true, Message = SuccessMSG, Data = "Updated" });

        }
        [HttpDelete]
        public IActionResult deleteShipper([FromBody]int id)
        {
            try
            {
                shipper.delete(id);
            }
            catch
            {
                return BadRequest(new { Success = false, Message = BadRequistMSG, Data = "dontDeleted" });
            }

            return Ok(new { Success = true, Message = SuccessMSG, Data = "deleted" });
            
           
        }
        /*[HttpGet("{id:int}/{name}")]
        public IActionResult getٍِِall(int id,string name)
        {
            return Ok("hello");
        }
        [HttpGet("{ID:int}/{Name:alpha}/{officePhone}")]
        public IActionResult add([FromRoute]Shipper sh)
        {
            return Ok("hello");
        }*/

        

    }
}
