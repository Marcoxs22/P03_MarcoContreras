using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : MonoBehaviour
{
   [SerializeField]
   private Text _scoreText;


   public void SetScore(int score)
   {
    _scoreText.text = score.ToString();
   }
}


