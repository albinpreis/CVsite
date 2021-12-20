using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;



namespace Shared
{
    public class UserCreateModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public HttpPostedFileBase Image { get; set; }
        public string Address { get; set; }
        public bool PrivateUser { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


    }
}
