using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public Vector3 firstPersonOffset = new Vector3(0, 1.6f, 0); // 1인칭 오프셋
    public Vector3 thirdPersonOffset = new Vector3(0, 5, -10); // 3인칭 오프셋
    public float smoothSpeed = 0.125f; // 카메라 움직임의 부드러운 속도
    public float lookSensitivity = 2f; // 마우스 감도

    private bool isFirstPerson = true; // 현재 시점 상태
    private Vector2 mouseDelta;
    private float currentXRotation = 0f;

    private void LateUpdate()
    {
        Vector3 desiredPosition;

        if (isFirstPerson)
        {
            desiredPosition = player.position + player.TransformDirection(firstPersonOffset);
        }
        else
        {
            desiredPosition = player.position + thirdPersonOffset;
        }

        // 현재 카메라 위치를 부드럽게 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (isFirstPerson)
        {
            transform.rotation = Quaternion.Euler(currentXRotation, player.eulerAngles.y, 0);
        }
        else
        {
            transform.LookAt(player);
        }

    }

    public void ToggleCameraView()
    {
        isFirstPerson = !isFirstPerson;
    }

    public void SetMouseDelta(Vector2 delta)
    {
        mouseDelta = delta;
        UpdateCameraRotation();
    }

    private void UpdateCameraRotation()
    {
        if (isFirstPerson)
        {
            float mouseX = mouseDelta.x * lookSensitivity;
            float mouseY = mouseDelta.y * lookSensitivity;

            // 플레이어의 회전을 카메라 회전에 반영
            player.Rotate(Vector3.up * mouseX);

            // 카메라 회전
            currentXRotation -= mouseY;
            currentXRotation = Mathf.Clamp(currentXRotation, -90f, 90f);
        }
    }
}
