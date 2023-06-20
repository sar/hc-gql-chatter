namespace hc_gql_chatter;

using HotChocolate.AspNetCore;
using HotChocolate.Data;
using HotChocolate.Execution.Options;
using HotChocolate.Language;
using HotChocolate.Types;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // HotChocolate GraphQL
        services.AddGraphQLServer()
            .AddQueryType(q => q.Name("Query"))
                .AddType<QueryUser>()
            .AddMutationType(m => m.Name("Mutation"))
                .AddTypeExtension<MutateUser>()
            // .AddSubscriptionType(s => s.Name("Subscription"))
            //     .AddTypeExtension<ChatSubscription>()
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            // .AllowIntrospection()
            // .AddInstrumentation()
            .AddInMemoryQueryStorage()
            .AddInMemorySubscriptions()
            .InitializeOnStartup();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });

            endpoints.MapGraphQL()
                .AllowAnonymous()
                .WithOptions(new GraphQLServerOptions()
                {
                    EnableGetRequests = false,
                    EnableSchemaRequests = true,
                    Tool = { Enable = true },
                });

            endpoints.MapBananaCakePop("/graphql/ide")
            .WithOptions(new GraphQLToolOptions()
            {
                Enable = true,
                IncludeCookies = true,
                DisableTelemetry = true,
            });
        });
    }
}
