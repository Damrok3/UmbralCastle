using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MyFunctions
{
    public static bool IsInsideCollider(GameObject ob, Vector3 point)
    { 
        Vector3 closest = Vector3.zero;
        if (ob.GetComponent<Collider2D>() != null)
        {
            closest = ob.GetComponent<Collider2D>().ClosestPoint(point);
        }
        else if(ob.GetComponent<EdgeCollider2D>() != null)
        {
            closest = ob.GetComponent<EdgeCollider2D>().ClosestPoint(point);
        }
        return closest == point;
    }

    public static Vector2 GetMouseWorldPosition()
    {
        Vector3 screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane + 1;
        Vector2 position = Camera.main.ScreenToWorldPoint(screenPosition);
        return position;
    }

    public static float GetVectorAngle(Vector3 directionVec)
    {
        float angleInRadians = Mathf.Atan2(directionVec.y, directionVec.x);
        return angleInRadians * Mathf.Rad2Deg;
    }
}

