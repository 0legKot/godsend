﻿// <copyright file="SupplierController.cs" company="Godsend Team">
// Copyright (c) Godsend Team. All rights reserved.
// </copyright>

namespace Godsend.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Godsend.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class SupplierController : Controller
    {
        private ISupplierRepository repository;

        public SupplierController(ISupplierRepository repo)
        {
            repository = repo;
        }

        [HttpGet("[action]")]
        public IEnumerable<Supplier> All()
        {
            return repository.Suppliers;
        }

        [HttpGet("[action]/{id:Guid}")]
        public Supplier Detail(Guid id)
        {
            return repository.Suppliers.FirstOrDefault(x => x.Id == id);
        }
    }
}