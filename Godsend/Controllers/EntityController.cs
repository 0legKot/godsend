﻿namespace Godsend.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Godsend.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;

    public abstract class EntityController<TEntity> : Controller
    {
        protected IRepository<TEntity> repository;

        [HttpGet("[action]")]
        public virtual IEnumerable<TEntity> All()
        {
            return repository.Entities;
        }

        [HttpDelete("[action]/{id:Guid}")]
        public virtual IActionResult Delete([FromBody]Guid id)
        {
            try
            {
                repository.DeleteEntity(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("[action]/{id:Guid}")]
        public virtual IActionResult CreateOrUpdate([FromBody]TEntity entity)
        {
            try
            {
                repository.SaveEntity(entity);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("[action]/{id:Guid}")]
        public virtual IActionResult Edit([FromBody]TEntity entity)
        {
            return CreateOrUpdate(entity);
        }

        [HttpPut("[action]/{id:Guid}")]
        public virtual IActionResult Create([FromBody]TEntity entity)
        {
            return CreateOrUpdate(entity);
        }

        /*[HttpGet("[action]/{id:Guid}")]
        public virtual TEntity Detail(Guid id)
        {
            return repository.GetEntity(id);
        }*/
    }
}
