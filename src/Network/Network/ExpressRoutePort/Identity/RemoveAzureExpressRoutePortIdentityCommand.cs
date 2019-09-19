﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Azure.Commands.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRoutePortIdentity"), OutputType(typeof(PSExpressRoutePort))]
    public class RemoveAzureExpressRoutePortIdentityCommand : NetworkBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The ExpressRoutePort")]
        public PSExpressRoutePort ExpressRoutePort { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ExpressRoutePort.Identity == null)
            {
                throw new ArgumentException("ExpressRoutePort doesn't have an identity assigned to it.");
            }

            base.ExecuteCmdlet();
            this.ExpressRoutePort.Identity = null;
            WriteObject(this.ExpressRoutePort);
        }
    }
}
