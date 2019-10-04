using GraphQlSample.Schema;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQlSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<Repository>();

            services.AddSingleton<CustomerSchema>();
            services.AddSingleton<ProductSchema>();
            services.AddSingleton<ProductTypeEnum>();
            services.AddSingleton<PurchaseSchema>();
            services.AddSingleton<CustomerQuery>();
            services.AddSingleton<GraphQlService>();

            services.AddSingleton<ISchema, MySchema>();
            services.AddGraphQL(_ =>
            {
                _.EnableMetrics = true;
                _.ExposeExceptions = true;
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseGraphQL<ISchema>("/graphql");

            app.UseGraphiQLServer( new GraphiQLOptions
            {
                GraphQLEndPoint = "/graphql",
                GraphiQLPath = "/graphiql"
            });
        }
    }
}
