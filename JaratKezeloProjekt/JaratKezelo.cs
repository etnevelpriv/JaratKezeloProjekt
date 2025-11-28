namespace JaratKezeloProjekt
{
    public class JaratKezelo
    {
        private List<Jarat> jaratok = new List<Jarat>();

        public void UjJarat(string jaratSzam, string kezdetiRepuloter, string celRepuloter, DateTime indulasIdopontja)
        {
            Jarat ujJarat = new Jarat
            {
                jaratSzam = jaratSzam,
                kezdetiRepuloter = kezdetiRepuloter,
                celRepuloter = celRepuloter,
                indulasIdopontja = indulasIdopontja,
                aktualisKeses = 0
            };
            if (jaratok.Any(j => j.jaratSzam == jaratSzam))
            {
                throw new ArgumentException("Már létező járatszám!");
            }
            else
            {
                jaratok.Add(ujJarat);
            }
        }
        public void Keses(string jaratSzam, int aktualisKeses)
        {
            Jarat jarat = jaratok.Find(j => j.jaratSzam == jaratSzam);
            if (jarat != null)
            {
                if (jarat.aktualisKeses + aktualisKeses >= 0)
                {
                    jarat.aktualisKeses += aktualisKeses;
                }
                else
                {
                    throw new ArgumentException("A késés nem lehet negatív!");
                }
            }
        }

        public DateTime MikorIndul(string jaratSzam)
        {
            Jarat jarat = jaratok.Find(j => j.jaratSzam == jaratSzam);
            if (jarat != null)
            {
                return jarat.indulasIdopontja.AddMinutes(jarat.aktualisKeses);
            }
            throw new ArgumentException("Nincs ilyen járat!");
        }

        public List<string> JaratokRepuloterrol(string kezdetiRepuloter)
        {
            List<string> lista = new List<string>();
            
            foreach (var jarat in jaratok)
            {
                if (jarat.kezdetiRepuloter == kezdetiRepuloter)
                {
                    lista.Add(jarat.jaratSzam);
                }
            }
            return lista;
        }
    }
}
