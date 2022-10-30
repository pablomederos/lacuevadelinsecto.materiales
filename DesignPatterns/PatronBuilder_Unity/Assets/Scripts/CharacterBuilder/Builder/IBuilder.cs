using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CharacterBuilder.Builder
{
    public interface IBuilder
    {
        IBuilder SetPosition(Vector3 position);
        IBuilder SetVelocity(float velocity);

        Character Build();
    }
}
