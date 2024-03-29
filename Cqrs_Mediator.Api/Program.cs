using Cqrs_Mediator.Application.ApplicatioConfigrations;
using Cqrs_Mediator.InfraStructure.InfraStructureConfigrations;
using Cqrs_Mediator.InfraStructure.InfraStructureConfigrations.SettingSystem;

namespace Cqrs_Mediator.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
        /*     var sdsj= builder.Configuration.GetSection("Attechments").Get<FileConfig>();//get:create object
            FileConfig fileConfig=new FileConfig();
            builder.Configuration.GetSection("Attechments").Bind(fileConfig); //must create object*/
           builder.Services.Configure<FileConfig>(builder.Configuration.GetSection("Attechments")); //enable to inject Ioption  and this
                                                                                                    //best I Option Create object singleton
            // Add services to the container.
            builder.Services.AddApplicationConfigration();
            builder.Services.AddInfraStructureConfigrations(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection(); //convert any request http to https 

            app.UseAuthorization();


            app.MapControllers();//reound on cottrollers and take apis and make mapping on owner api then make route table
                                 

            app.Run();
        }
    }
}
