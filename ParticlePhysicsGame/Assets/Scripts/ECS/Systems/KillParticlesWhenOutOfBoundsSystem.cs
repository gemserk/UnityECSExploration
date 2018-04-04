using System.Collections.Generic;
using DefaultNamespace.ECS.Components;
using Unity.Entities;
using Unity.Transforms2D;
using UnityEngine;

namespace ECS.Systems
{
    public class KillParticlesWhenOutOfBoundsSystem : ComponentSystem
    {
        private struct ActorGroup
        {
            public ComponentDataArray<Position2D> position;
            public ComponentDataArray<BoxBound> boxBounds;
            public int Length;
        }
        
        private struct ParticleGroup
        {
            public ComponentDataArray<Position2D> position;
            public ComponentDataArray<Particle> particle;
            public EntityArray entity;
            public GameObjectArray gameObject;
            public int Length;
        }
        
        [Inject] private ActorGroup actorGroup;
        [Inject] private ParticleGroup particleGroup;
        
        List<GameObject> objectsToDestroy = new List<GameObject>();
        
        protected override void OnUpdate()
        {
            objectsToDestroy.Clear();
            for (int i = 0; i < actorGroup.Length; i++)
            {
                var actorPos = actorGroup.position[i].Value;
                var actorBound = actorGroup.boxBounds[i];

                var minX = actorPos.x - actorBound.bounds.x / 2.0f;
                var maxX = actorPos.x + actorBound.bounds.x / 2.0f;
                var minY = actorPos.y - actorBound.bounds.y / 2.0f;
                var maxY = actorPos.y + actorBound.bounds.y / 2.0f;

                for (int j = 0; j < particleGroup.Length; j++)
                {
                    var pPos = particleGroup.position[j].Value;

                    if (pPos.x < minX || pPos.x > maxX ||
                        pPos.y < minY || pPos.y > maxY)
                    {
//                        var entity = particleGroup.entity[j];
//                        this.PostUpdateCommands.DestroyEntity(entity);
                        var go = particleGroup.gameObject[j];
                        //GameObject.Destroy(go);
                        objectsToDestroy.Add(go);
                    }
                }
            }

            foreach (var gameObject in objectsToDestroy)
            {
                GameObject.Destroy(gameObject);
            }
            objectsToDestroy.Clear();
        }
        
        
    }
}