using System.Collections.Generic;

namespace Ian.ShareApp
{
    public class Program
    {
        public static void Main()
        {
            _ = new ShareApplication(new List<User> { new User("John"), new User("Peter"), new User("Mary") });
        }
    }
}
