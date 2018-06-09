using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models.DataViewModels
{
    public class AddDataViewModel
    {
        public int id { get; set; }
        public string classify { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string modelmum { get; set; }
        public string imageurl { get; set; }
        public string remark { get; set; }
        public string createuser { get; set; }
        public DateTime? createdate { get; set; }
        public string updateuser { get; set; }
        public DateTime? updatedate { get; set; }
    }
}
