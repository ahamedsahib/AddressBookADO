using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookADO
{
    public class AddressBookModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string stateName { get; set; }
        public int zipCode { get; set; }
        public Int64 phoneNumber { get; set; }
        public string emailId { get; set; }
        public string addressBookName { get; set; }
        public string RelationType { get; set; }
        public int addressBookId { get; set; }
        public int personId { get; set; }
    }
}
