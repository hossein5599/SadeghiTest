using Microsoft.AspNetCore.Mvc.Rendering;

namespace SadeghiTest.Models
{
    public class IndexViewModel
    {
 
        public  IEnumerable<MyModel>? MyModels { get; set; }

        public List<SelectListItem> DLTypeOptions { get; set; }
}
}
