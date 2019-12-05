using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class CatalogType : BaseEntity, IAggregateRoot
    {
        public string Type { get; set; }
    }
}
