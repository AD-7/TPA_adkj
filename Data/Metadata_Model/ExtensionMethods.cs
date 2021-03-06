﻿using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Reflection.Metadata_Model
{
    
    internal static class ExtensionMethods
    {

        internal static bool GetVisible(this Type type)
        {
            return type.IsPublic || type.IsNestedPublic || type.IsNestedFamily || type.IsNestedFamANDAssem;
        }
        internal static bool GetVisible(this MethodBase method)
        {
            return method != null && (method.IsPublic || method.IsFamily || method.IsFamilyAndAssembly);
        }
        internal static string GetNamespace(this Type type)
        {
            string ns = type.Namespace;
            return ns != null ? ns : string.Empty;
        }

    }
}
