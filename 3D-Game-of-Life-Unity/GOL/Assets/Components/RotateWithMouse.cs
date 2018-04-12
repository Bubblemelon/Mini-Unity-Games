using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class RotateWithMouse : MonoBehaviour {

	public float mouseRotationSpeed = 75f;
	private bool didStartTouchNotOverUI;

	void Update () {
	
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
			didStartTouchNotOverUI = true;
		}

		if (Input.GetMouseButton(0) && didStartTouchNotOverUI) {
			Vector3 rotationRaw = new Vector3(Input.GetAxis("Mouse Y"),-Input.GetAxis("Mouse X"),0);
			transform.Rotate(rotationRaw * Time.deltaTime * mouseRotationSpeed,Space.World);

		} else {
			didStartTouchNotOverUI = false;
		}
	}
}
