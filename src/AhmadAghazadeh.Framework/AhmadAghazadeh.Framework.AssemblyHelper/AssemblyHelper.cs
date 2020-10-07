using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AhmadAghazadeh.Framework.AssemblyHelper
{
    public class AssemblyHelper
    {
        private static readonly List<Assembly> LoadedAssemblies;
        private readonly string _nameSpace;
        static AssemblyHelper()
        {
            LoadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic).ToList();
        }


        public AssemblyHelper(string nameSpace)
        {
            _nameSpace = nameSpace;

            var loadedPaths = LoadedAssemblies
                .Where(a => a.FullName!.Contains(_nameSpace))
                .Select(a => a.Location)
                .ToList();

            var referencedPaths = Directory
                .GetFiles(AppDomain.CurrentDomain.BaseDirectory, _nameSpace + "*.dll", SearchOption.AllDirectories);
            var toLoad = referencedPaths
                .Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase))
                .ToList();
            toLoad.ForEach(path =>
                LoadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));
        }

        private IEnumerable<Assembly> GetAllAssemblies()
        {
            var result = LoadedAssemblies
                .Where(a => a.FullName!.Contains(_nameSpace)).ToList();
            return result;
        }
        public IEnumerable<Assembly> GetAssemblies(Type type)
        {
            var baseClassname = type.Name;


            return GetAllAssemblies().SelectMany(a => a.GetTypes())
                .Where(a => a.BaseType != null && a.BaseType.Name == baseClassname)
                .Select(a => a.Assembly).ToList();
        }
        public IEnumerable<Type> GetTypes(Type type)
        {
            var baseClassName = type.Name;

            return GetAllAssemblies().SelectMany(a => a.GetTypes()).Where(a =>
                a.BaseType != null && a.BaseType.Name == baseClassName && a.IsClass && !a.IsAbstract).ToList();
        }

        public IEnumerable<Type> GetClassByInterface(Type baseInterFace)
        {
            var baseClassName = baseInterFace.Name;

            var result = GetAllAssemblies().SelectMany(a => a.GetTypes()).Where(a =>
                a.GetInterfaces().Any(b => b.Name == baseClassName) && a.IsClass && !a.IsAbstract).ToList();
            return result;
        }
        public IEnumerable<object> GetInstanceByInterface(Type baseInterFace)
        {
            var baseClassName = baseInterFace.Name;

            var allTypes = GetAllAssemblies().SelectMany(a => a.GetTypes()).ToList();
            var baseClasses = allTypes.Where(a => a.GetInterfaces().Any(b => b.Name == baseClassName && a.IsClass && !a.IsAbstract)).Distinct().ToList();
            var activatorClasses = baseClasses.Select(Activator.CreateInstance).ToList();
            return activatorClasses;
        }
    }
}
