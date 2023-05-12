using System.Collections.Generic;

namespace WebApplication5.ViewModels
{
    public class userRoleViewModel
    {
        public string  userId { get; set; }
        public string userName { get; set; }
        public List<roleViewModel> Roles { get; set; }
    }
}
