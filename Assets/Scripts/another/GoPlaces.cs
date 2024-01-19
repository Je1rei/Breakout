using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private Transform _placePoint;
    [SerializeField] private Transform[] _places;
    [SerializeField] private float _speed;

    private int _currentPlace;

    private void Start()
    {
        _places = new Transform[_placePoint.childCount];

        for (int i = 0; i < _placePoint.childCount; i++)
        {
            _places[i] = _placePoint.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        Transform _currentPlace = _places[this._currentPlace];
        transform.position = Vector3.MoveTowards(transform.position, _currentPlace.position, _speed * Time.deltaTime);

        if (transform.position == _currentPlace.position)
        {
            GetNextPlace();
        }
    }

    private Vector3 GetNextPlace()
    {
        _currentPlace++;

        if (_currentPlace == _places.Length)
        {
            _currentPlace = 0;
        }

        Vector3 place = _places[_currentPlace].transform.position;
        transform.forward = place - transform.position;

        return place;
    }
}