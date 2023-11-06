using OsintSharp.Ui.Cli.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsintSharp.Ui.Cli;

internal class CommandManager 
{
    ICommandAsync _command;

    public void SetCommand(ICommandAsync command)
    {
        _command = command;
    }

    public async Task StartAsync()
    {
        await _command.StartAnalysisAsync();
    }

}
