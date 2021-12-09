using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopify.Model.Dtos
{
    public class UserDto
    {
        //Simple model or Viewmodel.
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
