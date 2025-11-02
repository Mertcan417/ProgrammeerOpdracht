namespace ProgrammeerOpdracht.Exceptions
{

    public class PatientIdRequiredException : Exception
    {
        public PatientIdRequiredException(string message) : base(message)
        {
        }
    }
}
