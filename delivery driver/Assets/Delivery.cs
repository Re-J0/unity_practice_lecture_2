using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,destroyDelay);
        }

        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("고객 배달 완료.");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
