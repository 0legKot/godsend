﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Godsend.Models
{
    public abstract class Supplier
    {
        public Guid Id { get; set; }

        public SupplierInformation Info { get; set; }
    }

    public class SimpleSupplier : Supplier { }
}
