using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeActions : MonoBehaviour
{
    private float _angle = 0.0f;
    private Vector3 _initialPosition;

    [SerializeField] private float _radius = 5.0f;
    [SerializeField] private float _orbitSpeed = 2.0f;
    [SerializeField] private bool _orbitOn = false;
    [SerializeField] private bool _xAxisSpinOn = false;

    [SerializeField] private float _spinSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_xAxisSpinOn)
        {
            Spin();
        }
        if (_orbitOn)
        {
            Rotate();
        }
    }

    void Spin()
    {
        this.transform.localRotation *= Quaternion.AngleAxis(Time.deltaTime * _spinSpeed, new Vector3(1.0f, 0.0f, 0.0f));
    }

    void Rotate()
    {
        _angle += Time.deltaTime * _orbitSpeed;
        float deltaZ = _radius * Mathf.Cos(_angle);
        float deltaY = _radius * Mathf.Sin(_angle);

        /*if (180.0f * Mathf.PI / 180 > _angle && _angle > 90.0f * Mathf.PI / 180)
        {
            Debug.Log("Ïn quadrant 2");
        }*/

        Vector3 deltaPos = new Vector3(0, deltaY, deltaZ);
        Vector3 newPos = deltaPos + _initialPosition;
        this.transform.localPosition = newPos;
    }
}
