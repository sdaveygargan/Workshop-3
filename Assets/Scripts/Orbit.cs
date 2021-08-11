using System;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private float _angle =  0.0f;
    private Vector3 _initialPosition;

    [SerializeField] private float _radius = 10.0f;
    [SerializeField] private float _orbitSpeed = 2.0f;

    void Start()
    {
        _initialPosition = this.transform.localPosition;

    }

    void Update()
    {
        _angle += Time.deltaTime * _orbitSpeed;
        float deltaZ = _radius * Mathf.Cos(_angle);
        float deltaY = _radius * Mathf.Sin(_angle);

        if(180.0f * Mathf.PI/180 > _angle && _angle > 90.0f * Mathf.PI / 180)
        {
            Debug.Log("Ïn quadrant 2");
        }

        Vector3 deltaPos = new Vector3(0, deltaY, deltaZ);
        Vector3 newPos = deltaPos + _initialPosition;
        this.transform.localPosition = newPos;

    }


}
