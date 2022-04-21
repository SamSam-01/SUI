using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 100f)]
    private float speed = 1;

    private Vector3 _direction = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMove(InputValue value)
    {
        InputMove(value.Get<Vector2>());
    }

    public void OnVerticalMove(InputValue value)
    {
        InputVerticalMove(value.Get<float>());
    }

    public void InputMove(Vector2 move)
    {
        _direction = new Vector3(move.x, _direction.y, move.y);
    }

    public void InputVerticalMove(float move)
    {
        _direction.y = move;
    }

    // Update is called once per frame
    void Update()
    {
        _direction.Normalize();
        _velocity = _direction * speed * Time.deltaTime;
        transform.Translate(_velocity, Space.World);
    }
}
