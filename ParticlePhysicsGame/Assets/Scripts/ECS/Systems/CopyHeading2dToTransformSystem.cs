using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms2D;
using UnityEngine;

[ExecuteInEditMode]
public class CopyHeading2dToTransform : ComponentSystem {

	private struct Group
	{
		public int Length;
		public ComponentArray<Transform> tranforms;
		public ComponentDataArray<Heading2D> heading;
	}

	[Inject] private Group data;
	
	protected override void OnUpdate()
	{
		for (int i = 0; i < data.Length; i++)
		{
			var transform = data.tranforms[i];
			var heading = data.heading[i].Value;
			//transform.rotation = Quaternion.LookRotation(new Vector3(heading.x, heading.y, 0), Vector3.forward);

			if (!heading.Equals(new float2(0f, 0f)))
			{
				Quaternion quaternion = Quaternion.LookRotation(new float3(heading.x, 0, heading.y), new float3(0f, 1f, 0));
				
				transform.eulerAngles = new Vector3(0, 0, -quaternion.eulerAngles.y);

			}
		}
	}
}
