using CommitAI.OpenAi;

using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
                    .AddJsonFile($"appsettings.json")
                    .AddUserSecrets<Program>();
var config = configuration.Build();

var openApiConfiguration = new OpenApiConfiguration(config["OpenAi:ApiKey"]);
var openAiService = new OpenAiService(openApiConfiguration, new HttpClient());