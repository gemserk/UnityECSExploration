using System;
using Unity.Entities;
using Unity.Mathematics;

namespace DefaultNamespace.ECS.Components
{
    [Serializable]
    public struct BoxBound : IComponentData
    {
        public float2 bounds;
    }

    public class BoxBoundComponent : ComponentDataWrapper<BoxBound>
    {
        
    }
}