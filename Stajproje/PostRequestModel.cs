namespace Stajproje
{
    public class PostRequestModel
    {
        public int Count { get; set; }




    }
    public class GetPersonelByNumberRequestModel
    {
        public string personelNumberString { get; set; }




    }
    public class AddPersonelRequestModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
    }

}
