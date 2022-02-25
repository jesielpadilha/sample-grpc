namespace SampleGrpc.Server.Models
{
    public class City
    {
        public City()
        {
            LoadCities();
        }

        public City(string name, string state)
        {
            Name = name;
            State = state;
        }

        public string Name { get; private set; }

        public string State { get; private set; }

        private static List<City> Cities { get; set; } = new List<City>();

        public static List<City> GetCities()
        {
            if (!Cities.Any())
                LoadCities();

            return Cities;
        }

        public static void AddCity(City city)
        {
            Cities.Add(city);
        }

        private static void LoadCities()
        {
            Cities = new List<City>
            {
                new City("Brasilia", "DF"),
                //new City("Goiania", "GO"),
                //new City("Belo Horizonte", "MG"),
                //new City("São Luiz", "MA"),
                //new City("Manaus", "AM"),
                //new City("Curitiba", "PR"),
                //new City("São Bernardo do Campo", "SP"),
                //new City("São Paulo", "SP"),
                //new City("Palmas", "TO")
            };
        }
    }
}