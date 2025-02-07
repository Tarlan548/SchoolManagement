namespace Exam.API.Extensions;

public static class ServiceRegistrationDockerSecrets
{
    public static async Task AddSecretsAsync(WebApplicationBuilder builder)
    {
        var secretPath = "/run/secrets";
        var secrets = new Dictionary<string, string?>();

        if (File.Exists(System.IO.Path.Combine(secretPath, "postgres-password")))
        {
            var postgresPassword = (await File.ReadAllTextAsync(System.IO.Path.Combine(secretPath, "postgres-password"))).Trim();
            secrets.Add("ConnectionStrings:PostgreDB", $"Host=schoolmanagement_db_exam;Port=5434;Database=SchoolManagement;User ID=web_user;Password={postgresPassword};TrustServerCertificate=True");
        }
        builder.Configuration.AddInMemoryCollection(secrets);
    }
}
