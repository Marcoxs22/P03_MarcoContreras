using System;
using UnityEngine;

public class TiledBackground : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    private Renderer rendererUsed;
    private Vector2 offset = Vector2.zero;
    private Boolean isMoving = true;
    public bool IsMoving
    {
        get => isMoving;
        set
        {
            isMoving = value;
        }
    }

    private void Start()
    {
        rendererUsed = GetComponent<Renderer>();   
    }

    private void Update()
    {
        if (! isMoving) return;
        offset.x += speed * Time.deltaTime;
        rendererUsed.material.mainTextureOffset = offset;   
    }
}
