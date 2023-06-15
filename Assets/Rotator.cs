using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    private Vector3 _rotationDirection;
    [SerializeField][Range(0f, 200f)]
    private float _rotationSpeed;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        SetRandomRotation();
    }
    private void SetRandomRotation()
    {
        _rotationDirection = Random.insideUnitSphere;
        _transform.rotation = Random.rotation;

    }
    private void Update()
    {
        transform.Rotate( _rotationDirection * _rotationSpeed * Time.deltaTime);
    }

}
