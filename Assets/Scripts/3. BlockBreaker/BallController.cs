using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float radius;
    public Vector2 velocity;
    public List<Block> blocks;
    private Vector2 collisionPoint;

    void Update()
    {
        float deltaTime = Time.deltaTime;
        Vector2 newPosition = (Vector2)transform.position + velocity * deltaTime;

        foreach (Block block in blocks)
        {
            if (IsColliding(newPosition, radius, block))
            {
                Vector2 normal = CalculateNormal(newPosition, block);

                velocity = Vector2.Reflect(velocity, normal);

                newPosition = AdjustPosition(newPosition, radius, block, normal);

                Destroy(block.gameObject);
                blocks.Remove(block);
                break;
            }
        }

        transform.position = newPosition;
    }

    bool IsColliding(Vector2 ballPosition, float radius, Block block)
    {
        float left = block.transform.position.x - block.width / 2;
        float right = block.transform.position.x + block.width / 2;
        float top = block.transform.position.y + block.height / 2;
        float bottom = block.transform.position.y - block.height / 2;

        if (ballPosition.x + radius < left || ballPosition.x - radius > right ||
            ballPosition.y + radius < bottom || ballPosition.y - radius > top)
        {
            return false;
        }

        collisionPoint.x = Mathf.Clamp(ballPosition.x, left, right);
        collisionPoint.y = Mathf.Clamp(ballPosition.y, bottom, top);

        float distance = Vector2.Distance(ballPosition, collisionPoint);
        return distance < radius;
    }

    Vector2 CalculateNormal(Vector2 ballPosition, Block block)
    {
        Vector2 toBall = ballPosition - collisionPoint;

        return toBall.normalized;
    }


    Vector2 AdjustPosition(Vector2 newPosition, float radius, Block block, Vector2 normal)
    {

        float penetrationDepth = radius - Vector2.Distance(newPosition, collisionPoint);


        return newPosition + normal * penetrationDepth;
    }
}
