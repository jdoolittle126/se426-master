using System;

namespace w2_group_activity_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private CalculatorWebService.Calculator _calculator;
        private PhoneWebService.PhoneVerify _phoneVerify;
        private AddressWebService.AddressLookup _addressLookup;

        protected void Page_Load(object sender, EventArgs e)
        {
            _calculator = new CalculatorWebService.Calculator();
            _phoneVerify = new PhoneWebService.PhoneVerify();
            _addressLookup = new AddressWebService.AddressLookup();
        }

        private (int, int) GatherCalculatorInput()
        {
            int box1Input, box2Input = 0;
            int.TryParse(TextBoxCalculatorInput1.Text, out box1Input);
            int.TryParse(TextBoxCalculatorInput2.Text, out box2Input);

            return (box1Input, box2Input);
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            var input = GatherCalculatorInput();
            CalculatorResult.Text = _calculator.Add(input.Item1, input.Item2).ToString();   
        }

        protected void ButtonSubtract_Click(object sender, EventArgs e)
        {
            var input = GatherCalculatorInput();
            CalculatorResult.Text = _calculator.Subtract(input.Item1, input.Item2).ToString();
        }

        protected void ButtonGetRegion_Click(object sender, EventArgs e)
        {
            var result = _phoneVerify.CheckPhoneNumber(TextBoxPhone.Text, "0");
            OutputRegion.Text = $"{result.TelecomCity}, {result.TelecomState} {result.TelecomZip}";
        }

        protected void ButtonFindZipCodes_Click(object sender, EventArgs e)
        {
            OutputZipCode.Text = "";

            var result = _addressLookup.CityStateToZipCodeMatcher(TextBoxCity.Text, TextBoxState.Text, false, "0");
            
            foreach(object zipcode in result)
            {
                OutputZipCode.Text += $"{zipcode} ";
            }

        }
    }
}