using UnityEngine;
using UnityEngine.SceneManagement;

namespace My.Unity.Core
{
   public class LevelManager : MonoBehaviour
   {
      public void LoadNextLevel ()
      {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }

      public void LoadLevel (int index)
      {
         SceneManager.LoadScene(index);
      }
   }
}