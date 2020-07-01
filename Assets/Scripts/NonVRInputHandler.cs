using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVRInputHandler : MonoBehaviour
{
	[SerializeField]
    private Camera touchCamera;

	float cameraMoveSpeed = 4f;

	void Awake() 
	{
		Input.multiTouchEnabled = false;
	}

	private void MoveCameraWithTouch()
	{
		if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved) 
		// ||Input.GetMouseButton(0)
		)
		{
			// print("touched!");
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			Vector3 cameraEulerAngles = touchCamera.transform.eulerAngles;
			touchCamera.transform.localEulerAngles = new Vector3(
				cameraEulerAngles.x - touchDeltaPosition.y * Time.deltaTime * cameraMoveSpeed,
				cameraEulerAngles.y + touchDeltaPosition.x * Time.deltaTime * cameraMoveSpeed, 
				0
			);
		}
	}

	private void MoveCameraWithAccelerometer()
	{
 		// Vector3 dir = Vector3.zero;
        // dir.y = Input.acceleration.x;
        // if (dir.sqrMagnitude > 1)
        //     dir.Normalize();
        // dir *= Time.deltaTime;
        // touchCamera.transform.Rotate(dir * cameraMoveSpeed);

        float moveHorizontal = Input.acceleration.normalized.x; // left / right movement
        float moveVertical = -Input.acceleration.normalized.z; //forward / backwards
 
        // main three directional movement control
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		// Vector3 adjust = new Vector3(-90,0,0); 
		touchCamera.transform.rotation = 
		Quaternion.LookRotation(movement, Vector3.up);
		// touchCamera.transform.Rotate(adjust);
	}

	void Update() 
	{
		// MoveCameraWithTouch();
		MoveCameraWithAccelerometer();
	}
}
