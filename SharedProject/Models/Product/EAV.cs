﻿// <copyright file="EAV.cs" company="Godsend Team">
// Copyright (c) Godsend Team. All rights reserved.
// </copyright>

namespace Godsend.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EAV<T>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        [JsonIgnore]
        public virtual Product Product { get; set; }

        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        /// <value>
        /// The property.
        /// </value>
        public virtual Property Property { get; set; }

        [JsonIgnore]
        public Guid PropertyId { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }

        public override string ToString()
        {
            return $"{Product.Info.Name}, {Property.Name}: {Value}";
        }
    }
}
