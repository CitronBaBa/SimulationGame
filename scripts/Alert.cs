using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Alert
{   private string message;

    public Alert(string message)
    {   this.message = message;
    }

    public string getMessage()
    {   return message;
    }

    public void setMessage(string message)
    {   this.message = message;
    }
}