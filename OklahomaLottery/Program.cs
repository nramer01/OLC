using System;
using System.Net.Http;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace OklahomaLottery 
{
    [DataContract]
    internal class Plays
    {
        [DataMember(Name = "date_played")]
        public int Date_played { get; set; }
        [DataMember(Name = "games_played")]
        public string[] Games_played { get; set; }
    }

    internal class Program
    {


        private const string Url = "https://www.lottery.ok.gov/plays.json";

        private static void Main()
        {


            GetPlaysAsync();
            Console.ReadLine();


        }


        private static async void GetPlaysAsync()
        {
            string Game_1;
            Console.WriteLine($"What is the first game?");
            Game_1 = Console.ReadLine();

            int count = 0;
            int i = 0;

            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync(Url);

            var plays = JsonConvert.DeserializeObject<Plays[]>(response);

            foreach (var game in plays)
            {

                int date_played = game.Date_played;
                string[] games_played = game.Games_played;
                if (games_played[i] == Game_1)
                {

                    count++;
                    i++;

                }
                else
                {
                    i++;

                }

            }

            Console.WriteLine(Game_1 + "is played" + count + "times");
            Console.ReadLine();




        }

    }

}
