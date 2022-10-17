using PagerApp.Models;
using System.Collections.Generic;

namespace ImageList.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Image> Images { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
