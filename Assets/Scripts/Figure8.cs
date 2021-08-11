using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure8 : MonoBehaviour
{
    private Vector3 _initialPosition;
    private Vector3 _topCentre;
    private Vector3 _bottomCentre;

    private int _phase = 1;
    private float _angle = 0.0f;
    private float _radius = 4.0f;

    [SerializeField] private float _orbitSpeed = 1.0f;
    [SerializeField] [Range(1, 8)] private float _newRadius;


    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = this.transform.localPosition;
        _topCentre = _initialPosition + new Vector3(0, _radius, 0);
        _bottomCentre = _initialPosition + new Vector3(0, -1 * _radius, 0);
        _newRadius = _radius;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(_newRadius != _radius)
        {
            _radius = _newRadius;
            _topCentre = _initialPosition + new Vector3(0, _radius, 0);
            _bottomCentre = _initialPosition + new Vector3(0, -1 * _radius, 0);
        }

        if(_angle >= 2 * Mathf.PI)
        {
            _phase *= -1;
        }
        else if(_phase == -1 && _angle <= 0)
        {
            _phase *= -1;
        }

        _angle += Time.deltaTime * _phase *_orbitSpeed;
        float deltaZ = _phase * _radius * Mathf.Sin(_angle);
        float deltaY = -_phase * _radius * Mathf.Cos(_angle);
        Vector3 deltaPos = new Vector3(0, deltaY, deltaZ);
        Vector3 newPos;
        if (_phase == 1)
        {
            newPos = deltaPos + _topCentre;
        }
        else
        {
            newPos = deltaPos + _bottomCentre;
        }
        this.transform.localPosition = newPos;


    }
}
