namespace ShapeGenerator
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list, Random random)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
