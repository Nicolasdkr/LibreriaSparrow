// Data/LibreriaContextFactory.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LibreriaSparrow.Api.Data;

public class LibreriaContextFactory : IDesignTimeDbContextFactory<LibreriaContext>
{
	public LibreriaContext CreateDbContext(string[] args)
	{
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.AddUserSecrets<Program>()
			.Build();

		var connectionString = configuration.GetConnectionString("Default");

		var optionsBuilder = new DbContextOptionsBuilder<LibreriaContext>();
		optionsBuilder.UseSqlServer(connectionString);

		return new LibreriaContext(optionsBuilder.Options);
	}
}