namespace ProgrammeerOpdracht.Exceptions
{
    public class InvalidDocumentTypeException: Exception
    {
        public InvalidDocumentTypeException(string message): base(message) { 
        }
    }
}