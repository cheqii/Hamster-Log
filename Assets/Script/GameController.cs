using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
