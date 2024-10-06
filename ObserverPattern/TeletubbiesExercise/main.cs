using TeletubbiesExercise;

class MainClass
{
    public static void Main()
    {
        Teletubbie tinkyWinky = new Teletubbie();
        Teletubbie lala = new Teletubbie();
        Teletubbie po = new Teletubbie();
        Teletubbie dipsy = new Teletubbie();
        Telephone telephone = new Telephone();
        Teletubbie[] allOfThem = {tinkyWinky, lala, dipsy, po};
        foreach(Teletubbie teletubbie in allOfThem)
        {
            telephone.Attach(teletubbie);
        }
        telephone.Notify();
        telephone.SetTime(DayPart.AFTERNOON);
        telephone.Notify();
        telephone.Detach(dipsy);
        telephone.SetTime(DayPart.EVENING);
        telephone.Notify();
        telephone.Attach(dipsy);
        telephone.SetTime(DayPart.NIGHT);
        telephone.Notify();
    }
}
