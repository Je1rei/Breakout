using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField, Range(0.5f, 10f)] private float _speed;

    private void Update()
    {
        PaddleMove();
    }

    private void PaddleMove()
    {
        float translation = Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;

        transform.Translate(translation, 0, 0);
    }
}
