using EverTech.Permission.Molecules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace EverTech.Permission.Web.Utils
{
    public class LoginInfo
    {
        public static SysUserMolecule Loginer  => Admin();

        public static SysUserMolecule Admin()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var currentUserCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (currentUserCookie == null) return new SysUserMolecule();
                var ticket = FormsAuthentication.Decrypt(currentUserCookie.Value);
                return JsonConvert.DeserializeObject<SysUserMolecule>(ticket.UserData);
            }
            return new SysUserMolecule(); ;
        }
    }
}