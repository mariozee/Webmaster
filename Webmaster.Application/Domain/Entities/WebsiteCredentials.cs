using System;
using System.Collections.Generic;
using System.Text;

namespace Webmaster.Application.Domain.Entities
{
    public class WebsiteCredentials
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
