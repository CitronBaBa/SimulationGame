using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

        PlayerCompany.printEmployees();
        PlayerCompany.printAssets();
        PlayerCompany.printCompany();

        PrebuiltContracts.Add(new Contract("Bristol Romantic Website","romance",
            Industry.SpaceEngineering,500,1,100, new BasicPropertys(300,400,250)));

       Contract contract = new Contract("RAF webiste","raf",
            Industry.Military,500,1,170, new BasicPropertys(200,600,50));

       PrebuiltContracts.Add(new Contract("RAF webiste","raf",
            Industry.Military,500,1,170, new BasicPropertys(200,600,50)));

        PlayerCompany.takeProject(PrebuiltContracts[0],new string[] {"Lucy"});
        DeletePrebuiltContract(PrebuiltContracts[0]);
        //ontract contract = PrebuiltContracts[1];
        if(contract ==null) Debug.Log("wfwfwfwfwfw");
        PlayerCompany.takeProject(contract,new string[] {"Lisbon"});
        DeletePrebuiltContract(PrebuiltContracts[0]);
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
        Employee e1 = new Employee("Breanna Stewart", 100, "Junior Front End Developer", "Breanna is a fresh grafuate from the university of Leeds with an MEng degree in Software Engineering and outstanding accademic performance. She is very motivated to start as a Junior Front End Developer for a Web development company. She is very energetic and very commited to her line of work", new BasicPropertys(30,17,20));
        Employee e2 = new Employee("George McLean", 107, "Junior Front End Developer", "George is a Computer Science graduate who has completed his BSc studies from the university of Cardiff. He has many self-developed individual projects, such as  e-shops and building websites for small companies. He can be a valuable addition to the team. He is motivated and willing to stay for longer in case of an outstanding deadline", new BasicPropertys(31,18,22));
        Employee e3 = new Employee("Samantha Burns", 108, "Junior Front End Developer", "Samantha is a graduate with a MEng in Computer Engineering from the univesity of Brighton. She has very good front end development skills due to her two summer internships. She is very good at delivering projects and is very time efficient", new BasicPropertys(33,18,25));
        Employee e4 = new Employee("Amanda Beck", 112, "Junior Front End Developer", "Amanda is a junior front end developer and a graduate from the university of Birmingham with a BSc degree in Computer Science. She has completed a year in industry as a front end developer and is very eager to go back into work. She has completed multiple web based projects during both her year in industry and academics. Her experience can be of great value to the team due to her exposure in real-life projects and excellent academic performance", new BasicPropertys(35,19,26));
        Employee e5 = new Employee("Joshua Abbott", 107, "Junior Back End Engineer", "Joshua is a graduate with a MEng in Computer Science. He has good academic results and is very confident developing any back end features. His commitment into delivering high quality projects can be a great asset to the company.", new BasicPropertys(22,31,15));
        Employee e6 = new Employee("Sherrie Rush", 114, "Junior Back End Engineer", "Sherie is a junior back end engineer with a summer experience developing the back end of the website using relevant industry techniques. Her passion for back end development can be of great use for any project of this company.", new BasicPropertys(23,32,16));
        Employee e7 = new Employee("Jocelyn Woodard", 115, "Junior Back End Engineer", "Jocelyn is a graduate with a BEng in Computer Engineering from the university of Surrey. She has experience in delivering project that involve back end development for various areas. Her multidisciplinary experience can provide a great productivity boost for the company", new BasicPropertys(24,35,17));
        Employee e8 = new Employee("Dorothea Midgley", 115, "Junior Back End Engineer", "Dorothea is a graduate with a MEng in Software Engineering from Imperial College. She has also completed a year in industry and has very high back end skill. Her ability to generate and test code is unique and very effective. She can be a very sucessful back end developer and can significantly boost the productivity rate for back end projects", new BasicPropertys(25,35,18));
        Employee e9 = new Employee("Amelie Raymond", 107, "Junior Graphic Designeer", "Amelie is a graduate with a BSc in Graphics Design from the university of Bristol with a very successful academic record. She has completed all her university projects with distinction marks, which proves her ability to produce aesthetic and effective designs. She can be a good asset to the team", new BasicPropertys(20,15,30));
        Employee e10 = new Employee("Roxane McGill", 111, "Junior Graphic Designeer", "Roxane has an MEng degree in Graphics Design from the university of Brighton and experience with designing graphical features for her own projects. She can has a crystal clear sense of what should be implemented for graphical based designs. Her insight and skill can be proven very beneficial for the team.", new BasicPropertys(22,16,32));
        Employee e11 = new Employee("Carlos Santana", 114, "Junior Graphic Designeer", "Carlos is a graphic designer gradaute with a BSc degree from the university of Kent. He has experience from two summer internships as a graphics designer. His experience can be proven very beneficial since he will require less time to complete tasks faster and more effectively.", new BasicPropertys(23,17,33));
        Employee e12 = new Employee("Emily Ratajkowski", 121, "Junior Graphic Designeer", "Emily is a graduate with a MEng in Graphics Design from UCL with a year in industry as a graphical designer. She was one of the best interns at her company and she has an exemplary portfolio with various relevant projects. Her skill and experience can invigorate the graphical design team and produce much better projects that focus on the graphical part.", new BasicPropertys(25,19,35));
        Employee e13 = new Employee("Jack Black", 200, "Senior Front End Developer", "Jack is an experienced front end developer with many years of relevant industry experience. He has the ability to complete very difficult front end projects in little time. He is a very effective programmer and his front end skills can significantly enhance the productivity and quality of the overall team.", new BasicPropertys(51,23,28));
        Employee e14 = new Employee("Aurora Bowman", 214, "Senior Front End Developer", "Aurora is a senior front end developer with proven industry experience in several companies that develop web services. Her skill in front end development is very high and can be a great addition to the team since she can significantly speed up the overall development process for all web projects of the company", new BasicPropertys(52,24,32));
        Employee e15 = new Employee("Alvin Daniel", 207, "Senior Back End Engineers", "Alvin is a senior back end engineer with proven experience in multiple areas. His experience in coding in multiple programming languages can provide a great addition to the team. His multi disciplinary experience can be of great benefit for the team and produce really effective and testable code.", new BasicPropertys(29,50,24));
        Employee e16 = new Employee("Amber Brun", 210, "Senior Back End Engineers", "Amber is an experienced back end engineer with experience in various real-life applications. Her exposure to different fields can enhance the development production rate and also inspire the junior engineers to follow her strategy in developing and testing code. Her passion can be a great addition to this comapny", new BasicPropertys(31,52,26));
        Employee e17 = new Employee("Spencer Nguyen", 217, "Senior Graphic Designer", "Spencer is a senior graphics designer. He has a lot of experience in creating magnificent designs in various projects. His aesthetic appeal can significantly revolutionise the graphics of each project. He can be a great addition to the team.", new BasicPropertys(31,25,50));
        Employee e18 = new Employee("Nicola Oliverson", 224, "Senior Graphic Designer", "Nicola is an experienced graphics designer with proven industry experience. Her exposure to various fields of the graphics designing industry enabled her to build a unique skillset that can produce very effective graphical designs", new BasicPropertys(33,27,53));
        Employee e19 = new Employee("Yosef Griffith", 285, "Server Engineer", "Yosef has been involved with servers since his undergrad in IT informatics. He is very effective in working and maintaining with servers. ", new BasicPropertys(0,0,0));
        Employee e20 = new Employee("Angel Stein", 428, "Chief Server Engineer", "Angel is an experienced server engineer. She has been working with servers for many years and is very familiar with all principles on how to work and maintain the server systems of any company. She can be a great option for the server room of this company", new BasicPropertys(0,0,0));
        Employee e21 = new Employee("Steve Rogers", 571, "Senior Full Stack Developer", "Since the day he was injected with the super soldier serum, Steve Rogers started taking coding courses secretly from S.H.I.E.L.D. and showed his insight in producing high quality software in miminal time. He is able to hack most H.Y.D.R.A. servers and steal their data. During his time in the ice, Steve continued developing software and stopping hydra from his server inside his cryochamber He is a fantastic full stack developer and a lethal fighting machine. He is a perfect fit for this company.", new BasicPropertys(75,70,70));
        Employee e22 = new Employee("Peter Parker", 714, "Senior Full Stack Developer", "Peter Parker might only be a 15year old high school student but his skills in every technical aspect is outstanding. He can create any type of software that fulfills any requirement given from the job description. He is already a briliant scientist and a very strong full stack developer. He can speed up the production progress significantly", new BasicPropertys(80,75,85));
        Employee e23 = new Employee("Natasha Romanoff", 1000, "Senior Full Stack Developer", "Natasha Romanoff aka black widow is a living embodiment of combination of fighting and software skills. She can create any piece of software in a very fast pace and at the same time spy upon the progress of other hostile companies. Her quality of work is off the charts and no one would dare to questions her skills (dont do it, the dont call her black widow for nothing). She is possibly one of the best full stack developers that are working off the grid. She can be a great addition to the team", new BasicPropertys(95,85,90));
        Employee e24 = new Employee("Bruce Banner", 1428, "Senior Full Stack Developer", "Bruce Banner is a brilliant scientist with multiple PhDs in multiple area, which enabled him to evolve his coding skills. At the moment he is probably the best full stack developer that exists in the research facilities of the Avengers. When he find bugs in his code, he turns into the famous Hulk and codes 10 times faster and at the same time angrier. If you hire him it is highly likely that you might need to change the hardware a bit faster than you would expect. His skill is unique and should definitely be used to skyrocket the productivity and therefore profitability of the company", new BasicPropertys(110,120,105));
        Employee e25 = new Employee("Tony Stark", 2857, "Senior Full Stack Developer", "Anthony Start is the best engineer in the world. His knowledge in every field of engineering enabled him to be the best full stack developer of this universe. It is known that Tony Stark even beat Chuck Norris in a coding test. Yes he is that good. He can also bring his iron man suits and incorporate the whole company with Jarvis and Friday to completely maximise the productivity of the company. He is the best choice you can have. If you can, hire him.", new BasicPropertys(205,220,192));
        PrebuiltEmployees.Add(e1);
        PrebuiltEmployees.Add(e2);
        PrebuiltEmployees.Add(e3);
        PrebuiltEmployees.Add(e4);
        PrebuiltEmployees.Add(e5);
        PrebuiltEmployees.Add(e6);
        PrebuiltEmployees.Add(e7);
        PrebuiltEmployees.Add(e8);
        PrebuiltEmployees.Add(e9);
        PrebuiltEmployees.Add(e10);
        PrebuiltEmployees.Add(e11);
        PrebuiltEmployees.Add(e12);
        PrebuiltEmployees.Add(e13);
        PrebuiltEmployees.Add(e14);
        PrebuiltEmployees.Add(e15);
        PrebuiltEmployees.Add(e16);
        PrebuiltEmployees.Add(e17);
        PrebuiltEmployees.Add(e18);
        PrebuiltEmployees.Add(e19);
        PrebuiltEmployees.Add(e20);
        PrebuiltEmployees.Add(e21);
        PrebuiltEmployees.Add(e22);
        PrebuiltEmployees.Add(e23);
        PrebuiltEmployees.Add(e24);
        PrebuiltEmployees.Add(e25);
    }
}
