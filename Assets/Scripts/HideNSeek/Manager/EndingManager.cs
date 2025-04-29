using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    [SerializeField]
    private DifficultyManager difficultyManager;

    private Timer timer;

    [SerializeField]
    private Text winText;

    [SerializeField]
    private Text gameOverText;

    [SerializeField]
    private Button continueButton;

    [SerializeField]
    private PlayerControls movements;

    [SerializeField]
    private CameraMovements camMovements;

    public int ItemFound;
    // Start is called before the first frame update
    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject obj in players)
        {
            if (movements == null)
            {
                movements = obj.GetComponent<PlayerControls>();
            }

            if (camMovements == null)
            {
                camMovements = obj.GetComponent<CameraMovements>();
            }

            if (movements != null && camMovements != null)
            {
                break;
            }
        }

        difficultyManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<DifficultyManager>();

        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (ItemFound == difficultyManager.NumberOfItemsToFind && difficultyManager.NumberOfItemsToFind != 0)
        {
            winText.enabled = true;

            continueButton.gameObject.SetActive(true);

            if (movements != null && camMovements != null)
            {
                movements.enabled = false;
                camMovements.enabled = false;
            }

            if (timer != null)
            {
                timer.IsRunning = false;
            }
        }

        if (difficultyManager.TimeRemaining <= 0)
        {
            gameOverText.enabled = true;

            continueButton.gameObject.SetActive(true);

            if (movements != null && camMovements != null)
            {
                movements.enabled = false;
                camMovements.enabled = false;
            }

            if (timer != null)
            {
                timer.IsRunning = false;
            }
        }
    }
}
