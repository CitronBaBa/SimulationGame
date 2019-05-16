using System;
using System.Collections;
using System.Collections.Generic;
[Serializable]
public class Contract
{   private BasicPropertys propertys;
    private string name;
    private string description;
    private int award;
    private int level;
    private int timeLimit;
    private string industry;

    public Contract(string name, string description, string industry, int award,
                  int level, int timeLimit, BasicPropertys propertys)
    {   this.name = name;
        this.description = description;
        this.industry = industry;
        this.award = award;
        this.level = level;
        this.propertys = propertys;
        this.timeLimit = timeLimit;
    }

    public string getName() { return name;}
    public string getDescription() { return description;}
    public int getLevel() { return level;}
    public int getAward() { return award;}
    public int getTimeLimit() { return timeLimit;}
    public string getIndustry() { return industry;}

    public BasicPropertys getPropertys()
    {   return propertys;
    }

    public string getDetail()
    {   return "Level "+level+"--"+name+" worths "+award+"$;";
    }

    public static void Main(string[] args)
    {
    }

}
