using UserDBApp.Model;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Enter the command you wish to perform:\nAdd\nRemove\nUpdate\nSelect");
        string read=Console.ReadLine();
        using (UserContext db=new UserContext())
        {
            if(read=="Add")
            {
                User u= new User();
   
                Console.WriteLine("Enter name, age, city:");
                string[] parameters = Console.ReadLine().Split(", ").ToArray();
                u.Username= parameters[0];
                u.Age = int.Parse(parameters[1]);
                u.City= parameters[2];
                db.Users.Add(u);
                db.SaveChanges();
                Console.WriteLine("User has been registered successfully");
            }
            else if(read=="Remove")
            {
                Console.WriteLine("Enter id");
                int id = int.Parse(Console.ReadLine());
                List<User> list = new List<User>();
                list=db.Users.ToList();
                bool removed = false;
                foreach(User u in list)
                {
                    if(u.UserId==id)
                    {
                        db.Users.Remove(u);
                        db.SaveChanges();
                        Console.WriteLine("User successfully removed");
                        removed = true;
                        break;
                    }
                }
                if(removed==false)
                {
                    Console.WriteLine("User wasn't removed (no such id)");
                }
            }
            else if(read =="Select")
            {
                List<User> list = new List<User>();
                list = db.Users.ToList();
                foreach (User u in list)
                {
                    Console.WriteLine(u);
                }
            }
            else if(read=="Update")
            {
                List<User> list = new List<User>();
                list = db.Users.ToList();
                Console.WriteLine("Enter user id");
                int id = int.Parse(Console.ReadLine());
                id--;
                Console.WriteLine("Enter new info: name, age, city");
                string[] parameters = Console.ReadLine().Split(", ").ToArray();
                list[id].Username= parameters[0];
                list[id].Age = int.Parse(parameters[1]);
                list[id].City= parameters[2];
                db.Users.Update(list[id]);
                db.SaveChanges();
            }
        }
    }
}