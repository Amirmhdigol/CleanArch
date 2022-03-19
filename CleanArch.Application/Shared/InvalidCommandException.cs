namespace CleanArch.Application.Shared
{
    public class InvalidCommandException : BaseCommandException
    {
        public InvalidCommandException()
        {

        }
        public InvalidCommandException(string message) : base(message)
        {

        }
    }
}
