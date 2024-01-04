namespace TonicTodoList.Console.Repo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        public void Add(TEntity entity);
        public IEnumerable<TEntity> GetAll();
        public TEntity GetNthItem(int n);
        public void Update(TEntity entity);
        void DeleteAll();
        int Count();
    }
}
