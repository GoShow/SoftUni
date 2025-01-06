using LogForU.Core.Enums;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Models;
using System;

namespace LogForU.Core.Appenders;

public class ConsoleAppender : Appender
{
    public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        : base(layout, reportLevel)
    {
    }

    public override void AppendMessage(Message message)
    {
        Console.WriteLine(string.Format(Layout.Format, message.CreatedTime, message.ReportLevel, message.Text));

        MessagesAppended++;
    }
}
