using CommandLine;

namespace Scavenger
{
    public class Program
    {
        private static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<StartOptions, InstallOptions, UninstallOptions, StatusOptions>(args)
                .MapResult(
                    (StartOptions opts) => ServiceUtility.StartServiceDirectly(opts),
                    (InstallOptions opts) => ServiceUtility.RunRegistAndReturnExitCode(opts),
                    (UninstallOptions opts) => ServiceUtility.RunUnregistAndeReturnExitCode(opts),
                    (StatusOptions opts) => ServiceUtility.RunStatusAndReturnExitCode(opts),
                    errs => 1);
        }
    }
}