using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyAssetButton : MonoBehaviour
{   GameObject inputfield;
    GameControl control;
    Asset asset;
    GameObject card;

    void Start()
    {   Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
        control = Control.ConnectToGameModel();
    }

    public void setAsset(Asset c)
    {   this.asset = c;
    }

    public void setCard(GameObject card)
    {   this.card = card;
    }

    void TaskOnClick()
    {   if(asset != null)
        {   if(control.getUserCompany().buyAsset(asset))
            {   control.DeletePrebuiltAsset(asset);
                Destroy(card);
            }
        }
    }

}
