﻿namespace Stajproje
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

    public class UpdatePersonelRequestModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public int PersonelId { get; set; }
    }

    public class DeletePersonelRequestModel
    {
        
        public int PersonelId { get; set;}

    }
}
