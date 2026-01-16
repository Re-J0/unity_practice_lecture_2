using UnityEngine;

public class Delivery : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("마 자신있나");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("뭐임시치");  
        if(other.tag == "Package")
        {
            Debug.Log("패키지 픽업됨.");
        }

        else if (other.tag == "Customer")
        {
            Debug.Log("고객 배달 완료.");
        }
    }
}
