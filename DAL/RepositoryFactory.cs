namespace DAL
{
    public class RepositoryFactory
    {
        public static IRepository CreateRepository()
        {
            return new EFRepository(new Entities.NWindEntities());
        }
    }
}
