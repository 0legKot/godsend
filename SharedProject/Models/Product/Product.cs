﻿// <copyright file="Product.cs" company="Godsend Team">
// Copyright (c) Godsend Team. All rights reserved.
// </copyright>

namespace Godsend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    ///
    /// </summary>
    public class Product : IEntity
    {
        public Product()
        { }
        [JsonConstructor]
        public Product(ProductInformation Info)
        {
            this.Info = new ProductInformation();
            (this.Info as ProductInformation).Name = Info.Name;
            (this.Info as ProductInformation).Description = Info.Description;
            (this.Info as ProductInformation).State = Info.State;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
       // public ProductInformation Info { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [JsonIgnore]
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the entity information.
        /// </summary>
        /// <value>
        /// The entity information.
        /// </value>

        public Information Info { get; set; }

        public override string ToString()
        {
            return "Product: " + Info?.Name ?? "Hello include";
        }
    }

    /// <summary>
    ///
    /// </summary>
    public class ProductWithSuppliers
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the suppliers.
        /// </summary>
        /// <value>
        /// The suppliers.
        /// </value>
        public IEnumerable<SupplierAndPrice> Suppliers { get; set; }

        public IEnumerable<EAV<string>> StringProps { get; set; }

        public IEnumerable<EAV<decimal>> DecimalProps { get; set; }

        public IEnumerable<EAV<int>> IntProps { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class SupplierAndPrice
    {
        /// <summary>
        /// Gets or sets the supplier.
        /// </summary>
        /// <value>
        /// The supplier.
        /// </value>
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }
    }

    public class ProductInfosAndCount
    {
        public IEnumerable<ProductInformation> Infos { get; set; }

        public int Count { get; set; }
    }
}
