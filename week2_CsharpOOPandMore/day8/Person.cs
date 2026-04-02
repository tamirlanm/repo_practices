
class Person
{
    private int age;
    public string Name {get; set;} = "";
    public int Age
    {
        get => age;
        set
        {
            if(value < 18)
                throw new Exception("Faces under 18 years registation is prohibited");
        }
    }

}