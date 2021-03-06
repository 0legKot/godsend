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
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Supplier controller
    /// </summary>
    /// <seealso cref="Controllers.EntityController{Supplier}" />
    [Route("api/[controller]")]
    public class SupplierController : EntityController<Supplier>
    {
        public SupplierController(SupplierRepository repo, IHubContext<NotificationHub> hubContext, ILogger<EntityController<Supplier>> logger)
            : base(hubContext, logger)
        {
            repository = repo;
        }

        [HttpGet("[action]/{id:Guid}")]
        public Supplier Detail(Guid id)
        {
            var sup = repository.GetEntity(id);
            repository.Watch(sup);
            return sup;
        }
    }
}
