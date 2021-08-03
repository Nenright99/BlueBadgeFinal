﻿using BlueBadgeFinal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinal.Models.MovieModels
{
    public class MovieListItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public GenreType TypeOfGenres { get; set; }
        public string Actors { get; set; }
        public int TheatreID { get; set; }
    }
}
