﻿namespace Academy.DAL.Entities
{
    public class TeacherGroups : Entity
    {
        public int TeacherId { get; set; }  
        public int GroupId { get; set; }
        public Teacher Teacher { get; set; }    
        public Group Group { get; set; }
    }
}
