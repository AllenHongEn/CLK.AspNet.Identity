﻿using CLK.AspNet.Identity.WebSite.Models;
using CLK.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using System.Security.Principal;

namespace CLK.AspNet.Identity.WebSite
{
    public class RBACAuthorizeHelper : CLK.AspNet.Identity.Mvc.RBACAuthorizeHelper
    {
        // Singleton
        private static RBACAuthorizeHelper _current = null;
        public static RBACAuthorizeHelper Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new RBACAuthorizeHelper();
                }
                return _current;
            }
        }


        // Methods
        protected override PermissionAuthorize GetPermissionAuthorize()
        {
            return new ApplicationPermissionAuthorize(HttpContext.Current.GetOwinContext().Get<ApplicationPermissionManager>());
        }
    }
}