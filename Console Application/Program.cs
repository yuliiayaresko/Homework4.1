abstract class Worker
{
    public string Name;
    public string Position;
    public string WorkDay;
    public Worker(string name)
    {  Name = name;
        
    }
   

        public void Call()
        {
            Console.WriteLine($"{Name} is making a call.");
        }

        public void WriteCode()
        {
            Console.WriteLine($"{Name} is writing code.");
        }

        public void Relax()
        {
            Console.WriteLine($"{Name} is relaxing.");
        }

        public abstract void FillWorkDay();
    }
class Developer : Worker
{
    public Developer(string name, int WorkDay) : base("Розробник") { }
    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }

}

class Manager : Worker
{
    private Random random;
    public Manager(string position, int WorkDay) : base("Менеджер"){}
    public override void FillWorkDay()
    {
        int callTimes1 = random.Next(1, 11);  
        int callTimes2 = random.Next(1, 6);   

        for (int i = 0; i < callTimes1; i++)
        {
            Call();
        }
        Relax();
        for (int i = 0; i < callTimes2; i++)
        {
            Call();
        }
    }
}
class Team
{
    string TeamName;
    private List<Worker> workers;
    public Team(string teamname)
    {
        TeamName = teamname;
        workers = new List<Worker>();
    }
    public void AddWorker(Worker worker)
    {
        workers.Add(worker);
    }
    public void PrintTeamInfo()
    {
        Console.WriteLine($"Команда: {TeamName}");
        foreach (var worker in workers)
        {
            Console.WriteLine(worker.Name);  
        }
    }

    
    public void PrintDetailedTeamInfo()
    {
        Console.WriteLine($"Команда: {TeamName}");
        foreach (var worker in workers)
        {
            
            Console.WriteLine($"{worker.Name} - {worker.Position} - {worker.WorkDay}");
        }
    }
}
public class Programs
{
    private static void Main()
    {
        List<Team> teams = new List<Team>();

        bool addTeam = true;

        while (addTeam)
        {
            Console.Write("Введiть назву команди: ");
            string teamName = Console.ReadLine();
            Team team = new Team(teamName);
            teams.Add(team);

            bool addWorker = true;

            while (addWorker)
            {
                Console.Write("Бажаєте додати спiвробiтника? Напишiть так або нi: ");
                string answer = Console.ReadLine();

                if (answer == "так")
                {
                    Console.Write("Введiть iм'я вашого робiтника: ");
                    string name = Console.ReadLine();

                    Console.Write("Яку посаду вiн займає? Напишiть менеджер чи розробник: ");
                    string position = Console.ReadLine();

                    Console.Write("Скiльки годин придiляє роботi? Напишiть кiлькiсть годин: ");
                    int workDay = int.Parse(Console.ReadLine());

                    if (position.ToLower() == "розробник")
                    {
                        Developer developer = new Developer(name, workDay);
                        team.AddWorker(developer);
                    }
                    else if (position.ToLower() == "менеджер")
                    {
                        Manager manager = new Manager(name, workDay);
                        team.AddWorker(manager);
                    }
                    else
                    {
                        Console.WriteLine("Введена некоректна iнформацiя");
                    }
                }
                else if (answer == "нi")
                {
                    addWorker = false;
                }

                Console.Write("Бажаєте додати ще спiвробiтника в цiй командi? Якщо так, то введiть +, якщо нi, то - : ");
                string answer3 = Console.ReadLine();
                if (answer3 != "+")
                {
                    addWorker = false;
                }
            }

            Console.Write("Бажаєте додати ще команду? Якщо так, то введiть +, якщо нi, то - : ");
            string answer4 = Console.ReadLine();
            if (answer4 != "+")
            {
                addTeam = false;
            }
        }

        Console.Write("Бажаєте отримати детальну iнформацiю? Напишiть так або нi: ");
        string answer2 = Console.ReadLine();
        if (answer2 == "так")
        {
            foreach (var team in teams)
            {
                team.PrintDetailedTeamInfo();
            }
        }
    }
}




