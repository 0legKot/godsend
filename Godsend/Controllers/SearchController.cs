﻿// <copyright file="SearchController.cs" company="Godsend Team">
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
    using Microsoft.EntityFrameworkCore;

    public enum SearchType
    {
        All = 0,
        Products = 1,
        Suppliers = 2,

        // Orders = 3
    }

    // todo make procedure
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private DataContext context;

        public SearchController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("type/{t:int}/{term?}")]
        public AllSearchResult Find(SearchType t, string term)
        {
            switch (t)
            {
                case SearchType.All:
                    return FindAll(term);
                case SearchType.Products:
                    return new AllSearchResult { Products = FindProducts(term) };
                case SearchType.Suppliers:
                    return new AllSearchResult { Suppliers = FindSuppliers(term) };
                default:
                    return null;
            }
        }

        [HttpGet("all/{term?}")]
        public AllSearchResult FindAll(string term)
        {
            return new AllSearchResult
            {
                Products = FindProducts(term),
                Suppliers = FindSuppliers(term)
            };
        }

        [HttpGet("products/{term?}")]
        public IEnumerable<Product> FindProducts(string term)
        {
            return string.IsNullOrWhiteSpace(term)
                ? context.Products.Include(x => x.Info)
                : context.Products.Include(x => x.Info).Where(p => p.Info.Name.ToLower().Contains(term.ToLower()));
        }

        [HttpGet("suppliers/{term?}")]
        public IEnumerable<Supplier> FindSuppliers(string term)
        {
            return string.IsNullOrWhiteSpace(term)
                ? context.Suppliers.Include(x => x.Info)
                : context.Suppliers.Include(x => x.Info).Where(s => s.Info.Name.ToLower().Contains(term.ToLower()));
        }
    }
}