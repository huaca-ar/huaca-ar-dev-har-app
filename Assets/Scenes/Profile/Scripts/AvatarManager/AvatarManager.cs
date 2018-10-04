using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour {

    private float _deltaX = 0.0f;
    private float _lastX = 0.5f;
    private float _steps = 0.0f;
    private int _direction = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _deltaX = 0.0f;
                    break;
                case TouchPhase.Moved:
                    _deltaX = Mathf.Abs(_lastX - touch.position.x);

                    if (_deltaX < touch.position.x)
                    {
                        _direction = -1;
                    }
                    if (_deltaX > touch.position.x)
                    {
                        _direction = 1;
                    }
                    transform.Rotate(Vector3.up, _deltaX * _direction);
                    _lastX = touch.position.x;
                    break;
                default:
                    if (_deltaX > 0.05f) 
                        _deltaX -= 0.05f;
                    if (_deltaX < 0.05f)
                        _deltaX += 0.05f;
                    transform.Rotate(Vector3.up, _deltaX * _direction);
                    break;
            }
        }  
    }
}
