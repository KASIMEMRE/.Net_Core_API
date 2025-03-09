namespace WebAPI.Services{
    public class ConsoleLogger : ILoggerService{
        public void Write(string message){
            Console.WriteLine("[ConsoleLOgger] - "+message);
        }
    }
}