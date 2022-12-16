namespace blazor_metrozon.Models
{
    public class User
    {
        public int User_id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Money { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }



        public User(int user_id, string name, string surname, int money, string phone_number, string email, string password)
        {
            User_id = user_id;
            Name = name;
            Surname = surname;
            Money = money;
            Phone_number = phone_number;
            Email = email;
            Password = password;
        }
        public static User user = new User(1, "Mikle", "Frolov", 1200, "88005553535", "abobz@aboba.com", "12345");

    }         
}

