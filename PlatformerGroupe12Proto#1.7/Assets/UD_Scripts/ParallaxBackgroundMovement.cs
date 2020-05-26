using UnityEngine;

public class ParallaxBackgroundMovement : MonoBehaviour
{
    [SerializeField]
    private float backgroundXMoveSpeed = 0f, backgroundYMoveSpeed = 0f;

    private float directionX;
    private float directionY;

    float playerStartX, playerStartY;

    private void Start()
    {
        playerStartX = Camera.main.transform.position.x;
        playerStartY = Camera.main.transform.position.y;
    }

    void LateUpdate()
    {
        Moving();
    }

    void Moving()
    {
        directionX = Camera.main.transform.position.x;
        directionY = Camera.main.transform.position.y;

        transform.position = new Vector2(playerStartX + backgroundXMoveSpeed * (directionX - playerStartX), playerStartY + backgroundYMoveSpeed * (directionY - playerStartY));
    }
}
