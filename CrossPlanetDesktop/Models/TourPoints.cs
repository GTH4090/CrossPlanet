//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrossPlanetDesktop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TourPoints
    {
        public int Id { get; set; }
        public int TourTaskId { get; set; }
        public int PointId { get; set; }
    
        public virtual Point Point { get; set; }
        public virtual TourTask TourTask { get; set; }
    }
}