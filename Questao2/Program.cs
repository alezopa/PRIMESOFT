using Newtonsoft.Json;
using Questao2;

public class Program
{

    static HttpClient client = new HttpClient();
    public static  void Main()
    {

    

        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year).Result;



       


        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year).Result;

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        var _total = await Busca(team,year);

        return _total;
    }

    public static async Task<int>  Busca(string team, int year)
    {

        var retorno = new Dados();
        int _total = 0;

        var url = string.Format(@"https://jsonmock.hackerrank.com/api/football_matches?year={0}&team1={1}", year, team);

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                 retorno = JsonConvert.DeserializeObject<Dados>(data);

            }
        }

        if(retorno != null)
        {

            _total = retorno.Data.Where(c=>c.Team1 == team).Sum(m=>m.Team1goals);

        }


        return _total;

    }



}