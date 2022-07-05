using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTienda : MonoBehaviour
{
     public GameObject Sucubo;
    public void On()
    {
        ShopManager.instance.ToggleShop();
    }


    public void Off()
    {
        ShopManager.instance.ToggleShop();
    }
    
}
