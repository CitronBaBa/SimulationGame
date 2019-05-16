using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/* this is all you need to know about the model */
/* you are only allowed to use functions in the interface */
/*
interface CompanyInterface
{   // action funcion
    bool takeProject(Contract contract, string[] CrewNames);
    void hireEmployee(Employee e);

    //ask infos
    Dictionary<string,Employee> getEmployees();

}*/

/* anything else below you don't need to know */

// employee was held in a Dictionary, so that you can find one employee
// by its name
[Serializable]
public class Company //: CompanyInterface
{   private Dictionary<string,Employee> employees = new Dictionary<string,Employee>();
    private List<Asset> assets = new List<Asset>();
    private List<Project> projectsEngaged = new List<Project>();
    private int money = 100000000;
    private string companyName;

    //empty string = no alert
    private Alert alert = new Alert("");

    public Dictionary<string,Employee> getEmployees()
    {   return employees;
    }
    public List<Project> getCurrentProjects()
    {   return projectsEngaged;
    }

    public List<Asset> getCurrentAssets()
    {   return assets;
    }
    public int getMoney() { return money;}


    public Company(string name)
    {   this.companyName = name;
    }

// called on each day
    public void updateCompany()
    {   updateProjects();
        updateEmployees();
    }

// pay employees
    public void updateEmployees()
    {   foreach (Employee e in employees.Values)
        money -= e.getSalary();
    }

// proceed every project
    public void updateProjects()
    {   if(projectsEngaged.Count==0) return;
        //avoid concurrency problem of delete and access List
        //at the same time
        List<Project> finished = new List<Project>();
        foreach (Project p in projectsEngaged)
        {   if(p.dailyOperation())
            finished.Add(p);
        }
        if(finished.Count!=0)
        {   foreach(Project p in finished)
            finishProject(p);
        }
    }

//  get paid from and remove finishing project
    private void finishProject(Project project)
    {   money+=project.getAward();
        projectsEngaged.Remove(project);
    }

// sign up a project, asign employee by name
// if no employee has correspondent name return false
// if employee is busy return false;
    public bool takeProject(Contract contract)
    {   if (projectsEngaged.Count == 1){
            alert.setMessage("You have already activated a project");
            return false;
        }
        List<Employee> crew = new List<Employee>();
        foreach (var item in employees)
        {
            crew.Add(item.Value);
        }
        Project newproject = new Project(contract,crew);
        projectsEngaged.Add(newproject);
        return true;
    }

    public bool hireEmployee(Employee e)
    {   if (checkHireable(e)) employees.Add(e.getName(),e);
        else
        {  alert.setMessage("Can't hire now, you don't have required assets yet");
           return false;
        }
        return true;
    }

    public bool buyAsset(Asset newAsset)
    {   if (money < newAsset.getPrice())
        {   alert.setMessage("You don't have enough money to buy this assets!");
            return false;
        }

        if (newAsset.getName().Contains("Server Clusters"))
        {   if(!hasAssetWithName("Server Room"))
            alert.setMessage("You need a Server Room to buy server");
            return false;
        }
        assets.Add(newAsset);
        money -= newAsset.getPrice();
        return true;
    }

    private bool checkBuyable()
    {   return true;
    }

    private bool checkHireable(Employee e)
    {   string[] titleKeywords = e.getJobTitle().Split(' ');
        foreach(string s in titleKeywords)
        {    if(!checkKeyTitle(s)) return false;
        }
        return true;
    }

    private bool checkKeyTitle(string keywords)
    {   switch (keywords)
        {    case "Operation":
                if(hasAssetWithName("Server Room")) return true;
                return false;
             case "Senior":
                if(hasAssetWithName("Office LV2")) return true;
                return false;
             case "Full":
                if(hasAssetWithName("Office LV3")) return true;
                if(hasAssetWithName("Office LV2"))
                {   if(countEmployeeWithKeyword("Full")<2) return true;
                }
                return false;
             default:
                return true;
       }
     }

     private int countEmployeeWithKeyword(string keyword)
     {   int count = 0;
         foreach(Employee e in employees.Values)
         {   if(e.getName().Contains(keyword))
             count++;
         }
         return count;
     }

     private bool hasAssetWithName(string name)
     {   foreach(Asset a in assets)
         {   if(a.getName().Equals(name))
             return true;
         }
         return false;
     }

    public string getAlertMessage()
    {   string message = alert.getMessage();
        //reset alert
        alert.setMessage("");
        return message;
    }


// trivial functions, not important
// some were used to cooperate with the old UI
    public void printCompany()
    {   Debug.Log("Company: "+companyName+"---current account---:  "+money+"$");
        foreach(Project p in projectsEngaged)
        p.printProject();
    }

    public void printEmployees()
    {   String s = "";
        foreach (Employee e in employees.Values)
        s+=e.getName()+"  ";
        Debug.Log("Your current staff: "+s);
    }

    public string employeesInfo()
    {   string info = "";
        foreach (Employee e in employees.Values)
        info += "Employee: "+e.getName()+"\n";
        return info;
    }

    public void printAssets()
    {   foreach (Asset a in assets)
        Debug.Log("Your current assets: "+a.getDetail());
    }

    public string assetsInfo()
    {   string info = "";
        foreach (Asset a in assets)
        info += "Asset: "+a.getDetail()+"\n";
        return info;
    }

    public static void Main(string[] args)
    {   
    }
}
