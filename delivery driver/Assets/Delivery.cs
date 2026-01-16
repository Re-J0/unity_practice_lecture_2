using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("마 자신있나");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("뭐임시치");  
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("패키지 픽업됨.");
            hasPackage = true;
            Destroy(other.gameObject,destroyDelay);
        }

        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("고객 배달 완료.");
            hasPackage = false;
        }
    }
}
