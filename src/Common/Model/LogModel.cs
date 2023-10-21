namespace Common.Model;

public class LogModel
{
    //Thời gian thực hiện log, GMT 0
    public string Timestamp { get; set; } = default!;

    // Full data mà mình log
    public string FullData { get; set; } = default!;

    //Ipv4 của server
    public string SourceIp { get; set; } = default!;

    //Tên của service
    public string ServiceName { get; set; } = default!;

    // Level log
    public string Level { get; set; } = default!;

    public ContextMap ContextMap { get; set; } = default!;

    //log time theo GMT + 7
    public string CustomTimestamp { get; set; } = default!;
}

public abstract class ContextMap
{
    //ID của process
    public string ClientMessageId { get; set; } = default!;

    //httprequest hoặc httpresponse
    public string LogType { get; set; } = default!;

    //tổng thời gian xử lý khi logType = httpresponse, đơn vị millisecond làm tròn 3 chữ số sau dấu chấm
    public string Duration { get; set; } = default!;
}

