using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDBApp.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }

        [Column(TypeName = "int")]
        public int Age { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string City { get; set; }

        public override string ToString()
        {
            return $"Id:{UserId}, username: {Username}, age: {Age}, city:{City}";
        }
    }
}
