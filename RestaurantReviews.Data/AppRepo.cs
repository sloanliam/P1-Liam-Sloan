using RestaurantReviews.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Data
{
    public class AppRepo
    {
        /// <summary>
        /// 
        /// </summary>

        /// <dependencies>
        /// Ef Core SqlServer
        /// Ef Core Design
        /// Ef Core Tools
        /// </dependencies>

        private revtrainingdbContext _context;

        public string GetUsername(int userId)
        {
            var userList = _context.Users.Where(u => u.Id == userId);

            return userList.ToString();
        }
    }
}
