using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebVotingApp.Entities;
using WebVotingApp.Models;
using WebVotingApp.Models.Validators;
using WebVotingApp.Repository;
using WebVotingApp.Repository.Interface;
using WebVotingApp.Services;
using WebVotingApp.Services.Interface;

namespace WebVotingApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            services.AddAutoMapper(this.GetType().Assembly);

            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IVoterService, VoterService>();

            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IVoterRepository, VoterRepository>();
            

            services.AddScoped<IValidator<CreateCandidateDto>,CreateCandidateDtoValidator>();
            services.AddScoped<IValidator<CreateVoterDto>, CreateVoterDtoValidator>();

            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebVotingApp", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("FrontEndClient", builder =>

                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        //.WithOrigins(Configuration["AllowedOrigins"])

                    );
            });
            services.AddDbContext<VotingDbContext>
               (options => options.UseSqlServer(Configuration.GetConnectionString("VotingAppDbConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("FrontEndClient");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebVotingApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
