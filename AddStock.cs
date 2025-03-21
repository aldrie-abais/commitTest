namespace BloodBankManagementSystem
{
    public class AddBloodStock
    {
        public string BloodGroup { get; set; }
        public int BloodQty { get; set; }

        //public int QMinusQty
        public int AMinusQty { get; set; }

        public AddBloodStock()
        {

        }

        public AddBloodStock(int bloodQty)
        {
            BloodQty = bloodQty;
        }

        public AddBloodStock(String bloodGroup, int bloodQty, int aMinusQty)
        {
            BloodGroup = bloodGroup;
            BloodQty = bloodQty;
            AMinusQty = aMinusQty;
        }
    }
}

