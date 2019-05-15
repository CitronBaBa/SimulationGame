using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeContractButton : MonoBehaviour
{   GameObject inputfield;
    GameControl control;
    Contract contract;
    GameObject panel;

    void Start()
    {   Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
        control = Control.ConnectToGameModel();
    }

    public void setContract(Contract c)
    {   this.contract = c;
    }

    public void setPanel(GameObject panel)
    {   this.panel = panel;
    }

    void TaskOnClick()
    {   if(contract != null)
        {   if(control.getUserCompany().takeProject(contract,new string[] {"Lucy"}))
            {   control.DeletePrebuiltContract(contract);
                Destroy(panel);
            }
        }
    }

}
