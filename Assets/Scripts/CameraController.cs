using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 100f)]
    private float speed = 1;

    private Vector2 _direction;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMove(InputValue value)
    {
        InputMove(value.Get<Vector2>());
    }

    public void InputMove(Vector2 move)
    {
        _direction = move;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
    }
}
