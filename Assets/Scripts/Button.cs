using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] protected TextMesh _keyText;
    [SerializeField] private Material _onMaterial;
    [SerializeField] private Material _offMaterial;

    private MeshRenderer _meshRenderer;
    private bool _isSelected = false;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public virtual void OnClick()
    {
        
    }

    public void SetOnMaterial()
    {
        _meshRenderer.material = _onMaterial;
    }

    public void SetOffMaterial()
    {
        _isSelected = true;
        _meshRenderer.material = _offMaterial;
    }
}
