namespace Common.Config;

public class SwaggerConfig
{
    public enum VersioningType
    {
        None, CustomHeader, QueryString, AcceptHeader
    }

    public static VersioningType CurrentVersioningMethod = VersioningType.None;
    public static string QueryStringParam { get; private set; } = "api-version";
    public static string CustomHeaderParam { get; private set; } = "x-version";
    public static string AcceptHeaderParam { get; private set; } = "v-version";

    public static void UseCustomHeaderApiVersion(string parameterName)
    {
        CurrentVersioningMethod = VersioningType.CustomHeader;
        CustomHeaderParam = parameterName;
    }

    public static void UseQueryStringApiVersion()
    {
        QueryStringParam = "api-version";
        CurrentVersioningMethod = VersioningType.QueryString;
    }

    public static void UseQueryStringApiVersion(string parameterName)
    {
        CurrentVersioningMethod = VersioningType.QueryString;
        QueryStringParam = parameterName;
    }

    public static void UseAcceptHeaderApiVersion(string paramName)
    {
        CurrentVersioningMethod = VersioningType.AcceptHeader;
        AcceptHeaderParam = paramName;
    }
}

