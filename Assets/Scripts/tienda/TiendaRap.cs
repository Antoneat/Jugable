using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TiendaRap : MonoBehaviour
{
    public int SceneId;

    public GameObject panelTienda, tiendaFirstButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstSelectOption()
    {
            panelTienda.SetActive(true);
            Time.timeScale = 0f;

            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(tiendaFirstButton);
    }

    public void ChangeSceneTienda()
    {
        SceneManager.LoadScene(SceneId);
    }
}
