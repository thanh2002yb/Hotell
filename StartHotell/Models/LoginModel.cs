﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartHotell.Models
{
    public class LoginModel : IdentityUserLogin
    {
        [Required(ErrorMessage = "Mời bạn nhập tên tài khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời bạn nhập mật khẩu")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}