namespace Common.Extension;

public class UnhandledExceptionFilterAttributeExtension : Exception
{
    public UnhandledExceptionFilterAttributeExtension() : base("Log information has not been defined yet!!!")
    {
    }
}
