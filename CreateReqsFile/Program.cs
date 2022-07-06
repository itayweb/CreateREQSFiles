using System;

namespace CreateReqsFile // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static async Task CreateReqs()
        {
            string order = "";
            int skip = 0, take = 0;
            var reqs = new List<string>();
            using StreamWriter file = new("test.txt", append: true);
            for (int i = 0; i < 200000; i++)
            {
                var rand = new Random();
                var rndResult = rand.Next(2);
                order = rndResult == 0 ? "asc" : "desc";
                
                //var format = $"/queries/users/orderbydates?order={order}&type=string&skip={skip}&take={take}";
                string str = "";
                skip = rand.Next(20, 199);
                take = rand.Next(20, 199);
                str = string.Format("/queries/users/orderbydates?order={0}&type=string&skip={1}&take={2}", order, skip,
                    take);
                //var format = $"/queries/users/orderbydates?order={order}&type=string&skip={skip}&take={take}";
                Console.WriteLine(i + " " + str);
                await file.WriteLineAsync(str);
            }
            file.Close();
        }

        static async Task Main(string[] args)
        {
            await CreateReqs();
        }
    }
}