﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wed_ShopGaming.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult LinhKien()
        {
            return View();
        }
        public ActionResult MayTinh()
        {
            return View();
        }
    }
}