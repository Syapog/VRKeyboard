using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPointerMoving : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) transform.position = new Vector3(hit.point.x, hit.point.y, -1.13f);

    }
}
