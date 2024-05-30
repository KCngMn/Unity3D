using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f; // ���� ��

    private void OnCollisionEnter(Collision collision)
    {
        // �÷��̾ ���� �е忡 ��Ҵ��� Ȯ��
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            // �÷��̾ Rigidbody�� ������ �ִ��� Ȯ��
            if (playerRb != null)
            {
                // ���� ���� �߰��Ͽ� �÷��̾ ���� ������Ŵ
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
