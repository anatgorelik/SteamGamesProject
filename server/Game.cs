using System.Collections.Generic;
namespace hw1_Anat_Noa.Models
{
    public class Game
    {
        int id;
        string name;
        string steamUrl;
        string image;
        string releaseDate;
        string reviewSummary;
        int price;
        List<string> tags;
        bool windows;
        bool mac;
        bool linux;
        static List<Game> GamesList = new List<Game>();

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string SteamUrl { get => steamUrl; set => steamUrl = value; }
        public string Image { get => image; set => image = value; }
        public string ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public string ReviewSummary { get => reviewSummary; set => reviewSummary = value; }
        public int Price { get => price; set => price = value; }
        public List<string> Tags { get => tags; set => tags = value; }
        public bool Windows { get => windows; set => windows = value; }
        public bool Mac { get => mac; set => mac = value; }
        public bool Linux { get => linux; set => linux = value; }


        public Game(int id, string name, string steamUrl, string image, string releaseDate, string reviewSummary, int price, List<string> tags, bool windows, bool mac, bool linux)
        {
            Id = id;
            Name = name;
            SteamUrl = steamUrl;
            Image = image;
            ReleaseDate = releaseDate;
            ReviewSummary = reviewSummary;
            Price = price;
            Tags = tags;
            Windows = windows;
            Mac = mac;
            Linux = linux;

        }
        public Game()
        {
            Tags = new List<string>();

        }

        public bool Insert()
        {
            foreach (Game lstGame in GamesList)
            {
                if (lstGame.Id == this.Id || lstGame.Name == this.Name)
                    return false;

            }
            GamesList.Add(this);
            return true;
        }

        public List<Game> Read()
        {
            return GamesList;
        }


        public List<Game> GetByName(string name)
        {
            List<Game> result = new List<Game>();
            foreach (Game g in GamesList)
            {
                if (g.Name.Contains(name))
                    result.Add(g);
            }
            return result;

        }

        public bool UpdateGame(int oldId, Game newGame)
        {
            Game gameToUpdate = null;

            foreach (Game g in GamesList)
            {
                if (g.Id == oldId)
                    gameToUpdate = g;
            }

            if (gameToUpdate == null)
                return false;

            foreach (Game g in GamesList)
            {
                if (g.Id != oldId)
                {
                    if (g.Id == newGame.Id || g.Name == newGame.Name)
                    {
                        return false;
                    }
                }
            }

            gameToUpdate.Id = newGame.Id;
            gameToUpdate.Name = newGame.Name;
            gameToUpdate.SteamUrl = newGame.SteamUrl;
            gameToUpdate.Image = newGame.Image;
            gameToUpdate.ReleaseDate = newGame.ReleaseDate;
            gameToUpdate.ReviewSummary = newGame.ReviewSummary;
            gameToUpdate.Price = newGame.Price;
            gameToUpdate.Tags = newGame.Tags;
            gameToUpdate.Windows = newGame.Windows;
            gameToUpdate.Mac = newGame.Mac;
            gameToUpdate.Linux = newGame.Linux;

            return true;
        }

        public bool DeleteById(int id)
        {
            Game gameToDelete = null;
            foreach (Game g in GamesList)
            {
                if (g.Id == id)
                {
                    gameToDelete = g;
                    break;
                }
            }
            if (gameToDelete != null)
            {
                GamesList.Remove(gameToDelete);
                return true;
            }
            return false;
        }
    }
}
