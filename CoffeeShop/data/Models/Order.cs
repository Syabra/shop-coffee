using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Имя")]
        [MinLength(3)]
        [MaxLength(15)]
        [Required(ErrorMessage = "Длина имени не менее 3 символов")]
        public string name { get; set; }

        [Display(Name = "Фамилия")]
        [MinLength(4)]
        [MaxLength(20)]
        [Required(ErrorMessage = "Длина фамилии не менее 4 символов")]
        public string surname { get; set; }

        [Display(Name = "Адрес")]
        [MinLength(5)]
        [MaxLength(30)]
        [Required(ErrorMessage = "Длина адреса не менее 5 символов")]
        public string adress { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(8)]
        [MaxLength(15)]
        [Required(ErrorMessage = "Длина номера не менее 8 символов")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [MinLength(8)]
        [MaxLength(25)]
        [Required(ErrorMessage = "Длина email не менее 8 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetails> orderDetails { get; set; }
    }
}
