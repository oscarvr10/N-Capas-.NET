namespace DAL
{
    public class RepositoryFactory
    {
        public static IRepository CreateRepository()
        {
            var context = new Entities.NWindEntities();
            context.Configuration.ProxyCreationEnabled = false;
            return new EFRepository(context);
        }
    }
}
