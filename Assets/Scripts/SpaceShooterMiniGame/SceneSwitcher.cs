using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private Button button; 
    [SerializeField] private string sceneToLoad;

    private void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogError("Aucun bouton assign� � SceneSwitcher !");
        }
    }
    private void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            Debug.LogError("Le nom de la sc�ne � charger n'est pas d�fini !");
        }
    }
}