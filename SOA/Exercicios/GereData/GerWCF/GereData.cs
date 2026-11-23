namespace GeraWCF
{
    public class GereData:IData
    {
        public bool ValidDate(string s)
        {
            DateTime d;

            bool aux = DateTime.TryParse(s, out d);
            return aux;
        }
    }
}
