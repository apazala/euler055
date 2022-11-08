using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<BigInteger> nonLychrelSet = new HashSet<BigInteger>();
        HashSet<BigInteger> lychrelSet = new HashSet<BigInteger>();
        List<BigInteger> chainCheck = new List<BigInteger>(50);
        const int TARGET = 10000;
        const int MAXITER = 50;
        int count = 0;
        BigInteger n, nrev;
        for (int i = 1; i < TARGET; i++)
        {
            //Important!! first iteration is mandatory because there are palindromes that are Lychrel
            n = i;
            nrev = ReverseInt(n);
            n += nrev;

            bool isLychrel = true;
            chainCheck.Clear();
            for (int j = 0; j < MAXITER; j++)
            {
                if (lychrelSet.Contains(n))
                {
                    break;
                }
                if (nonLychrelSet.Contains(n))
                {
                    isLychrel = false;
                    break;
                }
                chainCheck.Add(n);
                nrev = ReverseInt(n);
                if(nrev.Equals(n)){
                    isLychrel = false;
                    break;
                }else{
                    n+=nrev;
                }
            }

            if(isLychrel){
                count++;
                foreach(BigInteger b in chainCheck){
                    lychrelSet.Add(b);
                }
            }else{
                foreach(BigInteger b in chainCheck){
                    nonLychrelSet.Add(b);
                }
            }
        }
        Console.WriteLine(count);
    }

    private static BigInteger ReverseInt(BigInteger n)
    {
        BigInteger rev = 0;
        BigInteger d;
        while (n > 0)
        {
            n = BigInteger.DivRem(n, 10, out d);
            rev = 10 * rev + d;
        }
        return rev;
    }
}