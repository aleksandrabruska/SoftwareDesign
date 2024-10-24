using TheStatePattern;

class Program
{
    public static void Main(string[] args)
    {
        FlashLight light = new FlashLight();
        light.Power(); //on
        Thread.Sleep(100);
        light.Power(); // off
        Thread.Sleep(100);
        light.Power(); //on
        Thread.Sleep(100);

        light.Mode(); // blinking
        light.Mode(); // solid
        light.Mode();
        light.Power();
        light.Power();
    }
}