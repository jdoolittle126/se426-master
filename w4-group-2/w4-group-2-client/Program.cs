using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace w4_group_2_client
{
    class Program
    {
        static void Main(string[] args)
        {


            MathException.MathExceptionClient proxy = new MathException.MathExceptionClient("BasicHttpBinding_IMathException");

            try
            {
                Console.WriteLine(proxy.DivisionExample(4, 0));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(proxy.FormattingError("a"));

            try
            {
                Console.WriteLine(proxy.DivisionExampleSoapMessage(4, 0));

            }

            catch (FaultException<DivideByZeroException> ex)
            {
                Console.WriteLine("Divide By Zero Exception code   " + ex.Detail.Source + " - " + ex.Code + " - " + ex.Reason);
            }

            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine(proxy.FormattingErrorSoapMessage("a"));

            }
            catch (FaultException<FormatException> ex)
            {
                Console.WriteLine("Format Exception code   " + ex.Detail.Source + " - " + ex.Code + " - " + ex.Reason);
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Code.Name + ":" + ex.Reason);
            }

            Console.WriteLine("Press enter to finish");
            Console.ReadLine();
        }
    }
}
