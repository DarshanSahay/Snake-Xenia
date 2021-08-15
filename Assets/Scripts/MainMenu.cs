using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject Stage;
    public void StageSelect()
    {
        Stage.SetActive(true);
    }
    public void SinglePlayer()
    {
        SceneManager.LoadScene(1);
    }
    public void MultiPlayer()
    {
        SceneManager.LoadScene(2);
    }

}