using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

[Serializable]
public class GameControl
{   private Company PlayerCompany;
    private List<Employee> PrebuiltEmployees = new List<Employee>();
    private List<Contract> PrebuiltContracts = new List<Contract>();
    private List<Asset> PrebuiltAssets = new List<Asset>();
    private float time0 = 0.0f;
    private float interval = 3.0f;  // the real time for each day in seconds
    private int day = 0;
    private bool pause = false;
    public void pauseGame() {   pause = true;}
    public void resumeGame() {   pause = false;}

    private bool newUpdate = false;
    public bool isNewUPdate() { return newUpdate;}
    public void resolveUpdate() { newUpdate = false;}

    public int getDay() { return day;}
    // Only fetch information using functions in the Interfaces
    // anythin below interface you don't need to know

    public Company getUserCompany()
    {   return PlayerCompany;
    }

    public void start()
    {   PlayerCompany = new Company("California Technology");
        intialSettings();
        testPause();
    }

    private void testPause()
    {   pauseGame();
        resumeGame();
    }

    public void update()
    {   if(Time.time-time0>interval && !pause)
        {   time0 = Time.time;
            printTime();
            timeUpdateModel();
            //flag the Update
            newUpdate = true;
        }
    }

    void timeUpdateModel()
    {   PlayerCompany.updateCompany();
        PlayerCompany.printCompany();
        day ++;
    }

    void intialSettings()
    {   initialPrebuiltEmployees();
        initialPrebuiltContracts();

        PlayerCompany.printEmployees();
        PlayerCompany.printAssets();
        PlayerCompany.printCompany();

    //     PrebuiltContracts.Add(new Contract("Bristol Romantic Website","romance",
    //         Industry.SpaceEngineering,500,1,100, new BasicPropertys(300,400,250)));

    //    Contract contract = new Contract("RAF webiste","raf",
    //         Industry.Military,500,1,170, new BasicPropertys(200,600,50));

    //    PrebuiltContracts.Add(new Contract("RAF webiste","raf",
    //         Industry.Military,500,1,170, new BasicPropertys(200,600,50)));

    //     PlayerCompany.takeProject(PrebuiltContracts[0],new string[] {"Lucy"});
    //     DeletePrebuiltContract(PrebuiltContracts[0]);
    //     //ontract contract = PrebuiltContracts[1];
    //     if(contract ==null) Debug.Log("wfwfwfwfwfw");
    //     PlayerCompany.takeProject(contract,new string[] {"Lisbon"});
    //     DeletePrebuiltContract(PrebuiltContracts[0]);
    }

    public void printTime()
    {   Debug.Log("");
        Debug.Log("//// "+ interval+" seconds passed//// current situation:");
        Debug.Log("Day "+day+":");
    }

    public void PrebuiltEmployee(Employee e)
    {   PrebuiltEmployees.Add(e);
    }

    public void DeletePrebuiltEmployee(Employee e)
    {   PrebuiltEmployees.Remove(e);
    }

    public void DeletePrebuiltContract(Contract c)
    {   PrebuiltContracts.Remove(c);
    }

    public void DeletePrebuiltAsset(Asset a)
    {   PrebuiltAssets.Remove(a);
    }

    public List<Employee> getPrebuiltEmployees()
    {   return PrebuiltEmployees;
    }

    public List<Contract> getPrebuiltContracts()
    {   return PrebuiltContracts;
    }

    public List<Asset> getPrebuiltAssets()
    {   return PrebuiltAssets;
    }
    
    private void initialPrebuiltEmployees()
    {
        using (StreamReader r = new StreamReader("./Assets/Script/SimulationGame/scripts/GameInfo.json")) {
            string json = r.ReadToEnd();
            List<JsonEmployee> employees = JsonConvert.DeserializeObject<List<JsonEmployee>>(json);
            // Debug.Log(employees.Count);
            for (int i = 0; i < employees.Count; i++) {
                Employee employee = new Employee(employees[i].getName(), employees[i].getSalary(), employees[i].getTitle(), employees[i].getDescription(), new BasicPropertys(employees[i].getFront(), employees[i].getBack(), employees[i].getGraphics()));
                Debug.Log(employee.getName());
                PrebuiltEmployees.Add(employee);
            }
        }
    }

    private void initialPrebuiltContracts() {
        using (StreamReader rr = new StreamReader("./Assets/Script/SimulationGame/scripts/ContractInfo.json")) {
            string json1 = rr.ReadToEnd();
            List<JsonContract> jcontracts = JsonConvert.DeserializeObject<List<JsonContract>>(json1);
            // Debug.Log(employees.Count);
            for (int i = 0; i < jcontracts.Count; i++) {
                Contract contract = new Contract(jcontracts[i].getNames(), jcontracts[i].getDescription(), jcontracts[i].getIndustry(), jcontracts[i].getRewards(), jcontracts[i].getLevel(), jcontracts[i].getTimeLimits(), new BasicPropertys(jcontracts[i].getFrontend(),jcontracts[i].getBackend(), jcontracts[i].getGraphics()));
                PrebuiltContracts.Add(contract);
            }
        }
    }

    
}
