using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Contants
{
    static class MessageTemplate
    {
        public const string BLOG_APPROVED_TEMPLATE = "Dear {firstName} {lastName}, your blog {title} approved by admin.";
        public const string BLOG_REJECTED_TEMPLATE = "Dear {firstName} {lastName}, your blog {title} rejected by admin.";
    }
}
