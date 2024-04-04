using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVmanager : MonoBehaviour
{
    public float fovAngle = 90f;

    public Transform fovPoint;
    public List<GameObject> targets;

    public float range = 8f;

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (GameObject t in targets)
        {
            Vector2 dir = t.transform.position - fovPoint.position;
            float angle = Vector3.Angle(dir, fovPoint.up);
            RaycastHit2D hit = Physics2D.Raycast(fovPoint.position, dir, range);

            if (angle < fovAngle / 2)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.CompareTag("enemy"))
                    {
                        t.GetComponent<EnemyController>().isSeenByPlayer = true;
                    }
                    else
                    {
                        t.GetComponent<EnemyController>().isSeenByPlayer = false;
                    }
                } 
            }
            else
            {
                t.GetComponent<EnemyController>().isSeenByPlayer = false;
            }
        }
        
    }
}
