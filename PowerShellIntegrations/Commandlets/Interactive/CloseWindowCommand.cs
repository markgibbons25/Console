﻿using System.Management.Automation;

namespace Cognifide.PowerShell.PowerShellIntegrations.Commandlets.Interactive
{
    [Cmdlet(VerbsCommon.Close, "Window")]
    public class CloseWindowCommand : BaseShellCommand
    {
        protected override void ProcessRecord()
        {
            //PutMessage(new CloseWindowMessage());
            HostData.CloseRunner = true;
        }
    }
}