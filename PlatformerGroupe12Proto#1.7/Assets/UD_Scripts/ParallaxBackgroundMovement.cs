using UnityEngine;

public class ParallaxBackgroundMovement : MonoBehaviour
{
    [SerializeField]
    private float backgroundXMoveSpeed = 0f, backgroundYMoveSpeed = 0f;

    private float directionX;
    private float directionY;

    float playerStartX, playerStartY;

    [Header("Offset")]

    [SerializeField] bool useOffset = false;
    [SerializeField] float XOffset = 0f, YOffset = 0f;

    private void Start()
    {
        if(!useOffset)
        {
            playerStartX = Camera.main.transform.position.x;
            playerStartY = Camera.main.transform.position.y;
        }
        else
        {
            playerStartX = Camera.main.transform.position.x + XOffset;
            playerStartY = Camera.main.transform.position.y + YOffset;
        }
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
