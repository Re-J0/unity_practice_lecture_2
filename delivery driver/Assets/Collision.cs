using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("마 자신있나");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("뭐임시치");  
    }
}
