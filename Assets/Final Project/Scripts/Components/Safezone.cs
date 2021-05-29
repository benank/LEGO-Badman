using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LastSafezone
{
    private static Vector3 position;
    
    public static void SetLastSafePosition(Vector3 position)
    {
        LastSafezone.position = position;
    }
    
    public static Vector3 GetLastSafePosition()
    {
        return LastSafezone.position;
    }
}

public class Safezone : MonoBehaviour
{
    [Tooltip("Optional: provide a fixed point that the player will always spawn at, instead of their safe position")]
    [SerializeField] private Transform safePoint;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (safePoint == null)
            {
                LastSafezone.SetLastSafePosition(other.gameObject.transform.position);
            }
            else
            {
                LastSafezone.SetLastSafePosition(safePoint.position);
            }
        }
    }
}
