using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField, Range(-1f, -10f)] private float _deadPosition;
    [SerializeField] private Ball _ball;

    private void FixedUpdate()
    {
        if (_ball != null) 
        {
            if (_ball.transform.position.y <= _deadPosition)
            {
                _ball.ResetBall();
                _ball.WasteLive();
            }
        }
    }

}
