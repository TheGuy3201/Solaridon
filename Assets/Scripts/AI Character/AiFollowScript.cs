using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollowScript : MonoBehaviour
{
    public float _followSpeed;
    public Transform _target;
    public float _minDistance;

    private void Update()
    {
        if (Vector2.Distance(transform.position, _target.position) > _minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _followSpeed * Time.deltaTime);
        }
        else
        {
            //Input attack code
        }
    }
}
