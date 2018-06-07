﻿// <copyright file="Order.cs" company="Godsend Team">
// Copyright (c) Godsend Team. All rights reserved.
// </copyright>

namespace Godsend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    public enum Status
    {
        Ready = 0,
        Shipped = 1,
        Cancelled = 2,
        Processing = 3,

            // ...
    }

    public abstract class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public IdentityUser Customer { get; set; }

        public IEnumerable<OrderPartDiscrete> DiscreteItems { get; set; }

        public IEnumerable<OrderPartWeighted> WeightedItems { get; set; }

        public DateTime Ordered { get; set; }

        public Status Status { get; set; }

        public DateTime? Done { get; set; }
    }

    public class SimpleOrder : Order
    {
    }

    public abstract class OrderPart
    {
        [Key]
        public Guid Id { get; set; }

        public Product Product { get; set; }

        public Supplier Supplier { get; set; }
    }

    public class OrderPartDiscrete : OrderPart
    {
        public int Quantity { get; set; }
    }

    public class OrderPartWeighted : OrderPart
    {
        public double Weight { get; set; }
    }
}
