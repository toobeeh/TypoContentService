using LibGit2Sharp;
using Microsoft.Extensions.Options;
using tobeh.TypoContentService.Server.Config;

namespace tobeh.TypoContentService.Server.Service;

public class GitHandler
{
    private readonly GitConfig _config;
    private readonly ILogger<GitHandler> _logger;
    
    public GitHandler(IOptions<GitConfig> config, ILogger<GitHandler> logger)
    {
        _config = config.Value;
        _logger = logger;
        Directory.CreateDirectory(_config.Path);
    }
    
    public void AddFile(byte[] fileBytes, string fileName, string repoFilePath, string commitMessage)
    {
        _logger.LogTrace("AddFile({fileName}, {repoFilePath}, {commitMessage})", fileName, repoFilePath, commitMessage);
        
        // Clone the repository
        var repoPath = $"{_config.Path}/static-data-{DateTimeOffset.Now.ToUnixTimeMilliseconds()}";
        var cloneOptions = new CloneOptions
        {
            FetchOptions =
            {
                CredentialsProvider = CredentialsHandler
            }
        };
        Repository.Clone(_config.RepositoryUrl, repoPath, cloneOptions);

        // Open the repository
        using (var repo = new Repository(repoPath))
        {
            // Create a new file in the repository
            var absolutePath = Path.Combine(repoPath, repoFilePath, fileName);
            File.WriteAllBytes(absolutePath, fileBytes);

            // Stage the file
            Commands.Stage(repo, Path.Combine(repoFilePath, fileName));

            // Create the commit
            var author = new Signature("Palantir Data Commit", "dev.tobeh@gmail.com", DateTimeOffset.Now);
            repo.Commit("[🤖] " + commitMessage, author, author);

            // Set the remote repository URL
            var remote = repo.Network.Remotes["origin"];
            var options = new PushOptions
            {
                CredentialsProvider = CredentialsHandler
            };

            // Push the commit to the remote repository
            repo.Network.Push(remote, $"refs/heads/{repo.Head.FriendlyName}", options);
        }

        // Clean up the temporary repository
        ForceDeleteDirectory(repoPath);
        _logger.LogInformation("Added file {fileName}", fileName);
        
        return;

        Credentials CredentialsHandler(string url, string user, SupportedCredentialTypes cred) => new UsernamePasswordCredentials { Username = _config.AccessToken, Password = string.Empty };
    }
    
    private static void ForceDeleteDirectory(string path) 
    {
        var directory = new DirectoryInfo(path) { Attributes = FileAttributes.Normal };

        foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
        {
            info.Attributes = FileAttributes.Normal;
        }

        directory.Delete(true);
    }
}