using System;
using System.Collections.Generic;
using System.Text;

namespace Webmaster.Application.Domain.Entities
{
    public class WebsiteCategory
    {
        public WebsiteCategory()
        {
            this.Websites = new HashSet<Website>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Website> Websites { get; set; }
    }
}
