public class JsonEmployee {
    private string Name;
    private int Salary;
    private int Front;
    private int Back;
    private int Graphics;
    private string Description;
    private string Title;
    public JsonEmployee(string Name, int Salary, int Front, int Back, int Graphics, string Description, string Title) {
        this.Name = Name;
        this.Salary = Salary;
        this.Front = Front;
        this.Back = Back;
        this.Graphics = Graphics;
        this.Description = Description;
        this.Title = Title;
    }

    public string getName() {
        return Name;
    }

    public int getSalary() {
        return Salary;
    }

    public int getFront() {
        return Front;
    }

    public int getBack() {
        return Back;
    }

    public int getGraphics() {
        return Graphics;
    }

    public string getDescription() {
        return Description;
    }

    public string getTitle() {
        return Title;
    }

    
}