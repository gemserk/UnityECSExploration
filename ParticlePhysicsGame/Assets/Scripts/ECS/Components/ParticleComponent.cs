using System;
using Unity.Entities;

namespace DefaultNamespace.ECS.Components
{
    [Serializable]
    public struct Particle : IComponentData
    {
        
    }

    public class ParticleComponent : ComponentDataWrapper<Particle>
    {
    }
}