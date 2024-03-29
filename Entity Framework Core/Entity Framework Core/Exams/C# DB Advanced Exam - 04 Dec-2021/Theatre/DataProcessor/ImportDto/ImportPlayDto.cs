﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [XmlElement("Title")]
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Required]
        [Range(typeof(float), "0.00", "10.00")]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [XmlElement("Screenwriter")]
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Screenwriter { get; set; }
    }
}
