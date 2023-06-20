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

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddInMemorySubscriptions();

        // HotChocolate GraphQL
        services.AddGraphQLServer()
            .AddQueryType(q => q.Name("Query"))
                .AddType<QueryUser>()
                .AddType<QueryChat>()
            .AddMutationType(m => m.Name("Mutation"))
                .AddTypeExtension<MutateUser>()
                .AddTypeExtension<MutateMessage>()
            .AddSubscriptionType(s => s.Name("Subscription"))
                .AddTypeExtension<ChatSub>()
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            // .AllowIntrospection()
            // .AddInstrumentation()
            .AddInMemoryQueryStorage()
            .AddInMemorySubscriptions()
            .InitializeOnStartup();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseWebSockets();

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
