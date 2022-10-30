using Assets.Scripts.CharacterBuilder.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CharacterBuilder
{
    internal static class Director
    {
        public static IBuilder Builder<T>() where T: IBuilder
        {
            return Activator.CreateInstance(typeof(T)) as IBuilder;
        }
    }
}
