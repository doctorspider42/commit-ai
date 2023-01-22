using CommitAI.OpenAi;

using Microsoft.Extensions.Configuration;

#pragma warning disable CS0162 // Unreachable code detected
var configuration = new ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .AddUserSecrets<Program>();
var config = configuration.Build();

var openApiConfiguration = new OpenApiConfiguration(config["OpenAi:ApiKey"]!);
var openAiService = new OpenAiService(openApiConfiguration, new HttpClient());

var diff = args.FirstOrDefault();

if (diff == null)
{
    Console.WriteLine("Please provide a diff as an argument");
    return;
}

Console.WriteLine(diff);
return;

var commitMessage = await openAiService.GetAnswerAsync(diff);
Console.WriteLine(commitMessage);
#pragma warning restore CS0162 // Unreachable code detected