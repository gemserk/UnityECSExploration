using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class EmitterComponent : MonoBehaviour {
    public GameObject prefab;
    public float timeToNextEmit;
    public float timeBetweenEmits;
    public float emitRadius;
}