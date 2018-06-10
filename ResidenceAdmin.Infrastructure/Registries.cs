using Autofac;
using ResidenceAdmin.DataAccess;
using ResidenceAdmin.DataAccess.Contracts;
using ResidenceAdmin.Persistency;

namespace ResidenceAdmin.Infrastructure
{
    public class Registries
    {
        public void Registry()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<IPersistencyContext>().As<PersistencyContext>();
            builder.RegisterType<IUserRepository>().As<UserRepository>();

        }
    }
}
