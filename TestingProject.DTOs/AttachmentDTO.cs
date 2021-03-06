﻿using System;

namespace TestingProject.DTOs
{
    public class AttachmentDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public string FilePath { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class NullAttachmentDTO : AttachmentDTO
    {
        public NullAttachmentDTO()
        {
            Id = -1;
            FileName = "Empty";
            OriginalFileName = "Empty";
            FilePath = "Empty";
            DateAdded = DateTime.MinValue;
        }
    }
}
