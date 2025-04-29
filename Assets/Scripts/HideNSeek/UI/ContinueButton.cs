using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ContinueButton : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private HidingSpotsHolder hidingSpotsHolder;

    [SerializeField]
    private ObjectHolder objectHolder;


    private void Start()
    {
        GameObject[] holders = GameObject.FindGameObjectsWithTag("Holder");

        foreach (GameObject obj in holders)
        {
            if (objectHolder == null)
            {
                objectHolder = obj.GetComponent<ObjectHolder>();
            }

            if (hidingSpotsHolder == null)
            {
                hidingSpotsHolder = obj.GetComponent<HidingSpotsHolder>();
            }

            if (objectHolder != null && hidingSpotsHolder != null)
            {
                break;
            }
        }

        button.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {
        hidingSpotsHolder.ResetValues();
        objectHolder.ResetValue();
        SceneManager.LoadScene("MainScene");
    }




}
