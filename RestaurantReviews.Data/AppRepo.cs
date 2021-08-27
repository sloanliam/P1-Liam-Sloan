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

        revtrainingdbContext context = new revtrainingdbContext();

        public string GetUsername(int userId)
        {
            var userList = context.Users.Single(u => u.Id == userId);

            return (string)userList.Username;
        }
    }
}
