using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebAPI.Entities
{
    public class Author{

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;}
        public string Name { get; set;}
        public bool IsActive {get; set;}
    }
}