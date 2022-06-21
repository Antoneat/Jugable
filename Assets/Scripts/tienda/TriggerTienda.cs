using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTienda : MonoBehaviour
{
     public GameObject Sucubo;
    public void On()
    {
        ShopManager.instance.ToggleShop();
        Sucubo.SetActive(false);

    }


    public void Off()
    {
        ShopManager.instance.ToggleShop();
        Sucubo.SetActive(true);
    }
    
}
