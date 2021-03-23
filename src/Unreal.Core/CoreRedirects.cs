﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Unreal.Core.Attributes;

namespace Unreal.Core
{
    public static class CoreRedirects
    {
        public static Dictionary<string, string> PartialRedirects { get; private set; } = new Dictionary<string, string>();
        private static readonly Dictionary<string, string> _redirects = new Dictionary<string, string>();

        static CoreRedirects()
        {
            Assembly[] currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            IEnumerable<Type> netFields = currentAssemblies.SelectMany(x => x.GetTypes()).Where(x => x.GetCustomAttribute<NetFieldExportGroupAttribute>() != null);

            foreach(Type type in netFields)
            {
                NetFieldExportGroupAttribute exportGroupAttribute = type.GetCustomAttribute<NetFieldExportGroupAttribute>();
                PartialNetFieldExportGroup partialAttribute = type.GetCustomAttribute<PartialNetFieldExportGroup>();
                IEnumerable<RedirectPathAttribute> redirectAttributes = type.GetCustomAttributes<RedirectPathAttribute>();

                if(partialAttribute != null)
                {
                    PartialRedirects.Add(partialAttribute.PartialPath, exportGroupAttribute.Path);
                }

                if(redirectAttributes != null)
                {
                    foreach (RedirectPathAttribute redirectAttribute in redirectAttributes)
                    {
                        _redirects.TryAdd(redirectAttribute.Path, exportGroupAttribute.Path);
                    }
                }
            }
        }

        public static string GetRedirect(string path)
        {
            if (_redirects.TryGetValue(path, out string result))
            {
                return result;
            }

            return path;
        }
    }
}
