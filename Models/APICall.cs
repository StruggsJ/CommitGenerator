namespace ProtoType.Models
{
    public class APICall
    {

        public CommitRoot GetCommit()
        {
            var client = new HttpClient();
            var url = "https://whatthecommit.com/index.txt";
            var response = client.GetStringAsync(url).Result;

            return new CommitRoot()
            {
                Commit = response.ToString()
            };
        }


    }
}
