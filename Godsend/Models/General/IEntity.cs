﻿namespace Godsend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IEntity
    {
         Guid Id { get; set; }
         Information EntityInformation { get; set; }
        //public virtual void SetIds() {
        //    Id = Guid.NewGuid();
        //    EntityInformation.Id = Guid.NewGuid();
        //}
    }
}
