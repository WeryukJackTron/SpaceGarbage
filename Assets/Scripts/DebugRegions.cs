using UnityEditor;
using UnityEngine;

public class DebugRegions : MonoBehaviour
{
    public void OnDrawGizmos()
    {
        const float y = 5.0f - 10.0f/3.0f;
        Gizmos.color = Color.white;
        Gizmos.DrawLine(new Vector3(-10.0f, y, 0.0f), new Vector3(10.0f, y, 0.0f));
        Gizmos.DrawLine(new Vector3(-10.0f, -y, 0.0f), new Vector3(10.0f, -y, 0.0f));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-10.0f, 2.5f, 0.0f), new Vector3(10.0f, 2.5f, 0.0f));
    }
}
