namespace JaratKezeloProjekt
{
    public class JaratKezelo
    {
        private List<Jarat> jaratok = new List<Jarat>();

        public void UjJarat(string jaratSzam, string kezdetiRepuloter, string celRepuloter, DateTime indulasIdopontja, int aktualisKeses)
        {
            Jarat ujJarat = new Jarat
            {
                jaratSzam = jaratSzam,
                kezdetiRepuloter = kezdetiRepuloter,
                celRepuloter = celRepuloter,
                indulasIdopontja = indulasIdopontja,
                aktualisKeses = 0
            };
            jaratok.Add(ujJarat);
        }
    }
}
