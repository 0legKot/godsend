﻿// <copyright file="IProductRepository.cs" company="Godsend Team">
// Copyright (c) Godsend Team. All rights reserved.
// </copyright>

namespace Godsend
{
    using System;
    using System.Collections.Generic;
    using Godsend.Models;

    /// <summary>
    /// 
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Gets the product with suppliers.
        /// </summary>
        /// <param name="productInfoId">The product information identifier.</param>
        /// <returns></returns>
        ProductWithSuppliers GetProductWithSuppliers(Guid productInfoId);

        IEnumerable<Category> Categories();
    }
}