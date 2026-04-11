using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3;
    private Animator animator;
    private Vector2 moveInput;           // 当前帧的原始输入（可以为零）
    private Vector2 facingDirection = Vector2.down; // 默认朝下，你可以根据需要调整

    void Start()
    {
        animator = GetComponent<Animator>();
        // 初始化时发送一次默认朝向
        CookingEventListener.st_OnVectorChange(facingDirection);
    }

    void Update()
    {
        // 获取输入
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(x, y);

        // 如果有移动输入，更新朝向
        if (moveInput != Vector2.zero)
        {
            facingDirection = moveInput.normalized;
            // 发送事件，通知其他系统朝向已改变
            CookingEventListener.st_OnVectorChange(facingDirection);
        }

        // 动画参数始终用 moveInput（可以为0，用于停止动画）
        if (moveInput.magnitude > 0)
        {
            animator.SetBool("isWalk", true);
            animator.SetFloat("horizental", moveInput.x);
            animator.SetFloat("vertical", moveInput.y);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        // 注意：不再每帧都发送事件，只在方向变化时发送
    }

    private void FixedUpdate()
    {
        // 实际移动使用 moveInput
        transform.Translate(moveInput.normalized * speed * Time.deltaTime);
    }
}
