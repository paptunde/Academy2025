using static System.Net.Mime.MediaTypeNames;

namespace Academy2025
{
    public class calculator1
    {
        public void sum(int x,int z)
        {
			Console.WriteLine(x + z);
        }
		public void kivonas(int x, int z)
		{
			Console.WriteLine(x - z);
		}
		public void szorzas(int x, int z)
		{
			Console.WriteLine(x * z);
		}
		public void osztas(int x, int z)
		{
			if (z == 0) Console.WriteLine("Nullával nem osztunk!");
			Console.WriteLine(x / z);
		}
	}
}
