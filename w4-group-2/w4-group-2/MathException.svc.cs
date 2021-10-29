using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace w4_group_2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MathException : IMathException
    {
        public string DivisionExample(int numerator, int denominator)
        {
            try
            {
                float result = numerator / denominator;
                return result.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public string FormattingError(string Number)
        {
            try
            {
                return Convert.ToSingle(Number).ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public string DivisionExampleSoapMessage(int numerator, int denominator)
        {
            try
            {
                float result = numerator / denominator;
                return result.ToString();
            }
            catch (Exception e)
            {

                throw new FaultException<DivideByZeroException>(new DivideByZeroException(), "Divide By Zero", new FaultCode("Divide By Zero Error"));
            }
        }


        public string FormattingErrorSoapMessage(string Number)
        {
            try
            {
                return Convert.ToSingle(Number).ToString();
            }
            catch (FormatException e)
            {
                //throw new FaultException<FormatException>(new FormatException(),"Formatting Error", new FaultCode("Formatting Error"));
                throw new FaultException<FormatException>(e, "Formatting Error", new FaultCode("Formatting Error"));


            }

        }
    }
}
