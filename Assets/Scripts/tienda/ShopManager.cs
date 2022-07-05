using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public Upgrade[] upgrades;

    public GameObject shopUI;
    public GameObject succUI;
    public Transform shopContent;
    public GameObject itemPrefab;
    public Player plyr;
    
    private void Awake()
    {
        if(instance == null)
        {
          
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
      
        foreach (Upgrade upgrade in upgrades)
        {
            GameObject item = Instantiate(itemPrefab, shopContent);

            upgrade.itemREF = item;

            foreach (Transform child in item.transform)
            {
                if (child.gameObject.name == "quantity")
                {
                    child.gameObject.GetComponent<TMP_Text>().text = upgrade.quantity.ToString();
                }
                else if (child.gameObject.name == "precio")
                {
                    child.gameObject.GetComponent<TMP_Text>().text = upgrade.precio.ToString();
                }
                else if (child.gameObject.name == "nombre")
                {
                    child.gameObject.GetComponent<TMP_Text>().text = upgrade.nombre.ToString();
                }
                else if (child.gameObject.name == "descripcion")
                {
                    child.gameObject.GetComponent<TMP_Text>().text = upgrade.descripcion.ToString();
                }
                else if (child.gameObject.name == "Image")
                {
                    child.gameObject.GetComponent<Image>().sprite = upgrade.Image;
                }
            }

            item.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                BuyUpgrade(upgrade);
            });
        }
    }

    void Update()
    {
        Pausa();
    }

    void Pausa()
    {
        if (!shopUI.activeInHierarchy || !succUI.activeInHierarchy)
        {

            Time.timeScale = 1f;

        }
        else 
        {
            Time.timeScale = 0f;
        }
    }

    public void BuyUpgrade(Upgrade upgrade)
    {
        if(plyr.almas>=upgrade.precio)
        {
            plyr.almas -= upgrade.precio;
            upgrade.quantity++;
         
            ApplyUpgrade(upgrade);
        }
    }

    public void ApplyUpgrade(Upgrade upgrade)
    {
        switch (upgrade.nombre)
        {
            case "Desplazamiento Espiritual":
                plyr.dashMejorado = true;
                if (upgrade.quantity == 1)
                {
                    Destroy(upgrade.itemREF);
                }
                break;

            case "Guadaña Espiritual":
                plyr.basicoMejorado = true;
                if (upgrade.quantity == 1)
                {
                    Destroy(upgrade.itemREF);
                }
                break ;

            case "Giro Espiritual Azul":
                plyr.cargadoAzul = true;
                if (upgrade.quantity == 1)
                {
                    Destroy(upgrade.itemREF);
                }
                break;

            case "Giro Espiritual Rojo":
                plyr.cargadoRojo = true;
                if (upgrade.quantity == 1)
                {
                    Destroy(upgrade.itemREF);
                }
                break;
        }
    
    }

    public void ToggleShop()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            succUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            succUI.SetActive(false);
        }
    }

    public void SuccIn()
    {
        succUI.SetActive(true);

    }

    public void SuccOut()
    {
        succUI.SetActive(false);

    }*/

}


[System.Serializable]
public class Upgrade
{
    public string nombre;
    public string descripcion;
    public int precio;
    public Sprite Image;
    [HideInInspector] public int quantity =0;
    [HideInInspector] public GameObject itemREF;
}

