using CommandLine;

namespace Scavenger
{
    [Verb("start", HelpText = "Start application directly.")]
    internal class StartOptions
    {
    }

    [Verb("regist", HelpText = "Regist Scavenger service.")]
    internal class InstallOptions
    {
    }

    [Verb("unregist", HelpText = "Unregist Scavenger service.")]
    internal class UninstallOptions
    {
    }

    [Verb("status", HelpText = "Check service status.")]
    internal class StatusOptions
    {
    }
}