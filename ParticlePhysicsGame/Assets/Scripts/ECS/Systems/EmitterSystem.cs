using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms2D;
using UnityEngine;

namespace ECS.Systems
{
    public class EmitterSystem : ComponentSystem
    {
        private struct Group
        {
            public ComponentArray<EmitterComponent> emitter;
            public ComponentDataArray<Position2D> position;
            public ComponentDataArray<Heading2D> heading;
            public int Length;
        }


        [Inject] private Group data;
        
        
        protected override void OnUpdate()
        {
            float dt = Time.deltaTime;

            for (int i = 0; i < data.Length; i++)
            {
                var emitter = data.emitter[i];
                emitter.timeToNextEmit -= dt;
                if (emitter.timeToNextEmit > 0)
                {
                    continue;
                }

                emitter.timeToNextEmit += emitter.timeBetweenEmits;

                var posEmitter = data.position[i].Value;
                var headingEmitter = data.heading[i].Value;

                
               // Entity entity = EntityManager.Instantiate(emitter.prefab);
                
                GameObject go = GameObject.Instantiate(emitter.prefab);
//                go.GetComponent<Position2DComponent>().Value = new Position2D {Value = posEmitter};
//                go.GetComponent<Heading2DComponent>().Value =  new Heading2D {Value = headingEmitter};
//
//                var e = go.GetComponent<GameObjectEntity>().Entity;
//
//                var pos2d = EntityManager.GetComponentData<Position2D>(e);
//                var head2d = EntityManager.GetComponentData<Heading2D>(e);
//                
                var e = go.GetComponent<GameObjectEntity>().Entity;

                var posToEmit = posEmitter + (float2)UnityEngine.Random.insideUnitCircle * emitter.emitRadius;
                
                this.PostUpdateCommands.SetComponent(e, new Position2D {Value = posToEmit});
                this.PostUpdateCommands.SetComponent(e, new Heading2D {Value = headingEmitter});
                
                this.UpdateInjectedComponentGroups();
            }
        }
    }
}