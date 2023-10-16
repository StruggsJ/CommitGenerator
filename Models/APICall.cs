using System.Linq;

namespace ProtoType.Models

{
    public class APICall
    {

        //To-Do: Figure out why the filter is not working properly. 

        public CommitRoot GetCommit()
        {
            var client = new HttpClient();
            var url = "https://whatthecommit.com/index.txt";
            var response = client.GetStringAsync(url).Result;

            HashSet<string> filter = new HashSet<string>() { "fuck", "fucking", "shit", "shitting", "Fuck", "Fucking", "Shit", "Shitting" };
            var generatedWords = response.ToList();
            var hasFilteredWord = generatedWords.Where(word => word.Equals(filter.Any())).ToList();
            bool isGood = true;

            foreach (var word in generatedWords)
            {
                if (hasFilteredWord.Contains(word))
                {
                    isGood = false;
                }
                else
                {

                }
            }

            while (isGood == false)
            {
                response = client.GetStringAsync(url).Result;
                generatedWords = response.ToList();
                hasFilteredWord = generatedWords.Where(word => word.Equals(filter.Any())).ToList();

                foreach (var word in generatedWords)
                {
                    if (hasFilteredWord.Contains(word))
                    {
                        isGood = false;
                    }
                    else
                    {

                    }
                }
            }

            if (isGood == true)
            {
                 
                return new CommitRoot()
            {
                Commit = response.ToString()
            };

            }
            else
            {
                throw new Exception("Error");
            }
           
        }


    }
}
