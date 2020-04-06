using System.Text;

namespace CondeJem2020Qualify.Q2
{
    public class StringWrapper
    {
        public string Wrap(string raw)
        {
            var oldValue = '0';
            StringBuilder sb = new StringBuilder();
            foreach (var ch in raw)
            {
                var newValue = ch;
                int diff = newValue - oldValue;
                if(diff > 0)
                {
                    for (int i = 0; i < diff; i++)
                    {
                        sb.Append('(');
                    }
                }
                else if(diff < 0)
                {
                    for (int i = 0; i < -diff; i++)
                    {
                        sb.Append(')');
                    }
                }
                oldValue = newValue;
                sb.Append(ch);
            }

            for (int i = 0; i < oldValue - '0'; i++)
            {
                sb.Append(')');
            }
            return sb.ToString();
        }
    }



}
