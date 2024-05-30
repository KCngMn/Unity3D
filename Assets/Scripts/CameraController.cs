using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public Vector3 firstPersonOffset = new Vector3(0, 1.6f, 0); // 1��Ī ������
    public Vector3 thirdPersonOffset = new Vector3(0, 5, -10); // 3��Ī ������
    public float smoothSpeed = 0.125f; // ī�޶� �������� �ε巯�� �ӵ�
    public float lookSensitivity = 2f; // ���콺 ����

    private bool isFirstPerson = true; // ���� ���� ����
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

        // ���� ī�޶� ��ġ�� �ε巴�� �̵�
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

            // �÷��̾��� ȸ���� ī�޶� ȸ���� �ݿ�
            player.Rotate(Vector3.up * mouseX);

            // ī�޶� ȸ��
            currentXRotation -= mouseY;
            currentXRotation = Mathf.Clamp(currentXRotation, -90f, 90f);
        }
    }
}
