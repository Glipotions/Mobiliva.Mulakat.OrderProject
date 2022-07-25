using Serilog;

namespace Mobiliva.Mulakat.Core.CrossCuttingConcerns.Logging.Serilog
{
    /// <ÖZET>
    /// Loglama dönüş tiplerini gösterir.
    /// </summary>
    public abstract class LoggerServiceBase
    {
        public ILogger Logger;
        public void Verbose(string message) => Logger.Verbose(message);
        //public void Trace(string message) => Logger.Trace(message);
        public void Fatal(string message) => Logger.Fatal(message);
        public void Info(string message) => Logger.Information(message);
        public void Warn(string message) => Logger.Warning(message);
        public void Debug(string message) => Logger.Debug(message);
        public void Error(string message) => Logger.Error(message);
    }
}
