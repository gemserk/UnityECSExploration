using UnityEngine;

namespace DefaultNamespace
{
    [ExecuteInEditMode]
    public class QuaternionTesterComponent : MonoBehaviour
    {
        public Vector3 heading;
        public Vector3 headingNormalized;
        public Quaternion quaternion;
        public Vector3 up;

        public Vector3 eulers;

        public void Update()
        {
            headingNormalized = heading.normalized;
            quaternion = Quaternion.LookRotation(headingNormalized, up);
            eulers = quaternion.eulerAngles;
        }
    }
}