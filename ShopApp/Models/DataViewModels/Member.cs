using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models.DataViewModels
{
    [Table(name: "Member")]
    public class Member
    {
        [Key, Column(name: "ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(name: "Email")]
        public string Email { get; set; }
        [Column(name: "Password")]
        public string Password { get; set; }
        [Column(name: "Name")]
        public string Name { get; set; }
        [Column(name: "BrithDay")]
        public System.Nullable<System.DateTime> BrithDay { get; set; }
        [Column(name: "Sex")]
        public System.Nullable<bool> Sex { get; set; }
        [Column(name: "PhoneBelongAddress")]
        public string PhoneBelongAddress { get; set; }
        [Column(name: "Phone")]
        public string Phone { get; set; }
        [Column(name: "Mobile")]
        public string Mobile { get; set; }
        [Column(name: "QQ")]
        public string QQ { get; set; }
        [Column(name: "MSN")]
        public string MSN { get; set; }

        [Column(name: "Skype")]
        public string Skype { get; set; }
        [Column(name: "StudySchool")]
        public System.Nullable<int> StudySchool { get; set; }
        [Column(name: "CityId")]
        public string CityId { get; set; }
        [Column(name: "ViewSupportId")]
        public System.Nullable<int> ViewSupportId { get; set; }
        [Column(name: "ViewSupportName")]
        public string ViewSupportName { get; set; }
        [Column(name: "SupportID")]
        public System.Nullable<int> SupportID { get; set; }

        [Column(name: "SupportName")]
        public string SupportName { get; set; }
        [Column(name: "SupportCode")]
        public string SupportCode { get; set; }
        [Column(name: "ComeUrl")]
        public string ComeUrl { get; set; }
        [Column(name: "IPBelongAddress")]
        public string IPBelongAddress { get; set; }
        [Column(name: "SessionId")]
        public System.Nullable<int> SessionId { get; set; }
        [Column(name: "CustomerName")]
        public string CustomerName { get; set; }
        [Column(name: "Description")]
        public string Description { get; set; }
        [Column(name: "ImportType")]
        public string ImportType { get; set; }
        [Column(name: "KeyWord")]
        public string KeyWord { get; set; }
        [Column(name: "EnterType")]
        public string EnterType { get; set; }
        [Column(name: "IsCompany")]
        public bool IsCompany { get; set; }
        [Column(name: "CompanyName")]
        public string CompanyName { get; set; }
        [Column(name: "IsReady")]
        public bool IsReady { get; set; }
        [Column(name: "UnLock")]
        public bool UnLock { get; set; }
        [Column(name: "IsOpera")]
        public bool IsOpera { get; set; }
        [Column(name: "IsCrm")]
        public bool IsCrm { get; set; }
        [Column(name: "IP")]
        public string IP { get; set; }
        [Column(name: "RegisterTime")]
        public System.DateTime RegisterTime { get; set; }
        [Column(name: "RegisterUrl")]
        public string RegisterUrl { get; set; }
        [Column(name: "Age")]
        public string Age { get; set; }
        [Column(name: "CityAreaId")]
        public System.Nullable<int> CityAreaId { get; set; }
        [Column(name: "StudyPurpose")]
        public string StudyPurpose { get; set; }
        [Column(name: "ProtectedTimes")]
        public System.Nullable<System.DateTime> ProtectedTimes { get; set; }
        [Column(name: "IsAborad")]
        public System.Nullable<int> IsAborad { get; set; }
        [Column(name: "IsCheck")]
        public int IsCheck { get; set; }
        [Column(name: "OfferType")]
        public System.Nullable<int> OfferType { get; set; }
        [Column(name: "FirstLevel")]
        public System.Nullable<int> FirstLevel { get; set; }
        [Column(name: "SecondLevel")]
        public System.Nullable<int> SecondLevel { get; set; }
        [Column(name: "Keywords")]
        public System.Nullable<int> Keywords { get; set; }
        [Column(name: "DataType")]
        public System.Nullable<int> DataType { get; set; }
        [Column(name: "StateLogId")]
        public System.Nullable<int> StateLogId { get; set; }
        [Column(name: "StateLogKey")]
        public string StateLogKey { get; set; }
    }
}
