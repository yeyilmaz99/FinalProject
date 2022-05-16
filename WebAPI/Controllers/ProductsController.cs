﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        // Loosely coupled -- gevşek bağlı
        //naming convention
        //IoC Container-- Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //swagger
            //dependency chain
            
            var result = _productService.GetAll();
            if(result.Success== true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
