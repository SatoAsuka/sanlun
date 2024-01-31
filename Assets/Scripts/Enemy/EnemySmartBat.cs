using UnityEngine;

public class EnemySmartBat : Enemy
{
    public float speed;
    public float radius;

    private Transform playerTransform;
    private bool facingRight = false;  // 假设怪物初始朝向左

    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();
        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;

            if (distance < radius)
            {
                Vector2 direction = playerTransform.position - transform.position;
                if (direction.x > 0 && !facingRight)
                {
                    Flip();
                }
                else if (direction.x < 0 && facingRight)
                {
                    Flip();
                }

                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
