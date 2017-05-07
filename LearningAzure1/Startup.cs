using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningAzure1.Startup))]
namespace LearningAzure1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
