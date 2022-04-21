using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Movement Specs")]
    [SerializeField]
    [Range(0f, 100f)]
    private float speed = 1;
    [SerializeField]
    [Range(0f, 1f)]
    private float lerpSpeed = 0.1f;

    [Header("Max Bounds")]
    [SerializeField]
    private float terrainMinDist = 10;
    [SerializeField]
    private float minX = -100;
    [SerializeField]
    private float maxX = 100;
    [SerializeField]
    private float minY = -100;
    [SerializeField]
    private float maxY = 100;
    [SerializeField]
    private float minZ = -100;
    [SerializeField]
    private float maxZ = 100;

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

        FixPos();
        Vector3 lerpPosition = Vector3.Lerp(transform.position, transform.position + _velocity, lerpSpeed);
        transform.position = lerpPosition;
        //transform.Translate(_velocity, Space.World);
    }

    private void FixPos()
    {
        RaycastHit hit;

        if (transform.position.x < minX)
        {
            _velocity.x = _velocity.x < 0 ? 0 : _velocity.x;
        }
        if (transform.position.x > maxX)
        {
            _velocity.x = _velocity.x > 0 ? 0 : _velocity.x;
        }
        if (transform.position.y < minY)
        {
            _velocity.y = _velocity.y < 0 ? 0 : _velocity.y;
        }
        if (transform.position.y > maxY)
        {
            _velocity.y = _velocity.y > 0 ? 0 : _velocity.y;
        }
        if (transform.position.z < minZ)
        {
            _velocity.z = _velocity.z < 0 ? 0 : _velocity.z;
        }
        if (transform.position.z > maxZ)
        {
            _velocity.z = _velocity.z > 0 ? 0 : _velocity.z;
        }
        if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, Vector3.up * hit.distance, Color.red);
            Debug.Log("under the map");
            _velocity.y = 1;
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.yellow);
            if (hit.distance < terrainMinDist)
            {
                _velocity.y = 0;
                transform.position = new Vector3(transform.position.x, transform.position.y + terrainMinDist - hit.distance, transform.position.z);
            }
        }
    }
}
