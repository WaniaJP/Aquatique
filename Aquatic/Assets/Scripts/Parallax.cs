using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    public Transform subject;

    private Vector2 _startPosition;
    private float _startZ;

    private Vector2 Travel => (Vector2)cam.transform.position - _startPosition;

    private float DistanceFromSubject => transform.position.z - subject.position.z;

    private float ClippingPlane => (cam.transform.position.z + (DistanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));

    private float parallaxFactor => Mathf.Abs(DistanceFromSubject) / ClippingPlane;
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        subject = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        _startPosition = transform.position;
        _startZ = transform.position.z;
    }

    private void Update()
    {
        Vector2 newPos =  _startPosition + Travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, _startZ);
    }


}
