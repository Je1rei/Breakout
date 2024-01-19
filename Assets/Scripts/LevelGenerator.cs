using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const string _brickTag = "Brick";

    [SerializeField] private Vector2 _offset;
    [SerializeField] private Vector2Int _sizeLevel;
    [SerializeField] private GameObject _brick;  
    [SerializeField] private Gradient _gradient;

    private void Awake()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        for (int i = 0; i < _sizeLevel.x; i++)
        {
            int randomOffset = Random.Range(0, 3);

            for (int j = 0; j < _sizeLevel.y; j++)
            {
                GameObject newBrick = Instantiate(_brick, transform);
                newBrick.transform.position = transform.position + new Vector3((float)((_sizeLevel.x - 1) * .5f - i) * _offset.x * randomOffset, j * _offset.y * randomOffset, 0);

                newBrick.GetComponent<SpriteRenderer>().color = _gradient.Evaluate((float)j / (_sizeLevel.y - 1));
            }
        }
    }

    public void DestroyLevel()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(_brickTag);

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
}
