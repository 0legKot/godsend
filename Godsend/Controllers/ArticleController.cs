﻿namespace Godsend.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Godsend.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private IArticleRepository repository;

        public ArticleController(IArticleRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("[action]")]
        public IEnumerable<ArticleInformation> All()
        {
            return repository.Articles.Select(a => a.Info);
        }

        [HttpGet("[action]/{id:Guid}")]
        public Article Detail(Guid infoId)
        {
            return repository.Articles.FirstOrDefault(x => x.Info.Id == infoId);
        }
    }

}