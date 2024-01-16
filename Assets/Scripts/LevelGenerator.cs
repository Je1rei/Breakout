using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Vector2Int _sizeLevel;
    [SerializeField] private GameObject _brick;  
    [SerializeField] private Gradient _gradient;

    private void Awake()
    {
        for (int i = 0; i < _sizeLevel.x; i++)
        {
            for (int j = 0; j < _sizeLevel.y; j++)
            {
                GameObject newBrick = Instantiate(_brick, transform);
                newBrick.transform.position = transform.position + new Vector3((float)((_sizeLevel.x - 1) * .5f - i) * _offset.x, j * _offset.y, 0);

                newBrick.GetComponent<SpriteRenderer>().color = _gradient.Evaluate((float)j / (_sizeLevel.y - 1));
            }
        }
    }

}
