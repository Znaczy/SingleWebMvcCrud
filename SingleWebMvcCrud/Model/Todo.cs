using System.ComponentModel.DataAnnotations;

namespace SingleWebMvcCrud.Model
{
    public class Todo
    {
        public int Id { get; set; }
        [Required, MaxLength(256)]
        public string WhatIsTodo { get; set; }
        public bool IsDone { get; set; }
    }
}