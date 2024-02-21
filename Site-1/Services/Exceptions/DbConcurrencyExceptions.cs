namespace Site_1.Services.Exceptions
{
    public class DbConcurrencyExceptions: ApplicationException
    {
        public DbConcurrencyExceptions( string message): base(message) { }    
    }
}
