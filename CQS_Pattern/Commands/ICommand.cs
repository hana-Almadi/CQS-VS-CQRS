

namespace CQS_Pattern
{
    public interface ICommand<Entity>
    {
        public void Insert(Entity entity);

        public void Update(Entity entity);
    }
}
