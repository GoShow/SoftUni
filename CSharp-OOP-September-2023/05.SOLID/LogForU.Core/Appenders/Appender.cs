using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Models;

namespace LogForU.Core.Appenders;

public abstract class Appender : IAppender
{
    protected Appender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
    {
        Layout = layout;
        ReportLevel = reportLevel;
    }

    public ILayout Layout { get; private set; }

    public ReportLevel ReportLevel { get; set; }

    public int MessagesAppended { get; protected set; }

    public abstract void AppendMessage(Message message);

    public override string ToString()
        => $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesAppended}";

}
