using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    
    
    public bool infiniteHorizontal;
    public bool infiniteVertical;
    
    private Vector3 _lastCameraPosition;
    private Transform _cameraTransform;
    private Transform _transform;
    private float _textureUnitSizeX;
    private float _textureUnitSizeY;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        _lastCameraPosition = _cameraTransform.position;
        
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        
        _textureUnitSizeX = (texture.width / sprite.pixelsPerUnit) * _transform.localScale.x; 
        _textureUnitSizeY = (texture.height / sprite.pixelsPerUnit) * _transform.localScale.y;
    }

    private void FixedUpdate()  
    {
        var position = _cameraTransform.position;
        var deltaMovement = position - _lastCameraPosition;
        
        _transform.position -= new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        _lastCameraPosition = position;
        
        if (infiniteHorizontal)
        {
            if (Mathf.Abs(_cameraTransform.position.x - _transform.position.x) >= _textureUnitSizeX)
            {
                var offsetPositionX = (_cameraTransform.position.x - transform.position.x) % _textureUnitSizeX;
                _transform.position = new Vector3(_cameraTransform.position.x + offsetPositionX, _transform.position.y);
            }
        }

        if (infiniteVertical)
        {
            if (Mathf.Abs(_cameraTransform.position.y - transform.position.y) >= _textureUnitSizeY)
            {
                float offsetPositionY = (_cameraTransform.position.y - transform.position.y) % _textureUnitSizeY;
                _transform.position = new Vector3(_transform.position.x, _cameraTransform.position.y + offsetPositionY);
            }
        }
    }
}