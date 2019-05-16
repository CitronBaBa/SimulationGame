public class JsonContract {
    private string Names;
    private string Industry;
    private int Rewards;
    private int Frontend;
    private int Backend;
    private int Graphics;
    private string Description;
    private int TimeLimits;
    private int Level;
    
    public JsonContract(string Names, string Industry, int Rewards, string Description, int Graphics, int Frontend, int Backend, int TimeLimits, int Level) {
        this.Names = Names;
        this.Industry = Industry;
        this.Rewards = Rewards;
        this.Description = Description;
        this.Graphics = Graphics;
        this.Frontend = Frontend;
        this.Backend = Backend;
        this.TimeLimits = TimeLimits;
        this.Level = Level;
    }

    public string getNames() {
        return Names;
    }

    public string getIndustry() {
        return Industry;
    }

    public int getRewards() {
        return Rewards;
    }

    public string getDescription() {
        return Description;
    }
    public int getGraphics() {
        return Graphics;
    }
    public int getFrontend() {
        return Frontend;
    }

    public int getBackend() {
        return Backend;
    }

    public int getTimeLimits() {
        return TimeLimits;
    }

    public int getLevel() {
        return Level;
    }
    
}