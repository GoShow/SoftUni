using LogForU.Core.Enums;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Models;

namespace LogForU.Core.Appenders.Interfaces;

public interface IAppender
{
    ILayout Layout { get; }

    ReportLevel ReportLevel { get; set; }

    int MessagesAppended { get; }

    void AppendMessage(Message message);
}
