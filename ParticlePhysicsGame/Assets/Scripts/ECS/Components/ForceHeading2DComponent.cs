using System;
using Unity.Entities;

namespace DefaultNamespace.ECS.Components
{
    [Serializable]
    public struct ForceHeading2d : IComponentData
    {
        public float radius;
    }

    public class ForceHeading2DComponent : ComponentDataWrapper<ForceHeading2d>
    {
    }
}