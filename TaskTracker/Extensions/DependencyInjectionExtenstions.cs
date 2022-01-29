using AutoMapper;
using TaskTracker.MapperProfile;

namespace TaskTracker.Extensions
{
    public static class DependencyInjectionExtenstions
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProjectProfile());
                mc.AddProfile(new ObjectiveProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
