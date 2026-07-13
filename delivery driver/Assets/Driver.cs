using System;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    // Update is called once per frame
    void Update() 
    // 유니티 생명주기 메서드 매 프레임마다 반복해서 실행되는 메서드입니다.
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        // 컴퓨터의 성능에 따라 프레임이 달라지는데, 성능 좋은 컴퓨터는 1초에 120번의 Update가 실행되고,
        // 성능 나쁜 컴퓨터는 1초에 60번의 Update가 실행되면 매우 심각한 불평등이 발생함.
        // 하여 지난 프레임부터 현재 프레임까지 걸린 시간(초)인 Time.deltaTime 를 곱해 모든 컴퓨터가 1초에 동일하게 이동하게 됨.
        float moveAmount = Input.GetAxis("Vertical")  * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    // 2D 물리 엔진에서 물체끼리 부딪혔을 때 유니티가 자동으로 호출해주는 이벤트 메서드입니다.
    {
        moveSpeed = slowSpeed;
        // 속도를 낮은 속도로 변경
    }
    void OnTriggerEnter2D(Collider2D collision) 
    // 2D 물리 엔진에서 물체끼리 부딪혔을 때 유니티가 자동으로 호출해주는 이벤트 메서드입니다.
    {
        if(collision.tag == "Boost")
        // 만약 부딪힌 오브젝트의 태그가 부스트라면
            moveSpeed = boostSpeed;
            // 속도를 부스트 속도로 변경
    }

    
}
