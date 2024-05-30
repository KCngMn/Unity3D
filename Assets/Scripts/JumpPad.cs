using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f; // 점프 힘

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어가 점프 패드에 닿았는지 확인
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            // 플레이어가 Rigidbody를 가지고 있는지 확인
            if (playerRb != null)
            {
                // 점프 힘을 추가하여 플레이어를 위로 점프시킴
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
