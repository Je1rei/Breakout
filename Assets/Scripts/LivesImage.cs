using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesImage : MonoBehaviour
{
    [SerializeField] private GameObject[] _livesImage;
    private Ball _ball;

    private void Start()
    {
        _ball = FindAnyObjectByType<Ball>();

        EnableLiveImage();
    }

    public void DisableLiveImage()
    {
        _livesImage[_ball.Live].SetActive(false);
    }

    public void EnableLiveImage()
    {
        for (int i = 0; i < _ball.Live; i++)
        {
            _livesImage[i].SetActive(true);
        }
    }
}
