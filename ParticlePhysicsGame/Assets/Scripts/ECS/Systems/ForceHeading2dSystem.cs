
using DefaultNamespace.ECS.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms2D;
using UnityEngine;

namespace ECS.Systems
{
    public class ForceHeading2dSystem : ComponentSystem
    {
        private struct ActorGroup
        {
            public int Length;
            [ReadOnly] public ComponentDataArray<Position2D> position;
            [ReadOnly]  public ComponentDataArray<Heading2D> heading;
            [ReadOnly] public ComponentDataArray<ForceHeading2d> forceHeading2d;
        }

        private struct ParticleGroup
        {
            public int Length;
            [ReadOnly] public ComponentDataArray<Position2D> position;
            public ComponentDataArray<Heading2D> heading;
            [ReadOnly] public ComponentDataArray<Particle> particle;
        }
        
        
        [Inject] private ActorGroup actorGroup;
        [Inject] private ParticleGroup particleGroup;
        
        
        protected override void OnUpdate()
        {
            for (int i = 0; i < actorGroup.Length; i++)
            {
                var actorPos = actorGroup.position[i].Value;
                var actorHeading = actorGroup.heading[i];
                var actorForceHeading = actorGroup.forceHeading2d[i];

                for (int j = 0; j < particleGroup.Length; j++)
                {
                    var pPos = particleGroup.position[j].Value;

                    if (math.distance(pPos, actorPos) <= actorForceHeading.radius)
                    {
                        particleGroup.heading[j] = actorHeading;
                    }
                }
            }
        }
    }
}