﻿using System;
using System.Management.Automation;
using Sitecore;
using Sitecore.Security.Accounts;
using Sitecore.SecurityModel;

namespace Cognifide.PowerShell.PowerShellIntegrations.Commandlets.Governance
{
    public class GovernanceUserBaseCommand : GovernanceBaseCommand
    {
        [Parameter]
        public User User { get; set; }

        protected override void BeginProcessing()
        {
            if (User == null)
            {
                User = Context.User;
            }
        }

        public void SwitchUser(Action action)
        {
            using (new SecurityStateSwitcher(SecurityState.Enabled))
            {
                if (string.Equals(User.Name, Context.User.LocalName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(User.Domain.Name, Context.User.Domain.Name, StringComparison.OrdinalIgnoreCase))
                {
                    action();
                }
                else
                {
                    using (new UserSwitcher(User))
                    {
                        action();
                    }
                }
            }
        }
    }
}