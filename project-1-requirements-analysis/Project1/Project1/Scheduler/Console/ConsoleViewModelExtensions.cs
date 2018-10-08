namespace Project1.Scheduler.Console
{
    public static class ConsoleViewModelExtensions
    {
        public static void WriteLine(this IConsoleViewModel viewModel, string message)
        {
            viewModel.ConsoleText += message + "\n";
        }

        public static void WriteLine(this IConsoleViewModel viewModel, string format, params object[] values)
        {
            WriteLine(viewModel, string.Format(format, values));
        }
    }
}
