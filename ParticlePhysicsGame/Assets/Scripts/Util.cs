
using Unity.Mathematics;
using Unity.Transforms2D;
using UnityEditor;
using UnityEngine;

public class Util
{
    
    [MenuItem ("CONTEXT/Heading2DComponent/Normalize")]
    static void NormalizeHeading2D (MenuCommand command) {
        Heading2DComponent heading = (Heading2DComponent)command.context;
        heading.Value = new Heading2D{ Value = math.normalize(heading.Value.Value)};
    }
}