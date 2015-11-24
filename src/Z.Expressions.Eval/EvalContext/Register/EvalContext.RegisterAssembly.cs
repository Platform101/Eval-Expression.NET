﻿// Description: Evaluate, Compile and Execute C# code and expression at runtime
// Website & Documentation: https://github.com/zzzprojects/Eval-Expression.NET
// Forum: https://zzzprojects.uservoice.com/forums/327759-eval-expression-net
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Linq;
using System.Reflection;

namespace Z.Expressions
{
    public partial class EvalContext
    {
        /// <summary>Registers all types from all specified assemblies.</summary>
        /// <param name="assemblies">A variable-length parameters list containing assemblies to register type from.</param>
        /// <returns>An Fluent EvalContext.</returns>
        public EvalContext RegisterAssembly(params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes()
                    // REMOVE some conflicted namespace
                    .Where(x => x.FullName != "System.Deployment.Application.Manifest.File"
                                && x.FullName != "System.Net.WebRequestMethods+File"
                                && !x.FullName.StartsWith("System.Dynamic.Utils.CollectionExtensions")).ToArray();

                RegisterType(types);
            }

            return this;
        }
    }
}