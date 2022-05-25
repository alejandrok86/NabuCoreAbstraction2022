namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    public class Email : BaseType
    {
        public int? EmailID { get; set; }
        public PeopleAndPlaces.ElectronicAddress CreatedBy { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Options { get; set; }

        public PeopleAndPlaces.ElectronicAddress[] Recipients { get; set; }

        public Email()
        {
        }

        public Email(int pEmailID)
        {
            EmailID = pEmailID;
        }

        public Email(int? pEmailID)
        {
            EmailID = pEmailID;
        }

        public string ListRecipientsAsCSV()
        {
            string csv = "";
            if (Recipients != null)
            {
                foreach (PeopleAndPlaces.ElectronicAddress recipient in Recipients)
                {
                    if (recipient.ErrorsDetected == false)
                    {
                        if (csv.Length > 0)
                            csv += ", ";
                        csv += recipient.ElectronicAddressDetail;
                    }
                }
            }
            return csv;
        }
        public string ListRecipientsAsSemiColonSeparated()
        {
            string csv = "";
            if (Recipients != null)
            {
                foreach (PeopleAndPlaces.ElectronicAddress recipient in Recipients)
                {
                    if (recipient.ErrorsDetected == false)
                    {
                        if (csv.Length > 0)
                            csv += ";";
                        csv += recipient.ElectronicAddressDetail;
                    }
                }
            }
            return csv;
        }
    }
}
