
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManage gameManage;
   void OnTriggerEnter2D()
    {
        gameManage.CompleteLevel();
    }
}
