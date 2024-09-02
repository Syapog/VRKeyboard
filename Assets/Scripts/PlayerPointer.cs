using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointer : MonoBehaviour
{
    private Button _prevButton;

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f))
        {
            if(hit.collider.TryGetComponent(out Button actualButton))
            {
                if(_prevButton != null)
                {
                    if(_prevButton != actualButton)
                    {
                        actualButton.SetOnMaterial();
                        _prevButton.SetOffMaterial();
                    }
                    else
                        actualButton.SetOnMaterial();
                }

                if(Input.GetKeyDown(KeyCode.Mouse0))
                    actualButton.OnClick();

                _prevButton = actualButton;
            }
            else if(_prevButton != null)
            {
                _prevButton.SetOffMaterial();
            }
        }
    }
}
