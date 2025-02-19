﻿namespace Base.Persistence.Repositories
{
    public class BaseEntity<TId> : IEntityTimestamps
    {
        public TId Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public BaseEntity()
        {
            Id = default;
        }

        public BaseEntity(TId id)
        {
            Id = id;
        }

    }
}
