using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace ProtoType.Models

{
    public class APICall
    {

        public CommitRoot GetCommit()
        {
            var client = new HttpClient();
            var url = "https://whatthecommit.com/index.txt";
            var response = client.GetStringAsync(url).Result;

            HashSet<string> filter = new HashSet<string>() { "fuck", "fucking", "shit", "shitting", "fuckup", "ass", "asshole", "damn", "damnit", "asshat" };
            char[] punctuationList = { '.', '?', '!', ' ', ',' };
            var generatedWords = response.Split(' ').ToList();
            bool isGood = true;
            string screenedWord = "";

            foreach (var word in generatedWords)
            {
                screenedWord = word.ToLower().Trim().TrimEnd(punctuationList);
                if (filter.Contains(screenedWord) == true)
                {
                    isGood = false;
                    break;
                }
                else
                {

                }
            }

            while (isGood == false)
            {
                response = client.GetStringAsync(url).Result;
                generatedWords = response.Split(' ').ToList();
                

                foreach (var word in generatedWords)
                {
                    screenedWord = word.ToLower().Trim().TrimEnd(punctuationList);
                    if (filter.Contains(screenedWord) == true)
                    {
                        isGood = false;
                        break;
                    }
                    else
                    {

                    }

                    isGood = true;
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
