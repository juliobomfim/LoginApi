using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            var dateTimeNow = DateTime.Now;
            Id = new Guid();
            Changed = dateTimeNow;
            Created = dateTimeNow;
        }

        public Guid Id { get; set; }
        public DateTime Changed { get; set; }
        public DateTime Created { get; set; }

    }
}
