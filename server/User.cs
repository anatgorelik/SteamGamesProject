
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace hw1_Anat_Noa.Models

{
    public class User
    {
        int id;
        string name;
        string email;
        string password;
        bool active= true;
        static List<User> UsersList= new List<User>();

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool Active { get => active; set => active = value; }

        public User() { }

        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }


        public List<User> Read()
        {
            return UsersList;
        }

        public bool Register()
        {
            foreach (User lstUser in UsersList)
            {
                if (lstUser.Id == this.Id || lstUser.Email == this.Email)
                    return false;
            }
            this.Password = CreateHash(this.Password);
            UsersList.Add(this);
            return true;
        }

        public User Login()
        {
            foreach (User lstUser in UsersList)
            {
                if (lstUser.Email == this.Email && CheckPassword(this.Password, lstUser.Password))
                    return lstUser;
            }
            return null;
        }

        private string CreateHash(string password) 
        {
            SHA256 sha = SHA256.Create();

            byte[] bytes = Encoding.UTF8.GetBytes(password);

            byte[] hashBytes = sha.ComputeHash(bytes);

            string result = "";

            for (int i = 0; i < hashBytes.Length; i++)
            {
                result += hashBytes[i].ToString("X2");
            }

            return result;
        }

        private bool CheckPassword(string inputPassword, string savedPassword)
        {
            string inputHash = CreateHash(inputPassword);
            if (inputHash == savedPassword)
                return true;
            return false;
        }
    }
}
