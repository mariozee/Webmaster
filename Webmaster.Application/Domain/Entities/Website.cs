using System;
using System.Collections.Generic;
using System.Text;

namespace Webmaster.Application.Domain.Entities
{
    public class Website
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int CategoryId { get; set; }
        public virtual WebsiteCategory Category { get; set; }

        public string ImagePath { get; set; }

        public bool Deleted { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
