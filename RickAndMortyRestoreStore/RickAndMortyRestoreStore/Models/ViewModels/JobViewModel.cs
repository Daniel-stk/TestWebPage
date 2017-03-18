using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RickAndMortyRestoreStore.Models.ViewModels
{
    public class JobViewModel
    {

        public int JobId { get; set; }
        private List<StateViewModel> _State = null;
        [Display(Name ="Title")]
        public string Name { get; set; }
        [Display(Name ="Summary")]
        public string Description { get; set; }
        [Display(Name="Status")]
        public List<StateViewModel> State
        {
            get
            {
                if(_State == null)
                {
                    _State = new List<StateViewModel>()
                    {   
                        new StateViewModel {Id = 1, StateName = "Pending" },
                        new StateViewModel {Id = 2, StateName = "Working on int" },
                        new StateViewModel {Id = 3, StateName = "Donde" }
                    };
                }
                return _State;
            }
        }
        [Display(Name = "Actual Status")]
        public string ActualState { get; set; }
        [Display(Name="Before")]
        public string MediaBefore { get; set; }
        [Display(Name="After")]
        public string MediaAfter { get; set; }
        [Display(Name="Recived On")]
        public DateTime StartDate { get; set; }
        [Display(Name="Done by")]
        public DateTime? EndDate { get; set; }
        public List<CommentsViewModel> Comments { get; set; } 
    }

    public class StateViewModel
    {
        public int Id { get; set; }
        public string StateName { get; set; }
    }
}