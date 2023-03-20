using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wed_ShopGaming.Models.Entity;

namespace Wed_ShopGaming.Models
{
    public class Sevices { 
    
        public static Sevices Create()
        {
            return new Sevices();
        }
        public static ApplicationDbContext _dbContext = ApplicationDbContext.Create();
        public static LoaiSPSevices LoaiSPSevice()
        {
            return LoaiSPSevices.Instance;
        }
    }
    public class LoaiSPSevices
    {

        private static LoaiSPSevices instance;
        public static LoaiSPSevices Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiSPSevices();
                }
                return instance;
            }
        }

        private ApplicationDbContext _dbContext;
        public LoaiSPSevices()
        {
            _dbContext = ApplicationDbContext.Create();
        }
        public List<LoaiSP> GetListLoaiSP()
        {
            return _dbContext.LoaiSPs.ToList();
        }
    }
}