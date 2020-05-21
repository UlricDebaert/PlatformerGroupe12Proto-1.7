
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
   public GameManage gameManage;

   public PlayerScore PS;
   public GameOverScript GOS;
   public TipsText TT;

   void OnTriggerEnter2D()
    {
        if (PS.score >= 30)
        {
            gameManage.CompleteLevel();
        }
        else
        {
            if((TT != null) && (GOS != null))
            {
                TT.notEnoughMicroship = true;
                GOS.Lose();
            }
        }
    }
}
