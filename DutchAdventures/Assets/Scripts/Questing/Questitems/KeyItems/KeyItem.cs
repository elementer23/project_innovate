[System.Serializable]
public class KeyItem
{
    //fields to create an keyItem
    public string name;
    public bool collected;

    public KeyItem(string name, bool collected)
    {
        this.name = name;
        this.collected = collected;
    }
}