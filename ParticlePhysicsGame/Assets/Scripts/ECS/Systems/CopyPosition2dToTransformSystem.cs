using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.Entities;
using Unity.Transforms2D;
using UnityEngine;

[ExecuteInEditMode]
public class CopyPosition2dToTransform : ComponentSystem {

	private struct Group
	{
		public int Length;
		public ComponentArray<Transform> tranforms;
		public ComponentDataArray<Position2D> positions;
	}

	[Inject] private Group data;
	
	protected override void OnUpdate()
	{
		for (int i = 0; i < data.Length; i++)
		{
			var transform = data.tranforms[i];
			var position = data.positions[i].Value;
			transform.position = new Vector3(position.x, position.y, 0);
		}
	}
}
