﻿namespace Microsoft.AspNetCore.Mvc.Versioning.Conventions
{
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    /// <content>
    /// Provides additional implementation specific to Microsoft ASP.NET Core.
    /// </content>
    [CLSCompliant( false )]
    public partial class ControllerApiVersionConventionBuilder
    {
        /// <summary>
        /// Attempts to get the convention for the specified action method.
        /// </summary>
        /// <param name="method">The <see cref="MethodInfo">method</see> representing the action to retrieve the convention for.</param>
        /// <param name="convention">The retrieved <see cref="IApiVersionConvention{T}">convention</see> or <c>null</c>.</param>
        /// <returns>True if the convention was successfully retrieved; otherwise, false.</returns>
        protected override bool TryGetConvention( MethodInfo method, [NotNullWhen( true )] out IApiVersionConvention<ActionModel>? convention )
        {
            if ( ActionBuilders.TryGetValue( method, out var actionBuilder ) )
            {
                return ( convention = actionBuilder ) != null;
            }

            convention = default;
            return false;
        }
    }
}