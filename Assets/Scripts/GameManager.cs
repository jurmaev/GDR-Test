using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   [SerializeField] private MoveCircle circle;
   [SerializeField] private SpawnManager spawnManager;
   [SerializeField] private GameObject gameOverText;
   [SerializeField] private GameObject gameWonText;
   [SerializeField] private GameObject restartButton;

   private void Update()
   {
      if (spawnManager.CoinsCount == circle.CoinsCount)
      {
         circle.GameOver();
         gameWonText.SetActive(true);
         restartButton.SetActive(true);
      }

      if (circle.IsDead)
      {
         gameOverText.SetActive(true);
         restartButton.SetActive(true);
      }
   }

   public void Restart()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
