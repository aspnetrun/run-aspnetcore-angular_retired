using System;

namespace AspnetRunAngular.Core.Entities.Base
{
    public abstract class Entity : EntityBase<int>
    {
        public Guid? CreatedById { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid? UpdatedById { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
