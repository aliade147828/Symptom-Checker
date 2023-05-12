using System.Collections;
using System.Collections.Generic;

namespace WebApplication5.ViewModels
{
    public class userViewModel
    {
        public string id { get; set; }
        public string userName { get; set; }
        public IEnumerable<string> roles { get; set; }
    }
}
