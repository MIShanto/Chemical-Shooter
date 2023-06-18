using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public float lookSpeed = 3.0f; // The speed at which the camera rotates
    private Vector2 _rotation = Vector2.zero; // The current rotation of the camera

    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                int id = touch.fingerId;
                if (!EventSystem.current.IsPointerOverGameObject(id))
                {
                    // Get movement of the finger since last frame
                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                    _rotation.y += touchDeltaPosition.x * lookSpeed;
                    _rotation.x += -touchDeltaPosition.y * lookSpeed;
                    _rotation.x = Mathf.Clamp(_rotation.x, -90f, 90f);
                    _rotation.y = Mathf.Clamp(_rotation.y, -60f, 60f);

                    // Apply the rotation to the camera
                    transform.eulerAngles = new Vector3(_rotation.x, _rotation.y, 0f);
                }
            }
            

        }
    }
}
