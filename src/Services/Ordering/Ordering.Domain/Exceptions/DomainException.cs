namespace Ordering.Domain.Exceptions
{
    class DomainException : Exception
    {
        public DomainException(string message) 
            : base($"Domain exception: {message} thrown from Domain layer")
        {
        }
    }
}
