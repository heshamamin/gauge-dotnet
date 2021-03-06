﻿// Copyright 2018 ThoughtWorks, Inc.
//
// This file is part of Gauge-CSharp.
//
// Gauge-CSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Gauge-CSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Gauge-CSharp.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.Linq;
using Gauge.Dotnet.Wrappers;
using Gauge.Messages;

namespace Gauge.Dotnet.Processors
{
    public class ExecutionEndingProcessor : HookExecutionProcessor
    {
        public ExecutionEndingProcessor(IExecutionOrchestrator executionOrchestrator, IAssemblyLoader assemblyLoader,
            IReflectionWrapper reflectionWrapper)
            : base(executionOrchestrator, assemblyLoader, reflectionWrapper)
        {
        }

        protected override string HookType => "AfterSuite";

        protected override string CacheClearLevel => SuiteLevel;

        protected override List<string> GetApplicableTags(Message request)
        {
            return GetExecutionInfo(request)?.CurrentSpec?.Tags?.ToList() ?? new List<string>();
        }

        protected override ExecutionInfo GetExecutionInfo(Message request)
        {
            return request.ExecutionEndingRequest.CurrentExecutionInfo;
        }
    }
}