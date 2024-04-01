using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartHotell.Models
{
    public class RegisterModel 
    {
        [Key]
        public long ID { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự ")]
        public string Password { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầy nhập Email")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Yêu cầy nhập SDT")]
        public string Phone { get; set; }
    }
}