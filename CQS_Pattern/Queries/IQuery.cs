

using System.Collections.Generic;

namespace CQS_Pattern
{
    public interface IQuery<Entity, Virtual> 
    {
        public Entity GetById(Virtual id);

        public ICollection<Entity> GetAll();
    }
}
